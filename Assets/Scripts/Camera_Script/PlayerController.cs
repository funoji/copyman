using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //移動の変数
    [SerializeField] [Tooltip("プレイヤーの移動スピード")] private float move_speed = 10f;
    [SerializeField] [Tooltip("プレイヤーの重力")] private Rigidbody rb;
    [SerializeField] [Tooltip("プレイヤーの移動方向")] private Vector3 direction;
    [SerializeField] [Tooltip("カメラの水平方向")] private CameraController refCamera_H;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        direction = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
            direction.z += 1f;
        if(Input.GetKey(KeyCode.S))
            direction.z -= 1f;
        if (Input.GetKey(KeyCode.D))
            direction.x += 1f;
        if (Input.GetKey(KeyCode.A))
            direction.x -= 1f;
        direction = direction.normalized * move_speed * Time.deltaTime;

        if (direction.magnitude > 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(refCamera_H.rotateH * direction), 10.0f);
            transform.position += refCamera_H.rotateH * direction;
        }
    }
}