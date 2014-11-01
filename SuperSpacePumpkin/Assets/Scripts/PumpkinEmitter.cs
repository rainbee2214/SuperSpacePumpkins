using UnityEngine;
using System.Collections;

public class PumpkinEmitter : MonoBehaviour {

	public Transform target;
	public GameObject pumpkin;
	int poolCount = 10;
	GameObject[] pumpkins;
	GameObject[] outOfViewPumpkins;
	Vector3 outOfView;
	Vector3 position;

	int pumpkinCount = 0;

	void Start()
	{
		position = outOfView;
		outOfView = new Vector3(1000, 1000, 0);
		pumpkins = new GameObject[poolCount];
		outOfViewPumpkins = new GameObject[poolCount];
		for (int i = 0; i < poolCount; i++)
		{
			outOfViewPumpkins[i] = Instantiate(pumpkin, outOfView, Quaternion.identity) as GameObject;
			outOfViewPumpkins[i].transform.parent = transform;
			outOfViewPumpkins[i].name = "Jack" + (i + 1);
			outOfViewPumpkins[i].SetActive(false);
		}
	}

	void Update ()
	{
		if (Input.GetButtonDown("Fire"))
		{
			ShootPumpkin();
		}
	}

	void ShootPumpkin()
	{
		//Get & Activate pumpkin from out of view
		outOfViewPumpkins[pumpkinCount].SetActive(true);
		//Call Fire on pumpkin
		outOfViewPumpkins[pumpkinCount].GetComponent<JackController>().Fire();
		//Increment pumpkin count
		pumpkinCount++;
		if (pumpkinCount >= poolCount - 1) pumpkinCount = 0;
	}

	void MovePumpkin()
	{
		transform.position = outOfView;
	}

}
