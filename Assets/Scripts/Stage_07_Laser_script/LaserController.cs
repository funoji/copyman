using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    [SerializeField] [Tooltip("���ˏꏊ")] GameObject firingLocatioin;
    [SerializeField] [Tooltip("���[�U�[�̌��ƂȂ�I�u�W�F�N�g")] GameObject laserObj;
    [SerializeField] [Tooltip("�I�u�W�F�N�g�̑���")]float laserSpeed = 50f;

    private float time;         //�@�b���Ǘ�
    private bool isOn = false;   //�@�R�b�Ԋu��on��off�̐؂�ւ��̔���
    private bool shotOn = true; //�@�P��̂݃I�u�W�F�N�g�𐶐������邽�߂̔���

    [SerializeField] bool gameOver;
    [SerializeField] bool gameClear;
    LaserGameOver laserGameOverScript;
    GoarManeger goarScript;

    private void Start()
    {
        //gameOver = GameObject.FindWithTag("Trigger");
        //gameOver = laserGameOverScript.GetComponent<LaserGameOver>().gameoverFlag;
        //gameClear = GameObject.FindWithTag("Goar_Judg");
        //gameClear = goarScript.GetComponent<GoarManeger>().gameclearFlag;
    }

    private void Update()
    {
        //���Ԃ𐶐�
        time += Time.deltaTime;
        //Debug.Log(time);

        //�R�b�Ԋu
        if (time <= 3.0f)
        {
            //�R�b�Ԋu�Ń��[�U�[�𔭎˂�����i�����蔻��̃I�u�W�F�N�g�͈��̂ݐ����j
            if (isOn && shotOn)
            {
                ShotMove(); //�I�u�W�F�N�g�̔���
                shotOn = false;
            }
        }
        if (time > 3.0f)
        {
            if (isOn) isOn = false;
            else if (!isOn) isOn = true; shotOn = true;
            time = 0; //���Ԃ̏�����
        }

        ////GameOver�ɂȂ����珈�����~����B����GameClear�ɂȂ����珈�����~����
        //if (gameOver == false || gameClear == false) 
        //{
        //    //���Ԃ𐶐�
        //    time += Time.deltaTime;
        //    //Debug.Log(time);

        //    //�R�b�Ԋu
        //    if (time <= 3.0f)
        //    {
        //        //�R�b�Ԋu�Ń��[�U�[�𔭎˂�����i�����蔻��̃I�u�W�F�N�g�͈��̂ݐ����j
        //        if (isOn && shotOn)
        //        {
        //            ShotMove(); //�I�u�W�F�N�g�̔���
        //            shotOn = false;
        //        }
        //    }
        //    if (time > 3.0f)
        //    {
        //        if (isOn) isOn = false;
        //        else if (!isOn) isOn = true; shotOn = true;
        //        time = 0; //���Ԃ̏�����
        //    }
        //}
    }

    //�I�u�W�F�N�g�̔���
    void ShotMove()
    {
        //�I�u�W�F�N�g�𔭎˂�����ꏊ���擾
        Vector3 laserobjPosition = firingLocatioin.transform.position;
        //�擾�����ꏊ�ɃI�u�W�F�N�g���o��������
        GameObject newLaser = Instantiate(laserObj, laserobjPosition, transform.rotation);
        //�o���������I�u�W�F�N�g��foward(z�������j
        Vector3 direction = newLaser.transform.right;
        //�I�u�W�F�N�g�̔��˕�����Z���������A�I�u�W�F�N�g��rigibody�ɗ͂�������
        newLaser.GetComponent<Rigidbody>().AddForce(direction * laserSpeed, ForceMode.Impulse);
    }
}
