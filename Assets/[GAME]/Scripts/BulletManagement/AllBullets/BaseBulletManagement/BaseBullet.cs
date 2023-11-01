using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BaseGameScripts.Pool;
using Scripts.EnemyManagement;
using Scripts.GameScripts;
using Scripts.GameScripts.BulletManagement;
using Scripts.GameScripts.BulletManagement.AllBullets.BaseBulletManagement;
using Scripts.GameScripts.BulletManagement.BaseBulletMovementManagement;
using Scripts.GameScripts.CharacterManagement;
using Scripts.GameScripts.PlayerManagement;
using Scripts.PlayerManagement;
using UnityEngine;

namespace Scripts.BulletManagement.AllBullets.BaseBulletManagement
{
    public abstract class BaseBullet : BaseComponent
    {
        private float _bulletSize;


        private FireType _currentFireType;
        private int _damage;
        private float _frostDuration;
        private bool _isFiredByPlayer;

        private Vector3 _moveToDir;
        private float _speed;

        [SerializeField]
        private BaseBulletDataSo baseBulletDataSo;

        [SerializeField]
        private BaseBulletEffectManager baseBulletEffectManager;

        [SerializeField]
        private BasePoolItem basePoolItem;

        [SerializeField]
        private BulletGfxManager bulletGfxManager;

        [SerializeField]
        private BulletInteractionManager bulletInteractionManager;

        [SerializeField]
        private BaseBulletMovement bulletMovement;

        public BasePoolItem BasePoolItem => basePoolItem;
        protected BaseBulletDataSo BaseBulletDataSo => baseBulletDataSo;
        private BaseBulletEffectManager BaseBulletEffectsManager => baseBulletEffectManager;

        private void Awake()
        {
            bulletInteractionManager.onInteract += OnInteract;
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            BulletManager.Instance.AddBullet(this);
        }

        public virtual void OnUpdate()
        {
            bulletMovement.MoveToDir(_moveToDir);
        }


        public void SetData(int damageToHit, float speedIncreasePercentage, float size, FireType fireType,
            bool isFiredByPlayer, Color bulletColor, float frostDuration = 0f)
        {
            _damage = damageToHit;
            _speed = speedIncreasePercentage;
            _bulletSize = size;
            _currentFireType = fireType;
            _frostDuration = frostDuration;
            _isFiredByPlayer = isFiredByPlayer;
            BaseBulletEffectsManager.CreateBulletEffect(TransformOfObj, _currentFireType);
            bulletMovement.UpdateSpeed(_speed);
            bulletGfxManager.SetBulletSize(_bulletSize, bulletColor);
        }

        public virtual void SetTarget(Vector3 dir) // güdümsüz mermi
        {
            _moveToDir = dir;
            bulletMovement.CanMove = true;
            bulletMovement.UpdateRotation(dir);
        }

        public virtual void SetTarget(Transform target) // güdümlü mermi
        {
            bulletMovement.CanMove = true;
        }


        protected virtual void ResetVariables()
        {
            bulletMovement.CanMove = false;
        }


        private void OnInteract(BaseCharacterManager chararacter)
        {
            if (!chararacter)
            {
                SendToPool();
                return;
            }

            if (_isFiredByPlayer)
            {
                if (chararacter.TryGetComponent(out PlayerManager playerManager))
                    return;
            }
            else
            {
                if (chararacter.TryGetComponent(out BaseEnemyManager enemyManager))
                    return;
            }

            Damage(chararacter);
            SendToPool();
        }

        private void Damage(BaseCharacterManager chararacter)
        {
            chararacter.TakeDamage(_damage, FireType.Normal);
            // if(_currentFireType == FireType.Frost)
            //     chararacter.Freeze(_frostDuration);

            var forward = chararacter.TransformOfObj.forward;
            var position = chararacter.TransformOfObj.position - forward * .25f;
            BaseBulletEffectsManager.CreateHiEffect(position, position - forward);
        }

        private void SendToPool()
        {
            BulletManager.Instance.RemoveBullet(this);
            BaseBulletEffectsManager.SendEffectsToThePool();
            ResetVariables();
            BasePoolItem.AddObjToPool(this);
        }
    }
}