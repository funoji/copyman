using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleLimit : MonoBehaviour
{
    public float rotateSpeed = 0.5f; //回転スピード
    public float rotateX_Min, rotateX_Max;
    public float rotateY_Min, rotateY_Max;
    private float angleY;
    private float angleX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        angleY = transform.localEulerAngles.y;
        if (angleY > 180)
        {
            angleY = angleY - 360;
        }
        angleY = Mathf.Clamp(angleY, rotateY_Min, rotateX_Max);

        angleX = transform.localEulerAngles.x;
        if (angleX>180)
        {
            angleX = angleX - 360;
        }
        angleX = Mathf.Clamp(angleX, rotateX_Min, rotateX_Max);
        transform.localEulerAngles = new(angleX, angleY, 0);
    }

    void Move()
    {
        //Vector3 angle = new Vector3(Input.GetAxis("CameraVertical") * rotateSpeed, Input.GetAxis("CameraHorizontal") * rotateSpeed * -1, 0); //Xbox360<Rstick>
        Vector3 angle = new Vector3(Input.GetAxis("Mouse Y") * rotateSpeed, Input.GetAxis("Mouse X") * rotateSpeed*-1, 0); //マウス
        transform.Rotate(angle);
    }
}
