using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpManager : MonoBehaviour
{
    [SerializeField] Transform playerPosition;

    public float x = -3;
    public float y = -3;
    public float z = -3;

    private Rigidbody rb;//Rigidbody�ǂݍ��ݗp�ϐ�
    public float JumpPower = 200f;//�W�����v�����(������ւ̗�)
    public int JumpLimit = 1;//�W�����v�ł����
    //private int jumpCount = 0;   //���������p
    private bool IsGround = true;//�ڒn�t���O�p
    private float distance = 1.0f;
    Vector3 rayPosition;

    void Start()
    {
        rb= GetComponent<Rigidbody>();   //Rigidbody�擾 
    }

    void Update()
    {
        rayPosition=/*transform.position+*/new Vector3(
            playerPosition.position.x-x, playerPosition.position.y-y, playerPosition.position.z-z);
        Ray ray = new Ray(rayPosition, Vector3.down);
        IsGround = Physics.Raycast(ray, distance);
        Debug.DrawRay(rayPosition, Vector3.down*distance, Color.red);

        //Debug.Log(IsGround);
    }
    public void Jump()
    {
        if (IsGround) //Ray�ŃW�����v���Ǘ�����Ver
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(new Vector3(0, JumpPower, 0)); //�W�����v�̕���
        }
    }

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
    //void OnCollisionEnter(Collision coll)
    //{
    //    //�n�ʂɒ��n���Ă��邩�ǂ����̔���
    //    //���������ɂ������ăX�e�[�W�̃^�O���hStageGround�h�ɕύX���܂����B
    //    if (coll.gameObject.tag=="StageGround")
    //    {
    //        IsGround=true;
    //    }
    //}
}
