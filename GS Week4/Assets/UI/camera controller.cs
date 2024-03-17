using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    public Camera[] cameras;
    public Canvas[] canvases; // 确保Canvas数组与Camera数组匹配
    private int currentCameraIndex;

    void Start()
    {
        Time.timeScale = 0.0f;
        foreach (Camera cam in cameras)
        {
            cam.gameObject.SetActive(false);
        }
        foreach (Canvas canvas in canvases)
        {
            canvas.gameObject.SetActive(false);
        }
        if (cameras.Length > 0)
        {
            ActivateCamera(0); // 使用ActivateCamera来初始化，确保一致性
        }
    }


    public void SwitchToSecondCamera()
    {
        if (cameras.Length >= 3)
        {
            ActivateCamera(1);
            Time.timeScale = 1.0f;
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
            canvases[i].gameObject.SetActive(i == index); // 同时激活对应的Canvas
        }
        currentCameraIndex = index;

        // 如果你想要在切换到第一个相机时暂停游戏，在这里设置
        Time.timeScale = (index == 0) ? 0.0f : 1.0f;
    }
}