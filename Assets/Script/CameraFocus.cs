using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class CameraFocus : MonoBehaviour
{
    private bool mVuforiaStarted = false;
    private bool mFlashEnabled = false;

    //public Text Mensaje_Error;

    void Start()
    {
        VuforiaARController vuforia = VuforiaARController.Instance;

        if (vuforia != null)
        {
            vuforia.RegisterVuforiaStartedCallback(ComenzarDesVuforia);
        }
    }

    private void ComenzarDesVuforia()
    {
        mVuforiaStarted = true;
        Poner_Focus();
    }

    private void OnApplicationPause(bool pause)
    {
        if (!pause)
        {
            if (mVuforiaStarted)
            {
                Poner_Focus();
            }
        }
    }

    private void Poner_Focus()
    {
        if (CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO))
        {
            //Mensaje_Error.text = "Autofocus";
        }
        else
        {
            //Mensaje_Error.text = "No soporta Autofocus";
        }
    }
}
