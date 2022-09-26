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
        if (transform.position.x < -500f)
        {
            transform.position = new Vector3(1375f, 205f, 0);
        }
    }
}
