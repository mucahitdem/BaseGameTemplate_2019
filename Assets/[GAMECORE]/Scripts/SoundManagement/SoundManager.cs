using System;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.Utilities;
using UnityEngine;

namespace GAME.Scripts.SoundManagement
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField]
        private PooledAudioSource audioSource;

        [SerializeField]
        private AudioSource music;

        [SerializeField]
        private AudioSource environment;

        [SerializeField]
        private AudioSource gamePlay;

        [SerializeField]
        private AudioClipAndId[] clips;


        public float GamePlaySoundVolume { get; private set; }
        public float MusicSoundVolume { get; private set; }
        public float EnvironmentSoundVolume { get; private set; }


        private readonly Dictionary<string, AudioClipAndId> _idsAndClips = new Dictionary<string, AudioClipAndId>();


        public static readonly string SAVE_KEYS_GAME_PLAY_VOLUME_MULTIPLIER = "GamePlayVolume";
        public static readonly string SAVE_KEY_MUSIC_VOLUME_MULTIPLIER = "MusicVolume";
        public static readonly string SAVE_KEY_ENVIRONMENT_VOLUME_MULTIPLIER = "EnvironmentVolume";
        
        public static readonly string AUDIO_BUTTON_CLICK = "ButtonClick";
        public static readonly string AUDIO_SMART_PHONE_NOTIFICATION = "SmartphoneNotification";
        public static readonly string AUDIO_SMART_PHONE_NEW_ORDER_NOTIFICATION = "NewOrderNotification";
        public static readonly string AUDIO_CITY_BG = "CityBg";
        public static readonly string AUDIO_SUBURB_BG = "SuburbanBg";
        public static readonly string AUDIO_ORDER_CANCELLED = "OrderCancelled";
        public static readonly string AUDIO_ORDER_DELIVERED = "OrderDelivered";
        public static readonly string AUDIO_LEVEL_UP = "LevelUp";

        private void Awake()
        {
            CreateDictionary();

            GamePlaySoundVolume = ES3.Load<float>(SAVE_KEYS_GAME_PLAY_VOLUME_MULTIPLIER, 1);
            MusicSoundVolume = ES3.Load<float>(SAVE_KEY_MUSIC_VOLUME_MULTIPLIER, 1);
            EnvironmentSoundVolume = ES3.Load<float>(SAVE_KEY_ENVIRONMENT_VOLUME_MULTIPLIER, 1);
            
            UpdateVolume(GamePlaySoundVolume, AudioType.GamePlay);
            UpdateVolume(MusicSoundVolume, AudioType.Music);
            UpdateVolume(EnvironmentSoundVolume, AudioType.Environment);
        }
        public void StopMusic(string id)
        {
            var clipData = ClipDataWithId(id);

            AudioSource currentSource = null;

            switch (clipData.audioType)
            {
                case AudioType.Music:

                    currentSource = music;
                    break;

                case AudioType.Environment:

                    currentSource = environment;
                    break;

                case AudioType.GamePlay:

                    currentSource = gamePlay;
                    break;
            }

            var currentSourceVolume = currentSource.volume;
            DOTween.To(() => currentSourceVolume, x => currentSourceVolume = x, 0, 1f)
                .OnUpdate(() => { currentSource.volume = currentSourceVolume; });
        }

        
        
        public void UpdateVolume(float value, AudioType audioType)
        {
            switch (audioType)
            {
                case AudioType.Master:
                    GamePlaySoundVolume = value;
                    MusicSoundVolume = value;
                    EnvironmentSoundVolume = value;
                    break;

                case AudioType.GamePlay:
                    GamePlaySoundVolume = value;
                    break;

                case AudioType.Music:
                    MusicSoundVolume = value;
                    break;

                case AudioType.Environment:
                    EnvironmentSoundVolume = value;
                    break;
            }

            gamePlay.volume = GamePlaySoundVolume;
            music.volume = MusicSoundVolume;
            environment.volume = EnvironmentSoundVolume;
        }
        public void PlayAudio(string id) //sounds ignores position // todo refactor
        {
            if (id.IsNullOrWhitespace())
            {
                Debug.LogError("NULL ID");
                return;
            }

            var clipData = ClipDataWithId(id);

            if (clipData == null)
            {
                Debug.LogError("CLIP DATA WITH ID : " + id + " NULL");
                return;
            }

            AudioSource currentSource = null;
            float currentSoundVolumeMultiplier = 0;


            switch (clipData.audioType)
            {
                case AudioType.Music:

                    currentSource = music;
                    currentSoundVolumeMultiplier = MusicSoundVolume;

                    break;

                case AudioType.Environment:

                    currentSource = environment;
                    currentSoundVolumeMultiplier = EnvironmentSoundVolume;

                    break;

                case AudioType.GamePlay:

                    currentSource = gamePlay;
                    currentSoundVolumeMultiplier = GamePlaySoundVolume;

                    break;
            }

            if (currentSoundVolumeMultiplier <= 0)
                return;

            var clip = clipData.audioClip;

            if (currentSource != null)
            {
                currentSource.volume = clipData.volume * currentSoundVolumeMultiplier;

                if (currentSource == gamePlay)
                    currentSource.PlayOneShot(clip);
                else
                {
                    SoundTransition(currentSource, clip);
                    // currentSource.clip = clip;
                    // currentSource.Play();
                }
            }
        }
        public void PlayAudioAtPosition(string id, Vector3 targetPos)
        {
            if (GamePlaySoundVolume <= 0)
                return;
            var clip = ClipDataWithId(id);

            var source = audioSource.BasePoolItem.PullObjFromPool<PooledAudioSource>(targetPos);
            source.AudioSource.volume = clip.volume;
            source.PlayClip(clip.audioClip);
        }


        private AudioClipAndId ClipDataWithId(string id)
        {
            if (_idsAndClips.TryGetValue(id, out AudioClipAndId clipAndId))
                return clipAndId;

            //Debug.LogError("THERE IS NO AUDIO WITH ID : " + id);
            return default;
        }
        private void CreateDictionary()
        {
            for (var i = 0; i < clips.Length; i++)
            {
                var currentData = clips[i];
                _idsAndClips[currentData.clipAddress] = currentData;
            }
        }
        private void SoundTransition(AudioSource currentSource, AudioClip clipToSet)
        {
            var currentSourceVolume = currentSource.volume;
            UpdateVolume(currentSource, 0, 1, () =>
            {
                currentSource.clip = clipToSet;
                UpdateVolume(currentSource, currentSourceVolume, 1, null);
            });
        }
        private void UpdateVolume(AudioSource currentSource, float endValue, float duration, Action onEnd)
        {
            var currentSourceVolume = currentSource.volume;
            DOTween.To(() => currentSourceVolume, x => currentSourceVolume = x, endValue, duration)
                .OnUpdate(() =>
                {
                    currentSource.volume = currentSourceVolume;
                })
                .OnComplete(() =>
                {
                    onEnd?.Invoke();
                });
        }
    }
}