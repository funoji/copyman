using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGimmick : MonoBehaviour
{
    [SerializeField] private float rotSpeed;
    [SerializeField] private float angle;
    [SerializeField] bool isActive = true;

    private bool seFlag = false;
    Quaternion targetRot;

    public bool ActiveGimmick
    {
        get => isActive;
        set => isActive = value;
    }
    public bool ActiveSeflag
    {
        get => seFlag;
        set => seFlag= value;
    }

    void Start()
    {
        targetRot = Quaternion.AngleAxis(angle, Vector3.up) * transform.rotation;
    }

    private void FixedUpdate()
    {
        if (!isActive) return;
        Rotate();
        if(seFlag)
        {
            AudioManager.Instance.PlaySE(SESoundData.SE.treasuryMove);
            seFlag = false;
        }

    }

    void Rotate()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, rotSpeed);
    }
}
