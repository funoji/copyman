using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Sample : MonoBehaviour
{
    public CanCopyObj animal;
}

[System.Serializable]
public class CanCopyObj
{
    public string name;
    [Header("object��")]

    [Header("�ԍ�")]
    public int NumberOfObj;
}