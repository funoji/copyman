using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1.0f;

    private CharacterController enemyController;
    private Vector3 destination;
    private Vector3 velocity;
    private Vector3 direction;

    void Start()
    {
        enemyController = GetComponent<CharacterController>();
        destination = new Vector3(0f, 0f, 0f);
        velocity = Vector3.zero;
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
