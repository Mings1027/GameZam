using System;
using System.Collections.Generic;
using GameControl;
using UnityEngine;

namespace ManagerControl
{
    public class SoundManager : Singleton<SoundManager>
    {
        public const string TitleBGM = "TitleBGM";
        public const string InGameBGM = "InGameBGM";
        public const string BossBGM = "BossBGM";
        
        public const string BossKillerWhaleAlarm = "BossKillerWhaleAlarm";
        public const string BossKillerWhaleBreath = "BossKillerWhaleBreath";
        public const string BossKillerWhaleProjectile = "BossKillerWhaleProjectile";
        public const string CrotchAppear = "CrotchAppear";
        public const string Breath = "Breath";
        public const string ButtonClick = "ButtonClick";
        public const string ClearEnding = "ClearEnding";
        public const string Dash = "Dash";
        public const string FailEnding = "FailEnding";
        public const string GetClam = "GetClam";
        public const string KillerWhaleAlarm = "KillerWhaleAlarm";
        public const string KillerWhaleAppear = "KillerWhaleAppear";
        public const string OnCollision = "OnCollision";

        [Serializable]
        public class BGMSound
        {
            public string bgmName;
            public AudioClip bgmSource;
        }

        [Serializable]
        public class EffectSound
        {
            public string effectName;
            public AudioClip effectSource;
        }

        private bool _musicOn;
        private Dictionary<string, AudioClip> _bgmDictionary;
        private Dictionary<string, AudioClip> _effectDictionary;

        [SerializeField] private AudioSource musicSource, effectsSource;
        [SerializeField] private BGMSound[] bgmSounds;
        [SerializeField] private EffectSound[] effectSounds;

        private void Awake()
        {
            _bgmDictionary = new Dictionary<string, AudioClip>();
            foreach (var s in bgmSounds)
            {
                _bgmDictionary.Add(s.bgmName, s.bgmSource);
            }

            _effectDictionary = new Dictionary<string, AudioClip>();
            foreach (var t in effectSounds)
            {
                _effectDictionary.Add(t.effectName, t.effectSource);
            }
        }

        public void PlayBGM(string clipName)
        {
            var clip = _bgmDictionary[clipName];
            musicSource.PlayOneShot(clip);
        }

        public void PlaySound(string clipName)
        {
            var clip = _effectDictionary[clipName];
            effectsSource.PlayOneShot(clip);
        }

        public bool BGMToggle()
        {
            if (_musicOn)
            {
                _musicOn = false;
                musicSource.mute = true;
            }
            else
            {
                _musicOn = true;
                musicSource.mute = false;
            }

            return _musicOn;
        }
    }
}