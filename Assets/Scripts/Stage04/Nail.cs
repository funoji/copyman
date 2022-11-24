using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nail : MonoBehaviour
{
    private Rigidbody rb;
    private bool isGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isGround = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGround)
        {
            rb.isKinematic = true;
            return;
        }
        Ray ray = new Ray(transform.position, Vector3.down);
        isGround = Physics.Raycast(ray, 0.75f);
        
    }
}
