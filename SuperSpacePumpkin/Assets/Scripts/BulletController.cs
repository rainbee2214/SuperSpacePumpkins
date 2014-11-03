using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	public float speed;

	void Update () 
	{
		rigidbody.velocity = -transform.forward * speed;
	}
	
}
