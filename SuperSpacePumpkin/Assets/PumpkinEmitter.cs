using UnityEngine;
using System.Collections;

public class PumpkinEmitter : MonoBehaviour {

	public Transform target;
	public GameObject pumpkin;
	int poolCount = 10;
	GameObject[] pumpkins;
	Vector3 outOfView;
	Vector3 position;

	void Start()
	{
		position = outOfView;
		outOfView = new Vector3(1000, 1000, 0);
		pumpkins = new GameObject[poolCount];
		for (int i = 0; i < poolCount; i++)
		{
			pumpkins[i] = Instantiate(pumpkin, outOfView, Quaternion.identity) as GameObject;
		}
	}

	void Update ()
	{
		//Shoot a pumpkin
		//Set it's position = camera position, and then set it in motion towards the planet
		position = transform.position;
		position.z -= 1;
		pumpkins[0].transform.position = position;
		//When destroying a pumpking
		//Set it's position to outOfView

	}

	void MovePumpkin()
	{
		transform.position = outOfView;
	}

}
