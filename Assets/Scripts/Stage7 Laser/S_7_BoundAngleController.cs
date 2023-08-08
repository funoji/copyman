using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_7_BoundAngleController : MonoBehaviour
{
    //�I�u�W�F�N�g��Rigidbody���擾
    [SerializeField] Rigidbody laserObject;

    //�I�u�W�F�N�g�Ƌ��Ƃ̓��ˊp�Ɣ��ˊp�𓯂��ɂ�����
    private void OnCollisionEnter(Collision collision)
    {
        // ���˃x�N�g���i���x�j
        var inDirection = laserObject.velocity;
        // �@���x�N�g��
        var inNormal = transform.up;
        // ���˃x�N�g���i���x�j
        var result = Vector3.Reflect(inDirection, inNormal);

        // �o�E���h��̑��x���{�[���ɔ��f
        laserObject.velocity = result;
    }
}
