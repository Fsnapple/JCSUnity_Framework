﻿/**
 * $File: JCS_SpriteRendererAction.cs $
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
    /// This will auto find the facing with correct direction.
    /// 
    /// In addition, u can use it inversely!
    /// </summary>
    [RequireComponent(typeof(SpriteRenderer))]
    public class JCS_SpriteRendererAction
        : MonoBehaviour
    {

        //----------------------
        // Public Variables

        //----------------------
        // Private Variables

        private SpriteRenderer mSpriteRenderer = null;
        private Vector3 mLastPosition = Vector3.zero;

        [Header("-- X Facing --")]

        [Tooltip("Enable/Disabel the effect in X axis")]
        [SerializeField]
        private bool mFreezeX = false;

        [Tooltip("Effect Only when Direction is Horizontal")]
        [SerializeField]
        private bool mIsFacingRight = true;


        [Header("-- Y Facing --")]
        [Tooltip("Enable/Disabel the effect in Y axis")]
        [SerializeField]
        private bool mFreezeY = false;

        [Tooltip("Effect Only when Direction is Vertical")]
        [SerializeField]
        private bool mIsFacingUp = true;

        //----------------------
        // Protected Variables

        //========================================
        //      setter / getter
        //------------------------------
        public bool IsFacingUp { get { return this.mIsFacingUp; } }
        public bool IsFacingRight { get { return this.mIsFacingRight; } }

        //========================================
        //      Unity's function
        //------------------------------
        private void Awake()
        {
            this.mSpriteRenderer = this.GetComponent<SpriteRenderer>();
        }

        private void LateUpdate()
        {
            Vector3 currentPos = this.transform.position;

            // if the position are the same, meaning the object
            // is idle. (have not been move)
            if (currentPos == mLastPosition)
                return;

            if (!mFreezeX)
            {
                // object going left
                if (currentPos.x < mLastPosition.x)
                {
                    if (mIsFacingRight)
                        mSpriteRenderer.flipX = false;
                    else
                        mSpriteRenderer.flipX = true;
                }
                // object going right
                else if (currentPos.x > mLastPosition.x)
                {
                    if (mIsFacingRight)
                        mSpriteRenderer.flipX = true;
                    else
                        mSpriteRenderer.flipX = false;
                }

                if (JCS_Utility.WithInRange(90, 270, this.transform.localEulerAngles.z))
                    mSpriteRenderer.flipX = !mSpriteRenderer.flipX;
            }

            if (!mFreezeY)
            {
                // object going down
                if (currentPos.y < mLastPosition.y)
                {
                    if (mIsFacingUp)
                        mSpriteRenderer.flipY = false;
                    else
                        mSpriteRenderer.flipY = true;
                }
                // object going up
                else if (currentPos.y > mLastPosition.y)
                {
                    if (mIsFacingUp)
                        mSpriteRenderer.flipY = true;
                    else
                        mSpriteRenderer.flipY = false;
                }

                // TODO(JenChieh): this have not test yet!!!
                if (JCS_Utility.WithInRange(90, 270, this.transform.localEulerAngles.z))
                    mSpriteRenderer.flipY = !mSpriteRenderer.flipY;
            }
            

            // update last position
            mLastPosition = currentPos;
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
