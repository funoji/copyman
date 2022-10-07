using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Megutan_PlayerController : MonoBehaviour
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
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.position += move * speed * Time.deltaTime;
    }
}