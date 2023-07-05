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
    [SerializeField] Transform UIpos;
    GameObject Origin;
    public ObjectManager ObjectManager;
    public new AudioClip audio;

    private void Start()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Cancopy"))
        {
            Name = other.gameObject.name;
            if (Name != inName && count == 0)
            {
                for (int i = 0; i < ObjectManager._CanCopyObj.Length; i++)
                {
                    if (ObjectManager._CanCopyObj[i].name == Name)
                    {
                        Obj = ObjectManager._CanCopyObj[i].Object;
                        Obj.name = ObjectManager._CanCopyObj[i].Object.name;
                        ObjectManager._CanCopyObj[i].Copied = true;
                        //Debug.Log(ObjectManager._CanCopyObj[i].Copied);
                        ForUIObj = Instantiate(ObjectManager._CanCopyObj[i].Object);
                        audio = ObjectManager._CanCopyObj[i].Audio;
                        inName = Name;
                        count = 1;
                        break;
                    }
                }
            }
        }
    }
}