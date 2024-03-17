using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    public Camera[] cameras;
    public Canvas[] canvases; // ȷ��Canvas������Camera����ƥ��
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
            ActivateCamera(0); // ʹ��ActivateCamera����ʼ����ȷ��һ����
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
            canvases[i].gameObject.SetActive(i == index); // ͬʱ�����Ӧ��Canvas
        }
        currentCameraIndex = index;

        // �������Ҫ���л�����һ�����ʱ��ͣ��Ϸ������������
        Time.timeScale = (index == 0) ? 0.0f : 1.0f;
    }
}