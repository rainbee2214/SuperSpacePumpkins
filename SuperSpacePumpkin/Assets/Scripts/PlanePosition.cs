using UnityEngine;
using System.Collections;

public class PlanePosition : MonoBehaviour 
{
	Vector3 position;

	public GameObject pumpsplosion;
	GameObject explosion;

	void Start () 
	{
		explosion = Instantiate (pumpsplosion, new Vector3(100,100,0), Quaternion.identity) as GameObject;
	}
	
	void Update () 
	{

	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log(other.tag);
		if (other.tag == "Pumpkin")
		{
			GameController.controller.Score = 1;
			explosion.transform.position = gameObject.transform.position;
			explosion.gameObject.particleSystem.Play();

			Destroy(other.gameObject);

		}
	}
}
