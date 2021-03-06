﻿/**
 * $File: JCS_PanelRoot.cs $
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
    /// Panel will make sure all the following
    /// child object fit the screen size!
    /// </summary>
    public class JCS_PanelRoot
        : JCS_BaseDialogueObject
    {

        //----------------------
        // Public Variables

        //----------------------
        // Private Variables

        private float mPanelDeltaWidthRatio = 0;
        private float mPanelDeltaHeightRatio = 0;


        [Header("** Initialize Variables (JCS_PanelRoot) **")]

        [Tooltip("Fit the whole screen size?")]
        [SerializeField]
        private bool mFitScreenSize = true;

        //----------------------
        // Protected Variables

        //========================================
        //      setter / getter
        //------------------------------
        public bool FitScreenSize { get { return this.mFitScreenSize; } set { this.mFitScreenSize = value; } }
        public float PanelDeltaWidthRatio { get { return this.mPanelDeltaWidthRatio; } }
        public float PanelDeltaHeightRatio { get { return this.mPanelDeltaHeightRatio; } }

        //========================================
        //      Unity's function
        //------------------------------
        protected override void Awake()
        {
            base.Awake();

            // NOTE(jenhiche): not sure is this the 
            // correct position for the code or not.
            if (mFitScreenSize)
            {
                FitPerfectSize();

                AddPanelChild();
            }
        }

        protected override void Start()
        {
            base.Start();
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
        
        /// <summary>
        /// Fit screen size base on Unity Engine 
        /// architecture.
        /// </summary>
        private void FitPerfectSize()
        {
            // get app rect
            RectTransform appRect = JCS_Canvas.instance.GetAppRect();

            float newWidth = appRect.sizeDelta.x;
            float newHeight = appRect.sizeDelta.y;

            float currentWidth = mRectTransform.sizeDelta.x;
            float currentHeight = mRectTransform.sizeDelta.y;

            mPanelDeltaWidthRatio = currentWidth / newWidth;
            mPanelDeltaHeightRatio = currentHeight / newHeight;

            Vector3 newPosition = mRectTransform.localPosition;

            if (JCS_Camera.main != null)
            {
                // make toward to the camera position
                Camera cam = JCS_Camera.main.GetCamera();

                if (cam != null)
                {
                    // Find the distance between the dialogue object and 
                    // the center (which is camera in this case)
                    float distanceX = mRectTransform.localPosition.x - cam.transform.localPosition.x;
                    float distanceY = mRectTransform.localPosition.y - cam.transform.localPosition.y;

                    newPosition.x = (distanceX / mPanelDeltaWidthRatio);
                    newPosition.y = (distanceY / mPanelDeltaHeightRatio);
                }
            }

            /*
             * NOTE(jenchieh): 
             * Cool, `sizeDelta' will actually change the `localPosition'
             * now since version 2017.4.
             * 
             * So we set the `sizeDelta' (width and height) first, then
             * set the `localPosition'.
             */
            {
                // set the width and height from app rect
                mRectTransform.sizeDelta = appRect.sizeDelta;

                // set to the new position
                mRectTransform.localPosition = newPosition;
            }
        }

        /// <summary>
        /// Add the panel child to all panel child.
        /// </summary>
        private void AddPanelChild()
        {
            Transform tempTrans = this.transform;

            // loop through the child object and 
            // add on to it.
            for (int index = 0;
                index < transform.childCount;
                ++index)
            {
                Transform child = tempTrans.GetChild(index);

                child.gameObject.AddComponent<JCS_PanelChild>();
            }
        }

    }
}
