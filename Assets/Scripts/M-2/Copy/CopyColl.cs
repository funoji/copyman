using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyColl : MonoBehaviour
{

    string Name;
    string inName;
    public static int count = 0;
    public GameObject ForUIObj;
    public GameObject Obj;
    GameObject Origin;
    public ObjectManager ObjectManager;

    private void Start()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Cancopy"))
        {
            //Debug.Log("“–‚½‚Á‚½");
            Name = other.gameObject.name;
            //Debug.Log(Name);

            if (Name != inName && count == 0)
            {
                for (int i = 0; i < ObjectManager._CanCopyObj.Length; i++)
                {
                    if (ObjectManager._CanCopyObj[i].name == Name)
                    {
                        Obj = ObjectManager._CanCopyObj[i].Object;
                        ObjectManager._CanCopyObj[i].Copied = true;
                        ForUIObj = GameObject.Instantiate(GameObject.Find(Name));
                        inName = Name;
                        count = 1;
                        Debug.Log(Obj.name);
                        break;
                    }
                }
            }
        }
    }
}