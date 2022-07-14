using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraControll : MonoBehaviour
{
    GameObject mainCamera; //�J����
    GameObject fieldObject; //���S�Ƃ������I�u�W�F�N�g
    public float rotateSpeed = 1.0f; //��]�X�s�[�h
    private Vector3 lastMousePosition; //���O�̉�]��ێ����Ă������߂̕ϐ�
    private Vector3 newAngle = new Vector3(0, 0, 0); // Vector3(0,0,0)�̃C���X�^���X
    
    void Start()
    {
        this.mainCamera = Camera.main.gameObject; //�J�����̃I�u�W�F�N�g���擾
        this.fieldObject = GameObject.Find("LookPos"); //���S�Ƃ������I�u�W�F�N�g���擾
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //���͂���Ă����񂾂����s����
        {
            newAngle = mainCamera.transform.localEulerAngles; //newAngle�ϐ��ɑ��ΓI�ȉ�]�n����
            lastMousePosition = Input.mousePosition;  //�N���b�N���ꂽ�ۂ̃}�E�X�ʒu����
        }
        else if (Input.GetMouseButton(0))
        {
            rotateCamera();
        }

        Find_Angle(this.mainCamera, this.fieldObject);
        //Debug.Log("�Q�_�Ԃ̋����F"+Find_Distance(this.mainCamera, this.fieldObject));
    }

    private void rotateCamera()
    {
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * this.rotateSpeed, Input.GetAxis("Mouse Y") * this.rotateSpeed, 0); 
        this.mainCamera.transform.RotateAround(this.fieldObject.transform.position, Vector3.up, angle.x); //X���̉�]
        this.mainCamera.transform.RotateAround(this.fieldObject.transform.position, transform.right, angle.y); //�����̉�]
    }

    public float Find_Distance(GameObject camera, GameObject player)
    {
        //�J�����[�v���C���[�̋���
        float dist_x = camera.transform.position.x - player.transform.position.x;
        float dist_z = camera.transform.position.y - player.transform.position.y;
        //���������߂�
        return Mathf.Sqrt((dist_x * dist_x) + (dist_z * dist_z));
    }
    void Find_Angle(GameObject camera,GameObject player)
    {
        //�p�x�����߂�
        Quaternion.LookRotation(camera.transform.position, player.transform.position);
        Debug.Log("�J�����̈ʒu�F"+camera.transform.position);
        Debug.Log("�v���C���[�̈ʒu�F" + player.transform.position);
        Debug.Log("�Q�_�Ԃ̊p�x�F"+Quaternion.LookRotation(camera.transform.position, player.transform.position));
    }
}