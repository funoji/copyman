using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GravityController : MonoBehaviour
{
    [SerializeField] private Vector3 ExtraGravity;
    private Rigidbody rb;

    private void Start()
    {
        rb= GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void FixedUpdate()
    {
        rb.AddForce(ExtraGravity,ForceMode.Acceleration);
    }
}
