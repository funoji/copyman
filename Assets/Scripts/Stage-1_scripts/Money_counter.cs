using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money_counter : MonoBehaviour
{
    [HeaderAttribute("カウントしたいオブジェクトの数")]
    [SerializeField] public int objects;
    [HideInInspector] public int metaobject = 0;
    // Update is called once per frame
    void Update()
    {
        if(metaobject - 22 >= objects)
        {
            GameDirector.GameClear = true;
        }
    }
}
