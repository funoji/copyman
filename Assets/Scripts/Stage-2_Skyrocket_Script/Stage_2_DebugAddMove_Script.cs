using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_2_DebugAddMove_Script : MonoBehaviour
{
    //[SerializeField] private float fowardspeed = 0.0001f;
    //[SerializeField] private float backspeed = 0.0f;

    //ïœêî
    [SerializeField] GameObject elever;
    public Rigidbody rb;
    public Transform initial;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();  //rigidbodyÇéÊìæ
        //initial.transform.position = new Vector3(-8f, 3.8f, 14f);
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position += new Vector3(-backspeed, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Trigger")
        {
            //Debug.Log("ìñÇΩÇ¡ÇΩ");
        }
    }


    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (Time.time <= 0.5f)
    //    {
    //        this.transform.position += new Vector3(-backspeed, 0, 0);
    //    }
    //    else
    //    {
    //        rb.AddForce(fowardspeed, 0, 0);
    //    }
    //}
}
