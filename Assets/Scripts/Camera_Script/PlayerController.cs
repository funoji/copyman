using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //プレイヤーが動く速度
    [SerializeField] float speed = 2f;
    private float applySpeed = 0.2f;
    [SerializeField] private CameraController refCamera;
    private Rigidbody rb;
    private float inputVertical;
    private float inputHorizontal;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {

        //プレイヤーを動かす
        Vector3 move = new Vector3(Input.GetAxis("MoveY"), 0, Input.GetAxis("MoveX"));
        transform.position += move * speed * Time.deltaTime;

        if (move.magnitude>0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                                      Quaternion.LookRotation(refCamera.Hrotation*move),
                                                      applySpeed);

            transform.position += refCamera.Hrotation * move;
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