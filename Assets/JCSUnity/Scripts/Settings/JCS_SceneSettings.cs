/**
 * $File: JCS_SceneSettings.cs $
 * $Date: 2016-10-28 13:59:35 $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information 
 *	                 Copyright (c) 2016 by Shen, Jen-Chieh $
 */
using UnityEngine;
using System.Collections;
using System;


namespace JCSUnity
{

    /// <summary>
    /// 
    /// </summary>
    public class JCS_SceneSettings
        : JCS_Settings<JCS_SceneSettings>
    {

        //----------------------
        // Public Variables

        //----------------------
        // Private Variables

        [Header("** Runtime Variables (JCS_SceneSettings) **")]

        [Tooltip("General Scene fadout time. (For all scene.)")]
        public float SCENE_FADEOUT_TIME = 1.5f;

        [Tooltip("General Scene fadein time. (For all scene.)")]
        public float SCENE_FADEIN_TIME = 1.5f;

        //----------------------
        // Protected Variables

        //========================================
        //      setter / getter
        //------------------------------

        //========================================
        //      Unity's function
        //------------------------------
        private void Awake()
        {
            instance = CheckSingleton(instance, this);
        }

        //========================================
        //      Self-Define
        //------------------------------
        //----------------------
        // Public Functions

        /// <summary>
        /// Get the real scene fade out time base on
        /// the scene manager override setting?
        /// </summary>
        /// <returns> time to fade out the scene </returns>
        public float GetSceneFadeOutTimeBaseOnSetting()
        {
            JCS_SceneManager jcsSm = JCS_SceneManager.instance;

            // check if override the setting.
            if (jcsSm.OverrideSetting)
            {
                // return the override value.
                return jcsSm.SceneFadeOutTime;
            }

            // if not override, 
            // return the basic value.
            return SCENE_FADEOUT_TIME;
        }

        /// <summary>
        /// Get the real scene fade in time base on
        /// the scene manager override setting?
        /// </summary>
        /// <returns> time to fade in the scene </returns>
        public float GetSceneFadeInTimeBaseOnSetting()
        {
            JCS_SceneManager jcsSm = JCS_SceneManager.instance;

            // check if override the setting.
            if (jcsSm.OverrideSetting)
            {
                // return the override value.
                return jcsSm.SceneFadeInTime;
            }

            // if not override, 
            // return the basic value.
            return SCENE_FADEIN_TIME;
        }

        //----------------------
        // Protected Functions

        /// <summary>
        /// Instead of Unity Engine's scripting layer's DontDestroyOnLoad.
        /// I would like to use own define to transfer the old instance
        /// to the newer instance.
        /// 
        /// Every time when unity load the scene. The script have been
        /// reset, in order not to lose the original setting.
        /// transfer the data from old instance to new instance.
        /// </summary>
        /// <param name="_old"> old instance </param>
        /// <param name="_new"> new instance </param>
        protected override void TransferData(JCS_SceneSettings _old, JCS_SceneSettings _new)
        {
            _new.SCENE_FADEIN_TIME = _old.SCENE_FADEIN_TIME;
            _new.SCENE_FADEOUT_TIME = _old.SCENE_FADEOUT_TIME;
        }

        //----------------------
        // Private Functions

    }
}
