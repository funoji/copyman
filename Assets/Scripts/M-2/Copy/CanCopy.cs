using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CopyManager : MonoBehaviour
{
    [SerializeField]
    [Header("このステージのコピーできるobjectの数")]
        

    public CanCopyObj canCopyObj;
}

[System.Serializable]
public class CanCopyObj
{
    public string name;
    [Header("object名")]

    [Header("番号")]
    public int NumberOfObj;

    [Header("object本体")]

    //this object got copied
    public static bool Copied = false;
}