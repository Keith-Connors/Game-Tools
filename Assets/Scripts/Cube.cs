using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{

	[SerializeField] private float sideVelocity = Random.Range(1, 50);

	[SerializeField] private float upVelocity = Random.Range(1, 50);
	
	// Use this for initialization
	void Start () 
	{
		Vector3 velocity = new  Vector3();
		velocity.x = Random.Range(-sideVelocity, sideVelocity);
		velocity.y = Random.Range(upVelocity / 2, upVelocity);
		velocity.z = Random.Range(-sideVelocity, sideVelocity);

		GetComponent<Rigidbody>().velocity = velocity;
	}
	
}
