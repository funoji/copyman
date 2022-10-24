using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBallScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name=="SmartBall"||
            other.gameObject.name == "SmartBall(Clone)")
        {
            Destroy(other.gameObject,0.0f);
        }
    }
}
