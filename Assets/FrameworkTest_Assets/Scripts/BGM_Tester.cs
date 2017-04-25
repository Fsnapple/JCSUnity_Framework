using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JCSUnity;


public class BGM_Tester
    : MonoBehaviour
{
    public AudioClip mBGM_01 = null;
    public AudioClip mBGM_02 = null;

    private void Update()
    {
        if (JCS_Input.GetKeyDown(KeyCode.A))
            JCS_SoundManager.instance.SwitchBackgroundMusic(mBGM_01, 0.5f, 0.5f);
        if (JCS_Input.GetKeyDown(KeyCode.S))
            JCS_SoundManager.instance.SwitchBackgroundMusic(mBGM_02, 0.5f, 0.5f);
    }

}
