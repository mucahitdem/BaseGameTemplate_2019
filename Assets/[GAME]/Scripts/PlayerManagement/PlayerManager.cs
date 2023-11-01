using System;
using System.Collections;
using _GAME_.Scripts.GameScripts.SoundManagement;
using Scripts.AnimatorManagement;
using Scripts.BaseGameScripts.FadeUiManagement;
using Scripts.BaseGameScripts.Helper;
using Scripts.BaseGameScripts.TimerManagement;
using Scripts.EnemyManagement;
using Scripts.GameScripts;
using Scripts.GameScripts.AnimationEventsManagement;
using Scripts.GameScripts.CameraManagement;
using Scripts.GameScripts.CharacterManagement;
using Scripts.GameScripts.FindTargetsInAreaManagement;
using Scripts.GameScripts.GfxManagement;
using Scripts.GameScripts.Helpers;
using Scripts.GameScripts.InteractionManagement;
using Scripts.GameScripts.MovementManagement.BaseMovementManagement;
using Scripts.GameScripts.PlayerManagement;
using Scripts.GameScripts.RigUpdaterManagement;
using Scripts.GameScripts.SkillManagement;
using Scripts.GameScripts.StatsManagement.PlayerStatsManagement;
using Scripts.GameScripts.WeaponManagement.Weapons;
using Scripts.InteractionManagement;
using Scripts.MovementManagement.BaseMovementManagement;
using Scripts.StatsManagement.PlayerStatsManagement;
using Scripts.WeaponManagement.Weapons;
using UnityEngine;

namespace Scripts.PlayerManagement
{
    public sealed class PlayerManager : BaseCharacterManager
    {
        private PlayerAnimator _playerAnimator;

        [SerializeField]
        private AnimationEvents animationEvents;

        [SerializeField]
        private BaseMovement baseMovement;

        [SerializeField]
        private BaseRigUpdater baseRigUpdater;

        [SerializeField]
        private FindNearestTargetInArea findNearestTargetInArea;

        [SerializeField]
        private GfxManager gfxManager;

        [SerializeField]
        private GroundChecker groundChecker;

        [SerializeField]
        private Timer healthFillingTimer;


        public bool isRiding;

        [SerializeField]
        private PlayerInteractionManager playerInteractionManager;

        [SerializeField]
        private PlayerStatsManager playerStatsManager;

        [SerializeField]
        private SkillManager skillManager;

        [SerializeField]
        private BaseWeapon weapon;

        public PlayerAnimator PlayerAnimator
        {
            get
            {
                if (!_playerAnimator)
                    _playerAnimator = (PlayerAnimator) animator;

                return _playerAnimator;
            }
        }

        public BaseWeapon Weapon
        {
            get
            {
                if (!weapon)
                    weapon = GetComponentInChildren<BaseWeapon>();

                return weapon;
            }
        }

        public SkillManager SkillManager => skillManager;
        public PlayerStatsManager PlayerStatsManager => playerStatsManager;
        public FindNearestTargetInArea FindNearestTargetInArea => findNearestTargetInArea;
        public BaseRigUpdater BaseRigUpdater => baseRigUpdater;
        private BaseMovement BaseMovement => baseMovement;

        protected override void Awake()
        {
            base.Awake();
            _playerAnimator = (PlayerAnimator) animator;
            baseMovement.Insert(this);
            animator.Insert(this);
            baseRigUpdater.Insert(this);
            //xpCollector.Insert(this);
            playerInteractionManager.Insert(this);
            healthLevelIndex = PlayerPrefs.GetInt(Defs.SAVE_KEY_PLAYER_HEALTH, 0);
            damageLevelIndex = PlayerPrefs.GetInt(Defs.SAVE_KEY_PLAYER_DAMAGE, 0);
            movementLevelIndex = PlayerPrefs.GetInt(Defs.SAVE_KEY_PLAYER_SPEED, 0);
        }

