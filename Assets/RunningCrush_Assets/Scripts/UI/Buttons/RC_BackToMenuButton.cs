﻿/**
 * $File: RC_BackToMenuButton.cs $
 * $Date: $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information 
 *                   Copyright (c) 2016 by Shen, Jen-Chieh $
 */
using UnityEngine;
using System.Collections;
using JCSUnity;
using System;

public class RC_BackToMenuButton
    : JCS_Button
{
    private JCS_2DSlideScreenCamera mSlideCamera = null;

    protected override void Awake()
    {
        base.Awake();

        // lazy code
        mSlideCamera = GameObject.Find("JCS_2DSlideScreenCamera").GetComponent<JCS_2DSlideScreenCamera>();
    }

    public override void JCS_OnClickCallback()
    {
        if (mSlideCamera == null)
        {
            JCS_Debug.LogError(
                "No JCS_2DSlideScreenCamera in the scene...");
            return;
        }

        mSlideCamera.SwitchScene(JCS_2D4Direction.BOTTOM);
    }
}
