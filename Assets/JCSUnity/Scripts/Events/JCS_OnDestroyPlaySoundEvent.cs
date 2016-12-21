﻿/**
 * $File: JCS_OnDestroyPlaySoundEvent.cs $
 * $Date: $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information 
 *                   Copyright (c) 2016 by Shen, Jen-Chieh $
 */
using UnityEngine;
using System.Collections;


namespace JCSUnity
{

    /// <summary>
    /// 
    /// </summary>
    [RequireComponent(typeof(JCS_SoundPlayer))]
    public class JCS_OnDestroyPlaySoundEvent
        : MonoBehaviour
    {

        //----------------------
        // Public Variables

        //----------------------
        // Private Variables
        private JCS_SoundPlayer mSoundPlayer = null;
        [SerializeField]
        private AudioClip mAudioClip = null;
        private JCS_SoundSettingType mSoundSettingType = JCS_SoundSettingType.NONE;

        //----------------------
        // Protected Variables

        //========================================
        //      setter / getter
        //------------------------------
        public void SetSoundSettingType(JCS_SoundSettingType type) { mSoundSettingType = type; }
        public void SetAudioClip(AudioClip ac) { this.mAudioClip = ac; }
        public JCS_SoundPlayer GetJCSSoundPlayer() { return this.mSoundPlayer; }

        //========================================
        //      Unity's function
        //------------------------------
        private void Awake()
        {
            mSoundPlayer = this.GetComponent<JCS_SoundPlayer>();
        }

        /// <summary>
        /// when is destroy play the sound.
        /// </summary>
        private void OnDestroy()
        {
            // if is quitting the application don't spawn object,
            // or else will cause memory leak!
            if (JCS_ApplicationManager.APP_QUITTING)
                return;

            // if switching the scene, don't spawn new gameObject.
            if (JCS_SceneManager.instance.IsSwitchingScene())
                return;

            // create object to do the event
            GameObject obj = new GameObject();

            // this object will play the sound, after the sound is played.
            // will destroy it self automatically.
            JCS_DestroySoundEndEvent dsee = obj.AddComponent<JCS_DestroySoundEndEvent>();

#if (UNITY_EDITOR)
            obj.name = "JCS_OnDestroyPlaySoundEvent";
#endif
            dsee.SetAudioClipAndPlayOneShot(mAudioClip, mSoundSettingType);
            
        }

        //========================================
        //      Self-Define
        //------------------------------
        //----------------------
        // Public Functions

        //----------------------
        // Protected Functions

        //----------------------
        // Private Functions

    }
}