        private IEnumerator Start()
        {
            yield return new WaitForEndOfFrame();
            Weapon.Insert(this);
            Weapon.onShootingState += OnShoot;
            Weapon.targetToShoot += GetNearestEnemy;
            Weapon.onFireRangeUpdated += OnFireRangeUpdated;
            var damage = BaseCharacterDataSo.baseCharacterData.characterData.damageAndCost[damageLevelIndex].value;
            DebugHelper.LogYellow("PLAYER DAMAGE : " + damage);
            Weapon.updateDamage?.Invoke(damage);
            findNearestTargetInArea.SetNewRange(Weapon.CurrentFireRange);
            baseStatsManager.UpgradeHealth(healthLevelIndex);
            baseMovement.UpgradeSpeed(movementLevelIndex);
        }

        private void Update()
        {
            if (IsDead)
            {
                if (animator.AnimatorStateManager.GetBool(Defs.ANIM_KEY_DIE) == false)
                    animator.AnimatorStateManager.SetBool(Defs.ANIM_KEY_DIE, true, true);

                return;
            }

            if (!IsEnabled)
                return;


            if (Time.frameCount % 10 == 0)
            {
                var targetToShoot = FindNearestTargetInArea.FindNearestChar<BaseEnemyManager>();
                PlayerStatsManager.showUiBar?.Invoke(targetToShoot);
                if (targetToShoot)
                {
                    if (healthFillingTimer.IsRunning) healthFillingTimer.StopTimer();
                }
                else
                {
                    if (!healthFillingTimer.IsRunning && !playerStatsManager.IsHealthFilled)
                        healthFillingTimer.RestartTimer();
                }
            }

            baseMovement.OnUpdate();


            if (isRiding)
                DebugHelper.LogRed("IS RIDING");
            else
                _playerAnimator.UpdateAnimatorWithInput(IsInputExist());
        }

        private void FixedUpdate()
        {
            if (!IsEnabled || IsDead)
                return;
            baseMovement.OnFixedUpdate();
        }

        private void LateUpdate()
        {
            if (!IsEnabled || IsDead)
                return;
            var target = GetNearestEnemy()?.TransformOfObj;
            baseRigUpdater.UpdateRig(target);
        }

        private void OnCollisionEnter(Collision other)
        {
            Rb.velocity = Vector3.zero;
        }

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            playerInteractionManager.onInteractedWithEnemy += OnInteractedWithEnemy;
            PlayerStatsActionManager.onLevelChanged += OnLevelChanged;

            PlayerActionManager.gainHp += GainHp;
            PlayerActionManager.gainMaxHp += GainMaxHp;
            PlayerActionManager.increasePlayerSizePercentage += IncreasePlayerSizePercentage;
            UpgradeDamage += UpgradeDmg;
            UpgradeHealth += UpgradeHlth;
            UpgradeMovementSpeed += UpgradeMvment;
            healthFillingTimer.onTimerEnded += HealthFillComplete;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            playerInteractionManager.onInteractedWithEnemy -= OnInteractedWithEnemy;
            PlayerStatsActionManager.onLevelChanged -= OnLevelChanged;

            Weapon.onShootingState -= OnShoot;
            Weapon.targetToShoot -= GetNearestEnemy;
            Weapon.onFireRangeUpdated -= OnFireRangeUpdated;

            PlayerActionManager.gainHp -= GainHp;
            PlayerActionManager.gainMaxHp -= GainMaxHp;
            PlayerActionManager.increasePlayerSizePercentage -= IncreasePlayerSizePercentage;
            UpgradeDamage -= UpgradeDmg;
            UpgradeHealth -= UpgradeHlth;
            UpgradeMovementSpeed -= UpgradeMvment;
            healthFillingTimer.onTimerEnded -= HealthFillComplete;
        }

        public CostAndValue HealthValues(int additionalValue)
        {
            return baseStatsManager.UpgradeHealthValues(healthLevelIndex + additionalValue);
        }

        public CostAndValue SpeedValues(int additionalValue) // 0 means current Level Values
        {
            return baseMovement.UpgradeSpeedValues(movementLevelIndex + additionalValue);
        }

        public CostAndValue DamageValues(int additionalValue)
        {
            var allValues = BaseCharacterDataSo.baseCharacterData.characterData.damageAndCost;
            if (additionalValue >= allValues.Length)
                return new CostAndValue(-1, -1);
            return allValues[damageLevelIndex + additionalValue];
        }


