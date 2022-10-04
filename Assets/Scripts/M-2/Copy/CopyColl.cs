using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyColl : MonoBehaviour
{

    string Name;
    string inName;
    public static int count = 0;
    [HideInInspector] public static GameObject Obj;
    GameObject Origin;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Cancopy"))
        {
            Debug.Log("“–‚½‚Á‚½");
            Name = other.gameObject.name;
            Debug.Log(Name);
            if (Name != inName && count == 0)
            {

                Obj = GameObject.Instantiate(GameObject.Find(Name));

                inName = Name;
                count = 1;
            }

        }
    }
}