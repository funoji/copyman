using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_StickMove : MonoBehaviour
{
    public void L_Stick_Move_X(float speed_X)
    {
        transform.position += new Vector3(
            0, 0, Input.GetAxis("Horizontal")*speed_X*Time.deltaTime);
    }

    public void L_Stick_Move_Y(float speed_Y)
    {
        transform.position += new Vector3(
            Input.GetAxis("Vertical")*speed_Y*Time.deltaTime, 0, 0);
    }
}
