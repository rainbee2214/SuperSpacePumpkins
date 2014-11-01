using UnityEngine;
using System.Collections;

public class PlanePosition : MonoBehaviour 
{
	Vector3 position;

	public GameObject pumpsplosion;
	GameObject explosion;
	Vector3 outOfView;

	void Start () 
	{
		outOfView = new Vector3(1000, 1000, 0);
		explosion = Instantiate (pumpsplosion, new Vector3(100,100,0), Quaternion.identity) as GameObject;
	}
	
	void Update () 
	{

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Pumpkin")
		{
			GameController.controller.Score = 1;
			explosion.transform.position = gameObject.transform.position;
			explosion.gameObject.particleSystem.Play();

			other.gameObject.transform.position = outOfView;
			//Destroy(other.gameObject);

		}
	}
}
