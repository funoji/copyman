using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpManager : MonoBehaviour
{
    [SerializeField] Transform player;
    private Rigidbody rb;�@�@�@�@//Rigidbody�ǂݍ��ݗp�ϐ�
    public float JumpPower = 200f;�@�@//�W�����v�����(������ւ̗�)
    public int JumpLimit = 1;    //�W�����v�ł����
    //private int jumpCount = 0;   //���������p
    private bool IsGround = true;�@//�ڒn�t���O�p
    //private bool IsJumping = false; //�ǃW�����֎~�p�@�ǃW����OK�ɂ���ꍇ�́��`���̊Ԃ��A���R�����g���Ă�������
    private float distance = 1.0f;
    Vector3 RayPosition;

    void Start()
    {
        rb= GetComponent<Rigidbody>();   //Rigidbody�擾  
    }

    void Update()
    {
        ////���n����܂ŃW�����v�񐔂͌��ɖ߂�Ȃ���[���Ă�������
        //if (IsGround)
        //    jumpCount=0;

        RayPosition= transform.position + new Vector3(player.position.x, player.position.y-3.5f, player.position.z);
        Ray ray = new Ray(RayPosition, Vector3.down);
        Debug.DrawRay(RayPosition, Vector3.down*distance, Color.red);

        IsGround = Physics.Raycast(ray, distance);
        Debug.Log(IsGround);
    }

    public void Jump()
    {
        if (IsGround) //�W�����v���Ă��Ȃ����
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(new Vector3(0, JumpPower, 0)); //�W�����v�̕���
/*            IsJumping=true;*/�@//�W�����v������[���Ă����t���O
        }
    }

    //��
    //public void Jump()
    //{
    //    if (jumpCount<JumpLimit)�@�@//Limit�̕������W�����v�ł���
    //    {
    //        rb.velocity = Vector3.zero;
    //        rb.AddForce(new Vector3(0, JumpPower, 0)); //�W�����v�̕���
    //        IsGround=false;�@//�W�����v������[���Ă����t���O

    //        jumpCount++;
    //    }
    //}
    //private void OnCollisionEnter(Collision coll)
    //{
    //    //�n�ʂɒ��n���Ă��邩�ǂ����̔���
    //    //���������ɂ������ăX�e�[�W�̃^�O���hStageGround�h�ɕύX���܂����B
    //    if (coll.gameObject.tag=="StageGround"||
    //        coll.gameObject.tag=="Cancopy")
    //    {
    //        IsGround=true;
    //    }
    //}
    //��
}
