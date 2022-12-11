using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpManager : MonoBehaviour
{
    [SerializeField] Transform playerPosition;

    public float x = 0;
    public float y = -0.75f;
    public float z = 0;

    Rigidbody rb;
    public float JumpPower = 250f;
     bool IsGround = true;
    float distance = 1.0f;
    Vector3 rayPosition;

    void Start()
    {
        rb= GetComponent<Rigidbody>();
    }

    void Update()
    {
        rayPosition=new Vector3(
            playerPosition.position.x-x, playerPosition.position.y-y, playerPosition.position.z-z);
        Ray ray = new Ray(rayPosition, Vector3.down);
        IsGround = Physics.Raycast(ray, distance);

        Debug.DrawRay(rayPosition, Vector3.down, Color.red);
        //Debug.Log(IsGround);
    }
    public void Jump()
    {
        if (IsGround)
        {
            AudioManager.Instance.PlaySE(SESoundData.SE.jump);
            rb.velocity = Vector3.zero;
            rb.AddForce(new Vector3(0,JumpPower,0));
        }
    }
}
