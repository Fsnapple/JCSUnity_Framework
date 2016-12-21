﻿/**
 * $File: JCS_SoundManager.cs $
 * $Date: $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: $
 */
using UnityEngine;
using System.Collections;


namespace JCSUnity
{

    /// <summary>
    /// 
    /// </summary>
    [RequireComponent(typeof(JCS_SoundPlayer))]
    public class JCS_SoundManager 
        : MonoBehaviour
    {

        //----------------------
        // Public Variables
        public static JCS_SoundManager instance = null;

        //----------------------
        // Private Variables
        private AudioListener mAudioListener = null;

        // environment, ui, etc.
        private JCS_Vector<AudioSource> mSFXSounds = null;

        // personal stuff, personal skill, personal jump walk, etc.
        private JCS_Vector<AudioSource> mSkillsSounds = null;

        private JCS_SoundPlayer mGlobalSoundPlayer = null;

        [Header("** Check Variables (JCS_SoundManager) **")]

        [Tooltip("")]
        [SerializeField]
        private AudioSource mBGM = null;

        //----------------------
        // Protected Variables

        //========================================
        //      setter / getter
        //------------------------------
        public void SetAudioListener(AudioListener al) { this.mAudioListener = al; }
        public AudioListener GetAudioListener() { return this.mAudioListener; }
        public AudioSource GetBackgroundMusic() { return this.mBGM; }
        public void SetBackgroundMusic(AudioSource music)
        {
            this.mBGM = music;

            this.mBGM.volume = JCS_GameSettings.GetBGM_Volume();
            this.mBGM.mute = JCS_GameSettings.BGM_MUTE;
        }
        public JCS_Vector<AudioSource> GetEffectSounds() { return this.mSFXSounds; }
        public JCS_SoundPlayer GetGlobalSoundPlayer() { return this.mGlobalSoundPlayer; }

        //========================================
        //      Unity's function
        //------------------------------
        private void OnApplicationFocus(bool focusStatus)
        {
            // turn off all the sound effect
            if (!focusStatus)
            {
                // mute all the sound
                AudioListener.volume = 0;
            }
            else
            {
                // enable all the sound
                AudioListener.volume = 1;
            }
        }

        private void Awake()
        {
            instance = this;

            mSFXSounds = new JCS_Vector<AudioSource>();
            mSkillsSounds = new JCS_Vector<AudioSource>();

            mGlobalSoundPlayer = this.GetComponent<JCS_SoundPlayer>();
        }

        private void Start()
        {
            if (JCS_Camera.main == null)
            {
                JCS_Debug.JcsErrors(
                    "JCS_SoundManager", 
                      
                    "There is no \"JCS_Camera\" assign!");

                return;
            }

            // Reset the sound every scene
            SetSFXSoundVolume(JCS_GameSettings.GetSFXSound_Volume());
            SetSkillsSoundVolume(JCS_GameSettings.GetSkillsSound_Volume());
            SetSFXSoundMute(JCS_GameSettings.EFFECT_MUTE);
            SetSkillsSoundMute(JCS_GameSettings.PERFONAL_EFFECT_MUTE);
        }


        //========================================
        //      Self-Define
        //------------------------------
        //----------------------
        // Public Functions

        /// <summary>
        /// Push to the sound effect into array ready for use!
        /// </summary>
        /// <param name="sound"></param>
        public void PlayOneShotSFXSound(int index)
        {
            AudioSource aud = mSFXSounds.at(index);
            if (aud.clip != null)
                aud.PlayOneShot(aud.clip, JCS_GameSettings.GetSFXSound_Volume());
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="source"></param>
        public void AssignSoundSource(JCS_SoundSettingType type, AudioSource source)
        {
            switch (type)
            {
                case JCS_SoundSettingType.NONE:
                    return;
                case JCS_SoundSettingType.BGM_SOUND:
                    SetBackgroundMusic(source);
                    break;
                case JCS_SoundSettingType.SFX_SOUND:
                    AssignSFX_Sound(source);
                    break;
                case JCS_SoundSettingType.SKILLS_SOUND:
                    AssignSkillsSound(source);
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="volume"></param>
        public void SetSoundVolume(JCS_SoundSettingType type, float volume)
        {
            switch (type)
            {
                case JCS_SoundSettingType.NONE:
                    return;
                case JCS_SoundSettingType.BGM_SOUND:
                    GetBackgroundMusic().volume = volume;
                    break;
                case JCS_SoundSettingType.SFX_SOUND:
                    SetSFXSoundVolume(volume);
                    break;
                case JCS_SoundSettingType.SKILLS_SOUND:
                    SetSkillsSoundVolume(volume);
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="act"></param>
        public void SetSoundMute(JCS_SoundSettingType type, bool act)
        {
            switch (type)
            {
                case JCS_SoundSettingType.NONE:
                    return;
                case JCS_SoundSettingType.BGM_SOUND:
                    GetBackgroundMusic().mute = act;
                    break;
                case JCS_SoundSettingType.SFX_SOUND:
                    SetSFXSoundMute(act);
                    break;
                case JCS_SoundSettingType.SKILLS_SOUND:
                    SetSkillsSoundMute(act);
                    break;
            }
        }

        //----------------------
        // Protected Functions

        //----------------------
        // Private Functions

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="vol"></param>
        private void SetSoundVolume(JCS_Vector<AudioSource> list, float vol)
        {
            for (int index = 0;
                index < list.length;
                ++index)
            {
                list.at(index).volume = vol;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="act"></param>
        private void SetSoundtMute(JCS_Vector<AudioSource> list, bool act)
        {
            for (int index = 0;
                index < list.length;
                ++index)
            {
                list.at(index).mute = act;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sound"></param>
        private void AssignSFX_Sound(AudioSource sound)
        {
            AssignSoundToList(mSFXSounds, sound);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sound"></param>
        private void AssignSkillsSound(AudioSource sound)
        {
            AssignSoundToList(mSkillsSounds, sound);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="sound"></param>
        private void AssignSoundToList(JCS_Vector<AudioSource> list, AudioSource sound)
        {
            if (sound == null)
            {
                JCS_Debug.JcsErrors("JCS_SoundManager",   "Assigning Source that is null...");
                return;
            }

            list.push(sound);
            sound.volume = JCS_GameSettings.GetSFXSound_Volume();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vol"></param>
        private void SetSFXSoundVolume(float vol)
        {
            SetSoundVolume(mSFXSounds, vol);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vol"></param>
        private void SetSkillsSoundVolume(float vol)
        {
            SetSoundVolume(mSkillsSounds, vol);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="act"></param>
        private void SetSFXSoundMute(bool act)
        {
            SetSoundtMute(mSFXSounds, act);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="act"></param>
        private void SetSkillsSoundMute(bool act)
        {
            SetSoundtMute(mSkillsSounds, act);
        }

    }
}
