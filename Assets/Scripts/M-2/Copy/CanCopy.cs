using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CopyManager : MonoBehaviour
{
    [SerializeField]
    [Header("���̃X�e�[�W�̃R�s�[�ł���object�̐�")]
        

    public CanCopyObj canCopyObj;
}

[System.Serializable]
public class CanCopyObj
{
    public string name;
    [Header("object��")]

    [Header("�ԍ�")]
    public int NumberOfObj;

    [Header("object�{��")]

    //this object got copied
    public static bool Copied = false;
}