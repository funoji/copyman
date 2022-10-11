using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollTextureScript : MonoBehaviour
{
    public float speed = 0.5f;
    void Start()
    {
        
    }
    void Update()
    {
        transform.Translate(-speed, 0, 0);
        if (transform.position.x < -1370f)
        {
            transform.position = new Vector3(3000f, 540f, 0);
        }
    }
}
