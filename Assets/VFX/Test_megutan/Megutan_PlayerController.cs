using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Megutan_PlayerController : MonoBehaviour
{
    //�v���C���[���������x
    [SerializeField] float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        //�v���C���[�𓮂���
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.position += move * speed * Time.deltaTime;
    }
}