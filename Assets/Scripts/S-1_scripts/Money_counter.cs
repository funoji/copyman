using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money_counter : MonoBehaviour
{
    [HeaderAttribute("カウントしたいオブジェクトの数")]
    [SerializeField] int objects;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] cubeObjects = GameObject.FindGameObjectsWithTag("Cancopy");
        //Debug.Log(cubeObjects.Length);
        if(cubeObjects.Length >= objects)
        {
            GameDirector.GameClear = true;
        }
    }
}
