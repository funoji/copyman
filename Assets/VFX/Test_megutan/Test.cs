using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private Rigidbody rb;�@�@�@�@//Rigidbody�ǂݍ��ݗp�ϐ�
    public float JumpPower = 200f;�@�@//�W�����v�����(������ւ̗�)
    public int JumpLimit = 1;    //�W�����v�ł����
    private int jumpCount = 0;   //���������p
    private bool IsGround = true;�@//�ڒn�t���O�p

    void Start()
    {
        rb = GetComponent<Rigidbody>();   //Rigidbody�擾  
    }

    void Update()
    {
        //���n����܂ŃW�����v�񐔂͌��ɖ߂�Ȃ���[���Ă�������
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (IsGround)
            jumpCount = 0;
    }

    public void Jump()
    {
        if (jumpCount < JumpLimit)�@�@//Limit�̕������W�����v�ł���
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(new Vector3(0, JumpPower, 0)); //�W�����v�̕���
            IsGround = false;�@//�W�����v������[���Ă����t���O

            jumpCount++;
        }
    }
    private void OnCollisionEnter(Collision coll)
    {
        //�n�ʂɒ��n���Ă��邩�ǂ����̔���
        //���������ɂ������ăX�e�[�W�̃^�O���hStageGround�h�ɕύX���܂����B
        if (coll.gameObject.tag == "StageGround")
        {
            IsGround = true;
        }
    }
}