using UnityEngine;
using System.Collections;

public class PumpkinEmitter : MonoBehaviour {

	public Transform target;
	public GameObject pumpkin;
	public int poolCount = 40;
	GameObject[] outOfViewPumpkins;
	Vector3 outOfView;

	int pumpkinCount = 0;

	public float shootDelay = 3f;
	public float lastShootTime = 0f;
	void Start()
	{
		lastShootTime = Time.time;
		outOfView = new Vector3(1000, 1000, 0);
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
			//ShootPumpkin();
		}
		if (Time.time > lastShootTime + shootDelay)
		{
			lastShootTime = Time.time;
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
