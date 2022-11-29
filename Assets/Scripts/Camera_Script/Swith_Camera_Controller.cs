using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Swith_Camera_Controller : MonoBehaviour
{
    [SerializeField]CinemachineVirtualCamera firstCamera;

    private int defaultPriority;

    // Start is called before the first frame update
    void Start()
    {
        defaultPriority = firstCamera.Priority;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject)
        {
            firstCamera.Priority = 50;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject)
        {
            firstCamera.Priority = defaultPriority;
        }
    }
}
