using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator_Soccer : MonoBehaviour
{
    [SerializeField] private GameObject InstanceObject;
    [SerializeField] private Transform SpawnPosition;
    Rigidbody rb;
    public int Power = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "soccerball"||
            other.gameObject.name=="RefSoccerBall")
        {
            //Instantiate(InstanceObject);
            GameObject obj = Instantiate(InstanceObject);
            rb = obj.GetComponent<Rigidbody>();
            obj.transform.position=new Vector3(
                SpawnPosition.position.x,
                SpawnPosition.position.y,
                SpawnPosition.position.z);
            rb.AddForce(transform.forward * Power, ForceMode.Impulse);
        }
    }
}
