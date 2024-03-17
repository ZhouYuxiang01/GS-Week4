using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    public Camera[] cameras;
    private int currentCameraIndex;

    void Start()
    {
        foreach (Camera cam in cameras)
        {
            cam.gameObject.SetActive(false);
        }
        if (cameras.Length > 0)
        {
            cameras[0].gameObject.SetActive(true);
            currentCameraIndex = 0;
        }
    }

    public void SwitchToSecondCamera()
    {
        if (cameras.Length >= 3)
        {
            ActivateCamera(1);
        }
    }

    public void SwitchToThirdCamera()
    {
        if (cameras.Length >= 3)
        {
            ActivateCamera(2);
        }
    }

    public void SwitchToFourthCamera()
    {
        if (cameras.Length >= 4)
        {
            ActivateCamera(3);
        }
    }

    private void ActivateCamera(int index)
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(i == index);
        }
        currentCameraIndex = index;
    }
}