using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    [System.Serializable]
    public class CanCopyObj
    { 
        [Header("object–{‘Ì")]
        public GameObject Object;

        [HideInInspector]
        public string name;

        [HideInInspector]
        public int NumberOfObj;

        //this object got copied
        [HideInInspector]
        public bool Copied = false;
    }

    [SerializeField] public CanCopyObj[] _CanCopyObj;

    void Start()
    {

        for (int i = 0; i < _CanCopyObj.Length; i++)
        {
            _CanCopyObj[i].name = _CanCopyObj[i].Object.name;
            _CanCopyObj[i].NumberOfObj = i;
        }

    }
}