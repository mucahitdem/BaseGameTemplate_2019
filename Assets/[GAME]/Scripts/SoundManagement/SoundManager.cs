using System.Collections.Generic;
using Scripts;
using Scripts.BaseGameScripts.Helper;
using Scripts.GameScripts;
using Scripts.GameScripts.GameManagement;
using Scripts.GameScripts.PlayerManagement;
using Scripts.PlayerManagement;
using UnityEngine;

namespace _GAME_.Scripts.GameScripts.SoundManagement
{
    public class SoundManager : SingletonMono<SoundManager>
    {
        private readonly Dictionary<string, AudioClip> _idsAndClips = new Dictionary<string, AudioClip>();
        private float _initialBgVolume;
        private float _initialSecondBgVolume;

        private bool _isEffectsDisabled;
        private AudioClip _tempClip;

        [SerializeField]
        private PooledAudioSource audioSource;

        [SerializeField]
        private AudioSource bg;

        public float bgSoundVolumeMultiply;

        [SerializeField]
        private AudioClipAndId[] clips;

        [SerializeField]
        private AudioSource globalEffects;

        public float globalSoundVolume;
        private PlayerManager playerManager;

        [SerializeField]
        private AudioSource secondBg;

        protected override void OnAwake()
        {
            for (var i = 0; i < clips.Length; i++)
            {
                var currentData = clips[i];
                _idsAndClips[currentData.clipId] = currentData.audioClip;
            }

            _initialBgVolume = bg.volume;
            _initialSecondBgVolume = secondBg.volume;

            bgSoundVolumeMultiply = PlayerPrefs.GetFloat(Defs.SAVE_KEY_BG_VOLUME_MULTIPLIER, 1);
            globalSoundVolume = PlayerPrefs.GetFloat(Defs.SAVE_KEY_GLOBAL_VOLUME, 1);
            _isEffectsDisabled = PlayerPrefs.GetInt(Defs.SAVE_KEY_IS_EFFECTS_DISABLED, 0) != 0;

            SetBgSoundVolume(bgSoundVolumeMultiply);
        }

        public void ControlBg(bool isEnabled)
        {
            if (isEnabled)
            {
                bg.Play();
                secondBg.Play();
            }
            else
            {
                bg.Stop();
                secondBg.Stop();
            }
        }

        public void ControlGlobalVolume(bool isEnabled)
        {
            _isEffectsDisabled = isEnabled;
            PlayerPrefs.SetInt(Defs.SAVE_KEY_IS_EFFECTS_DISABLED, _isEffectsDisabled ? 1 : 0);
        }

        public float GetMusicVolume()
        {
            return bgSoundVolumeMultiply;
        }

        public float GetFxVolume()
        {
            return globalSoundVolume;
        }

        public void SetBgSoundVolume(float volume)
        {
            bgSoundVolumeMultiply = volume;
            PlayerPrefs.SetFloat(Defs.SAVE_KEY_BG_VOLUME_MULTIPLIER, bgSoundVolumeMultiply);

            bg.volume = bgSoundVolumeMultiply * _initialBgVolume;
            secondBg.volume *= bgSoundVolumeMultiply * _initialSecondBgVolume;
        }

        public void SetGlobalSoundVolume(float volume)
        {
            globalSoundVolume = volume;
            PlayerPrefs.SetFloat(Defs.SAVE_KEY_GLOBAL_VOLUME, globalSoundVolume);
        }

        private void Start()
        {
            playerManager = GameManager.Instance.Player;
        }

        public void AddBgSound(string id)
        {
            var clip = ClipWithId(id);
            secondBg.clip = clip;
            secondBg.Play();
        }

        public void ClearBgSound()
        {
            secondBg.Stop();
        }

        public void PlayGlobalAudio(string id)
        {
            if (_isEffectsDisabled)
                return;
            var clip = ClipWithId(id);

            if (clip)
            {
                var source =
                    audioSource.BasePoolItem.PullObjFromPool<PooledAudioSource>(playerManager
                        ? playerManager.TransformOfObj.position
                        : Vector3.zero);
                source.AudioSource.volume = globalSoundVolume;
                source.PlayClip(clip);
                //globalEffects.PlayOneShot(clip);
            }
        }

        public void PlayAudioAtPosition(string id, Vector3 targetPos)
        {
            var clip = ClipWithId(id);
            if (clip == null)
                return;
            var source = audioSource.BasePoolItem.PullObjFromPool<PooledAudioSource>(targetPos);
            source.PlayClip(clip);
        }


        public AudioClip ClipWithId(string id)
        {
            if (_idsAndClips.TryGetValue(id, out _tempClip)) return _tempClip;

            DebugHelper.LogRed("THERE IS NO AUDIO WITH THIS ID");
            return null;
        }
    }
}