using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	Vector3 latestPos;
	Vector3 movingDirecion;
	[SerializeField] float speedMagnification;
	[SerializeField] Rigidbody rb;
	Vector3 movingVelocity;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		Movement();
		Rotate();
	}

	void FixedUpdate()
	{

	}

	void Movement()
    {
		float x = Input.GetAxisRaw("Horizontal");
		float z = Input.GetAxisRaw("Vertical");
		movingDirecion = new Vector3(x, 0, z);
		movingDirecion.Normalize();
		movingVelocity = movingDirecion * speedMagnification;
		rb.velocity = new Vector3(movingVelocity.x, rb.velocity.y, movingVelocity.z);
	}

	void Rotate()
    {
		Vector3 differenceDis = new Vector3(transform.position.x, 0, transform.position.z) - new Vector3(latestPos.x, 0, latestPos.z);
		latestPos = transform.position;
		if (Mathf.Abs(differenceDis.x) > 0.001f || Mathf.Abs(differenceDis.z) > 0.001f)
		{
			if (movingDirecion == new Vector3(0, 0, 0)) return;
			Quaternion rot = Quaternion.LookRotation(differenceDis);
			rot = Quaternion.Slerp(rb.transform.rotation, rot, 0.2f);
			this.transform.rotation = rot;
		}
	}

}
