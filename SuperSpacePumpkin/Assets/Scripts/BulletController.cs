using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	public float speed;
	public int forward = 1;
	void Update () 
	{
		rigidbody.velocity = -transform.forward * speed * forward;
	}
	
}
