using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Megutan_CopyColl : MonoBehaviour
{
    string Name;
    [HideInInspector] public static GameObject Obj;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Cancopy"))
        {
            Debug.Log("“–‚½‚Á‚½");
            Name = other.gameObject.name;
            Debug.Log(Name);
            Obj = GameObject.Find(Name);
        }
    }
}