using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    //プレイヤーが動く速度
    [SerializeField] float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        //プレイヤーを動かす
        Vector3 move = new Vector3(Input.GetAxis("MoveX"), 0, Input.GetAxis("MoveY"));
        transform.position += move * speed * Time.deltaTime;

        ////Debug.Log(move);
        //if(Input.GetAxis("Horizontal") >= 1)
        //{
        //    Debug.Log("aaaaa");
        //}

        //Vector3 move = new Vector3(Input.GetAxis("LstickHorizontal"), 0, Input.GetAxis("LstickVertical"));
        //transform.position += move * speed * Time.deltaTime;
    }
}