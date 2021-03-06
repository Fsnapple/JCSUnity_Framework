﻿/**
 * $File: JCS_BlackScreen.cs $
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
    /// Black screen gameobject for JCSUnity usage.
    /// </summary>
    [RequireComponent(typeof(JCS_FadeObject))]
    public class JCS_BlackScreen 
        : MonoBehaviour
    {

        //----------------------
        // Public Variables

        //----------------------
        // Private Variables
        private JCS_FadeObject mFadeObject = null;

        //----------------------
        // Protected Variables

        //========================================
        //      setter / getter
        //------------------------------
        public Color LocalColor
        {
            get { return this.mFadeObject.LocalColor; }
            set
            {
                this.mFadeObject.LocalColor = value;
            }
        }

        //========================================
        //      Unity's function
        //------------------------------
        private void Awake()
        {
            this.mFadeObject = this.GetComponent<JCS_FadeObject>();
        }

        private void Start()
        {
            // everytime it reload the scene.
            // move to the last child make sure everything get cover by this.
            JCS_Utility.MoveToTheLastChild(this.transform);
        }

        //========================================
        //      Self-Define
        //------------------------------
        //----------------------
        // Public Functions

        /// <summary>
        /// 
        /// </summary>
        /// <param name="time"></param>
        public void FadeIn(float time)
        {
            mFadeObject.FadeIn(time);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="time"></param>
        public void FadeOut(float time)
        {
            mFadeObject.FadeOut(time);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsFadeIn()
        {
            return mFadeObject.IsFadeIn();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsFadeOut()
        {
            return mFadeObject.IsFadeOut();
        }

        /// <summary>
        /// Move the panel to front
        /// </summary>
        public void MoveToTheLastChild()
        {
            Transform parent = this.transform.parent;

            Vector3 recordPos = this.transform.localPosition;
            Vector3 recordScale = this.transform.localScale;
            Quaternion recordRot = this.transform.localRotation;

            // this part will mess up the transform
            // so we record all we need and set it back
            {
                this.transform.SetParent(null);
                this.transform.SetParent(parent);
            }

            // here we set it back!
            this.transform.localPosition = recordPos;
            this.transform.localScale = recordScale;
            this.transform.localRotation = recordRot;
        }

        //----------------------
        // Protected Functions

        //----------------------
        // Private Functions

    }
}
