using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    bool OnSound;
    [System.Serializable]
    public class CanCopyObj
    { 
        [Header("object–{‘Ì")]
        public GameObject Object;

        [HideInInspector]
        public string name;

        [HideInInspector]
        public int NumberOfObj;

        [SerializeField]
        public Quaternion Rotate;

        [SerializeField]
        public Vector3 Scale;

        [SerializeField]
        public Vector3 Position;
        //this object got copied
        public bool Copied = false;

        //suond
        [SerializeField]
        public AudioClip Audio;
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