        public override void Reset()
        {
            base.Reset();
            Weapon.isDisabled = false;
            PlayerStatsManager.ResetHealth();
            animator.AnimatorStateManager.SetBool(Defs.ANIM_KEY_DIE, false, true);
            Rb.constraints = RigidbodyConstraints.FreezePositionY |
                             RigidbodyConstraints.FreezeRotationZ |
                             RigidbodyConstraints.FreezeRotationX;
            gfxManager.Gfx.SetLocalPositionAndRotation(Vector3.zero, Quaternion.Euler(Vector3.zero));
        }

        protected override void OnDied(float takenDamage)
        {
            if (IsDead)
                return;

            Weapon.isDisabled = true;
            SoundManager.Instance.PlayGlobalAudio(Defs.AUDIO_PLAYER_DEATH);
            base.OnDied(takenDamage);
            Rb.constraints = RigidbodyConstraints.FreezeAll;
            animator.AnimatorStateManager.SetBool(Defs.ANIM_KEY_DIE, true, true);
        }

        protected override void TakeDamage(float damage)
        {
            if (IsDead || !IsEnabled || !CanTakeDamage)
                return;
            base.TakeDamage(damage);
            animator.AnimatorStateManager.SetTrigger(Defs.ANIM_KEY_HIT, true);
            CameraActionManager.shakeCamera?.Invoke(new CameraShakeData(.09f, 6f, .1f));
            PlayerActionManager.onPlayerTakeDamage?.Invoke();
        }
        

        private void HealthFillComplete()
        {
            playerStatsManager.UpgradeHealth(healthLevelIndex);
        }
        
        private void UpgradeHlth()
        {
            healthLevelIndex++;
            baseStatsManager.UpgradeHealth(healthLevelIndex);
            PlayerPrefs.SetInt(Defs.SAVE_KEY_PLAYER_HEALTH, healthLevelIndex);
        }

        private void UpgradeDmg()
        {
            damageLevelIndex++;
            var damage = BaseCharacterDataSo.baseCharacterData.characterData.damageAndCost[damageLevelIndex].value;
            Weapon.updateDamage?.Invoke(damage);

            PlayerPrefs.SetInt(Defs.SAVE_KEY_PLAYER_DAMAGE, damageLevelIndex);
        }

        private void UpgradeMvment()
        {
            movementLevelIndex++;
            baseMovement.UpgradeSpeed(movementLevelIndex);

            PlayerPrefs.SetInt(Defs.SAVE_KEY_PLAYER_SPEED, movementLevelIndex);
        }

        private void IncreasePlayerSizePercentage(float percentage)
        {
            var currentSize = TransformOfObj.localScale;
            var nextSize = currentSize + Vector3.one * MathCalculations.CalculatePercentage(currentSize.x, percentage);
            //DebugHelper.LogYellow("PLAYER SIZE : " + currentSize + " /// " + nextSize);
            TransformOfObj.localScale = nextSize;
        }

        private void GainMaxHp(int increaseAmount)
        {
            PlayerStatsManager.GainMaxHealth(increaseAmount);
        }

        private void GainHp(int amount)
        {
            PlayerStatsManager.GainHealth(amount);
        }

        private void OnFireRangeUpdated(float currentRange)
        {
            findNearestTargetInArea.UpdateRadius(currentRange);
        }

        private void OnLevelChanged(int level)
        {
            if (level <= 1)
                return;

            Time.timeScale = 0f;
            skillManager.OpenSkillUpgradePanel();
        }

        private void OnInteractedWithEnemy()
        {
            // TakeDamage(1);
            // gfxManager.OnDamaged();
            // playerInteractionManager.DisableInteractionForTime();
        }

        private BaseEnemyManager GetNearestEnemy()
        {
            if (Weapon.isDisabled)
                return null;
            var targetToShoot = FindNearestTargetInArea.FindNearestChar<BaseEnemyManager>();
            return targetToShoot;
        }

        private void OnShoot(bool isShooting)
        {
            // CameraActionManager.shakeCamera?.Invoke(new CameraShakeData(.09f, 4f, .1f));
            animator.AnimatorStateManager.AnimOfObj.Play(Defs.ANIM_KEY_SHOOT, 1, 0);
        }

        private bool IsInputExist()
        {
            return Mathf.Abs(BaseMovement.PlayerInput.magnitude) > 0f;
        }
    }
}