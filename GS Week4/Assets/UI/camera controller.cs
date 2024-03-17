using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    public Camera[] cameras;
    private int currentCameraIndex;

    void Start()
    {
        // ��ʼ��ʱ�����˵�һ������⣬���������������
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

    public void SwitchCamera()
    {
        currentCameraIndex++;
        if (currentCameraIndex >= cameras.Length)
        {
            currentCameraIndex = 0;
        }
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(i == currentCameraIndex);
        }
    }
}
