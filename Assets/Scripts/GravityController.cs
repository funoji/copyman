using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//�@�d�͑���p�̃X�N���v�g�BRigidbody�����Ă�I�u�W�F�N�g�ɃA�^�b�`�����
//���̃I�u�W�F�N�g�݂̂ɂ�����d�͂𒲐��ł���B


[RequireComponent(typeof(Rigidbody))]
public class GravityController : MonoBehaviour
{
    public float ExtraGravity = 1f;�@//Rigidbody�ɉ�����d�͂̔{��
    private Rigidbody rb;�@�@//Rigidbody�擾�p�̕ϐ�

    private void Start()
    {
        rb= GetComponent<Rigidbody>(); //Rigidbody�擾
    }

    private void FixedUpdate()
    {
        rb.AddForce((ExtraGravity-1f)*Physics.gravity, ForceMode.Acceleration);�@//�{����
    }
}
