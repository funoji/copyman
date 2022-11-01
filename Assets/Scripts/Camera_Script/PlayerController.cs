using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //プレイヤーが動く速度
    [SerializeField] float speed = 2f;
    Vector3 forword = new Vector3(0, 0, 20);
    Vector3 back = new Vector3(0, 0, -20);
    Vector3 Left = new Vector3(0, -1, 0);
    Rigidbody rb;
    [SerializeField] GameObject PlayerTrans;
    [SerializeField] float rotspeed;
    [SerializeField] float movespeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        //プレイヤーを動かす
        //Vector3 move = new Vector3(Input.GetAxis("MoveX"), 0, Input.GetAxis("MoveY"));
        //transform.position += move * speed * Time.deltaTime;
        if(Input.GetKey(KeyCode.W))
        {
            PlayerTrans.transform.Translate(new Vector3(0, 0, movespeed) * Time.deltaTime);
            Debug.Log("Wがおされた");
        }

        if(Input.GetKey(KeyCode.S))
        {
            PlayerTrans.transform.Translate(new Vector3(0, 0, -movespeed) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            PlayerTrans.transform.Rotate(new Vector3(0, -rotspeed, 0) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            PlayerTrans.transform.Rotate(new Vector3(0, rotspeed, 0) * Time.deltaTime);
        }

        ////Debug.Log(move);
        //if(Input.GetAxis("Horizontal") >= 1)
        //{
        //    Debug.Log("aaaaa");
        //}

        //Vector3 move = new Vector3(Input.GetAxis("LstickHorizontal"), 0, Input.GetAxis("LstickVertical"));
        //transform.position += move * speed * Time.deltaTime;
    }
}