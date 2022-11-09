using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickClear : MonoBehaviour
{
    //���̕ϐ�
    [SerializeField] GameObject target;

    //�I�u�W�F�N�g���Ђ��H�ɓ��������狴���d�͂ŗ��Ƃ��B�܂��Ђ��H�������B
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Trigger")
        {
            Attach_Gravity(); //�d�͂�t�^����
            Destroy(this.gameObject); //�I�u�W�F�N�g������
        }
    }

    //�d�͂�t�^����
    void Attach_Gravity()
    {
        target.GetComponent<Rigidbody>().useGravity = true;
    }
}
