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
	
	Vector3 origin = new Vector3(0,0,0);
	Vector3 position;

	bool pushingCamera = true;
	public float planetPushSpeed = 0.1f;
	public float targetDistance = 10f;

	public Material[] boxes;
	void Start()
	{
		int i = Random.Range (0, boxes.Length);
		Debug.Log (i);
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
			}
		}

		position.x = distanceFromPlanet*Mathf.Sin(phi)*Mathf.Cos(theta);
		position.y = distanceFromPlanet*Mathf.Sin(phi)*Mathf.Sin(theta);
		position.z = distanceFromPlanet*Mathf.Cos(phi);
		
		transform.position = position;
		transform.LookAt(target);

		phi = phi + phiSpeed;
		if (phi >= bound)
		{
			//phi = 0;
		}

		theta = theta + thetaSpeed;
		if (theta >= bound)
		{
			//phi = 0;
		}
	}

	void pushCameraOut() 
	{
		distanceFromPlanet += planetPushSpeed;
	}
	
}
