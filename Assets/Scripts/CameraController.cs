using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private CinemachineVirtualCamera playerCam;
    [SerializeField] private CinemachineVirtualCamera baseCam;

    public void EnablePlayerCam()
    {
        baseCam.enabled = false;
        playerCam.enabled = true;
    }
    public void EnableBaseCam()
    {
        baseCam.enabled = true;
        playerCam.enabled = false;
    }
}
