using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartToGimmick : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] OpenGimmick gimmick;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cancopy")) 
            gimmick.ActiveGimmick = true;
        if(other.gameObject.name=="CPM")
            gimmick.ActiveGimmick = true; 
    }

}
