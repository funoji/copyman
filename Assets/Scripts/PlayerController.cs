using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //プレイヤーが動く速度
    [SerializeField] float speed = 2f;
    public float turnMove = 1.0f;
    //三人称カメラ：プレイヤーのカメラ
    public Camera playerCamera = null;
    //三人称カメラ：プレイヤーオブジェクトへの参照
    public GameObject player = null;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

        //プレイヤーを動かす
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        transform.position += move * speed * Time.deltaTime;



    }
}
