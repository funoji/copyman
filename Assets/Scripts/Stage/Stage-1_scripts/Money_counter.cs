using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money_counter : MonoBehaviour
{
    [HeaderAttribute("�J�E���g�������I�u�W�F�N�g�̐�")]
    [SerializeField] int objects;
    [HideInInspector] public int metaobject;
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(cubeObjects.Length);
        if(metaobject >= objects)
        {
            GameDirector.GameClear = true;
        }
    }
}
