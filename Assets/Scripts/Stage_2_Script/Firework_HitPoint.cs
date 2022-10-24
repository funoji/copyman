using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firework_HitPoint : MonoBehaviour
{
    //�����ɂ��Ă̏���
    [SerializeField] [Tooltip("�����蔻��̃I�u�W�F�N�g")] GameObject hitPoint;
    [SerializeField] [Tooltip("���������ꍇ : ������܂ł̎���")] private float deleTime;
    [SerializeField] [Tooltip("�������ĂȂ��ꍇ : ������܂ł̎���")] private float NodeleTime;
    [SerializeField] [Tooltip("�����͈�")] private float hitRadius = 2.0f;

    private void Start()
    {
        //�����̓����蔻��I�u�W�F�N�g���擾
        hitPoint=GameObject.Find("HitPoint_Empty");

        //�����͈͂̕ύX����
        hitPoint.GetComponent<SphereCollider>().radius = hitRadius;

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            //�����͈͂��I���ɂ���
            hitPoint.GetComponent<SphereCollider>().enabled = true;
            
            //���Ԍo�߂ŏ���
            Destroy(this.gameObject, deleTime);
        }
        else
        {
            //������Ȃ������ꍇ : ���Ԍo�߂ŏ���
            Destroy(this.gameObject, NodeleTime);
        }
    }
}
