using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLimitItem : MonoBehaviour
{
    [SerializeField] private float limitTime;
    private float lifeTime;
    private bool onLimitArea = false;
    private bool isDestroy = false;

    private void Start()
    {
        lifeTime = limitTime * 60f;
    }

    private void FixedUpdate()
    {
        LimitTimeCount();
        ItemDestroy();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "LimitArea")
        {
            onLimitArea = true;
            lifeTime = limitTime * 60f;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "LimitArea")
        {
            onLimitArea = false;
        }
    }

    private void LimitTimeCount()
    {
        if (!onLimitArea)
        {
            lifeTime -= 1.0f;
        }

        if(lifeTime == 1)
        {
            transform.position = new Vector3(0, 1000000, 0);
        }
        
        if(lifeTime <= 0)
        {
            isDestroy = true;
        }
    }

    private void ItemDestroy()
    {
        if (isDestroy)
        {
            this.gameObject.SetActive(false);

        }
    }
}
