using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGimmick : MonoBehaviour
{
    [SerializeField] private float rotSpeed;
    [SerializeField] private float angle;
    [SerializeField] bool isActive = true;

    Quaternion targetRot;

    public bool ActiveGimmick
    {
        get => isActive;
        set => isActive = value;
    }

    void Start()
    {
        targetRot = Quaternion.AngleAxis(angle, Vector3.up) * transform.rotation;
    }

    private void FixedUpdate()
    {
        if (!isActive) return;
        Rotate();
    }

    void Rotate()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, rotSpeed);
    }
}
