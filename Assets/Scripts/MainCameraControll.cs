using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Cinemachine;

public class MainCameraControll : MonoBehaviour
{
    //�O�l�̃J�����F�J����������͂��L������v���p�e�B
    Vector2 cameraRotationInput = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        //�I�u�W�F�N�g�̖��O�Ō������Ď擾
        //GameObject Maincamera_object = GameObject.Find("Main Camera");
        GameObject Playercamera_object = GameObject.Find("PlayerCamera");
        //Debug.Log("���C���J�����̈ʒu"+Maincamera_object.transform.position);
        Debug.Log("�v���C���[�J�����̈ʒu"+Playercamera_object.transform.position);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Look(Vector2 input)
    {
        cameraRotationInput = input;
    }

}
