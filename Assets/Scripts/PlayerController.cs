using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //�v���C���[���������x
    [SerializeField] float speed = 2f;
    public float turnMove = 1.0f;
    //�O�l�̃J�����F�v���C���[�̃J����
    public Camera playerCamera = null;
    //�O�l�̃J�����F�v���C���[�I�u�W�F�N�g�ւ̎Q��
    public GameObject player = null;

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
