//�A�^�b�`����I�u�W�F�N�g�FDwbuk�pCube�uDebugShot_Cube�v�E�v���C���[
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stage_2_Firework_Move_Script: MonoBehaviour
{
    //Debug : object����I�u�W�F�N�g�𐶐�����
    [SerializeField] [Tooltip("�e�̔��ˏꏊ")] GameObject fireworkPoint;
    [SerializeField] [Tooltip("�e")] GameObject firework;
    [SerializeField] [Tooltip("�e�̃X�s�[�h")] float fireworkSpeed = 20f;

    //�Q�[���N���A����
    [SerializeField] [Tooltip("�^�[�Q�b�g�̌�")] public GameObject[] Count;
    [SerializeField] [Tooltip("�Q�[���N���A�p�̃p�l��")] public GameObject clearPanel;

    private void Start()
    {
        clearPanel.SetActive(false);
    }

    private void Update()
    {
        //�^�[�Q�b�g�������Č���������iCount.Length�F�^�[�Q�b�g�̌��j
        Count = GameObject.FindGameObjectsWithTag("Target");
        //Debug.Log("�c��̃^�[�Q�b�g���F" + Count.Length);
        //�����O�ɂȂ������̏���
        if (Count.Length == 0)
        {
            clearPanel.SetActive(true);
            //Debug.Log("�Q�[���N���A");
            Transtion.instatns.Trans_GameClear();
        }

        //Debug : �X�y�[�X�L�[���������Ƃ��̏���
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            shot();
        }
    }

    //Debug : �I�u�W�F�N�g����Speher�𐶐�
    void shot()
    {
        Vector3 Point = this.transform.position;
        GameObject newFirework = Instantiate(firework, Point, transform.rotation);
        Vector3 direction = newFirework.transform.forward;
        newFirework.GetComponent<Rigidbody>().AddForce(direction * fireworkSpeed, ForceMode.Impulse); ;
    }
}
