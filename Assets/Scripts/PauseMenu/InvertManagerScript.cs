using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class InvertManagerScript : MonoBehaviour
{
    public static bool HoriInvert = false;
    public static bool VertInvert = false;

    CinemachineVirtualCamera cinemaCamera;
    private void Start()
    {
        cinemaCamera = GameObject.Find("CameraSystem").GetComponent<CinemachineVirtualCamera>();
    }

    public void HoriInvertIsCheck()
    {
        HoriInvert = !HoriInvert;
        cinemaCamera.GetCinemachineComponent(CinemachineCore.Stage.Aim).GetComponent<CinemachinePOV>().m_HorizontalAxis.m_InvertInput =
            !cinemaCamera.GetCinemachineComponent(CinemachineCore.Stage.Aim).GetComponent<CinemachinePOV>().m_HorizontalAxis.m_InvertInput;
    }
    public void VertInvertIsCheck()
    {
        VertInvert = !VertInvert;
        cinemaCamera.GetCinemachineComponent(CinemachineCore.Stage.Aim).GetComponent<CinemachinePOV>().m_VerticalAxis.m_InvertInput =
            !cinemaCamera.GetCinemachineComponent(CinemachineCore.Stage.Aim).GetComponent<CinemachinePOV>().m_VerticalAxis.m_InvertInput;
    }
}
