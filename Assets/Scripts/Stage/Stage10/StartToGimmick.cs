using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartToGimmick : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] OpenGimmick gimmick;

    private void OnTriggerEnter(Collider other)
    {
        gimmick.ActiveGimmick = true;
    }

}
