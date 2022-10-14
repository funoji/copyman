using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//�@�d�͑���p�̃X�N���v�g�BRigidbody�����Ă�I�u�W�F�N�g�ɃA�^�b�`�����
//���̃I�u�W�F�N�g�݂̂ɂ�����d�͂𒲐��ł���B


[RequireComponent(typeof(Rigidbody))]
public class GravityController : MonoBehaviour
{
    [SerializeField]private Vector3 ExtraGravity;�@//Rigidbody�ɉ�����d�͂̔{��
    private Rigidbody rb;�@�@//Rigidbody�擾�p�̕ϐ�

    private void Start()
    {
        rb= GetComponent<Rigidbody>(); //Rigidbody�擾
        rb.useGravity = false;
    }

    private void FixedUpdate()
    {
        rb.AddForce(ExtraGravity, ForceMode.Acceleration);�@//�{����
    }
}
