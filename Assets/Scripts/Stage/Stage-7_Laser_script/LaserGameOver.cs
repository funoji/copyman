using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_GameOver : MonoBehaviour
{
    //�Q�[���I�[�o�[�t���O�i�����Ffalse�j
    public bool gameoverFlag = false;

    //�Q�[���I�[�o�[����
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameoverFlag = true;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameoverFlag = true;
            Debug.Log("��������");
        }
    }
}
