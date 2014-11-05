using UnityEngine;
using System.Collections;

public class CameraPosition : MonoBehaviour 
{
	public float distanceFromPlanet;
	public float phi;
	public float theta;
	public float phiSpeed;
	public float thetaSpeed;
	public float bound = 3f;

	public Transform target;
	public GameObject GUI;

	Vector3 origin = new Vector3(0,0,0);
	Vector3 position;

	bool pushingCamera = true;
	public float planetPushSpeed = 0.1f;
	public float targetDistance = 10f;

	public Material[] boxes;

	void Start()
	{
		if (Application.loadedLevelName == "Death")
		{
			pushingCamera = false;
		}

		if (Application.loadedLevelName != "Tutorial") GUI.gameObject.SetActive(false);

		int i = Random.Range (0, boxes.Length);
		Skybox skybox = gameObject.GetComponent<Skybox>(); 
		skybox.material = boxes[i];
		position = origin;

		theta = Random.Range(-180, 180);
		//Convert theta and phi to radians
		theta = theta * (Mathf.PI / 180);
		phi = phi * (Mathf.PI / 180);

	}
	
	void Update()
	{
		if (pushingCamera)
		{
			pushCameraOut();
			if (distanceFromPlanet >= targetDistance)
			{
				pushingCamera = false;
				if (Application.loadedLevelName != "Tutorial")
					GUI.gameObject.SetActive(true);
			}
		}

		position.x = distanceFromPlanet*Mathf.Sin(phi)*Mathf.Cos(theta);
		position.y = distanceFromPlanet*Mathf.Sin(phi)*Mathf.Sin(theta);
		position.z = distanceFromPlanet*Mathf.Cos(phi);
		
		transform.position = position;
		transform.LookAt(target);

		phi = phi + phiSpeed;
		theta = theta + thetaSpeed;
	}

	void pushCameraOut() 
	{
		distanceFromPlanet += planetPushSpeed;
	}
	
}
