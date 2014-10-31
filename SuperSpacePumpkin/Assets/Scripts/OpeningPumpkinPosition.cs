using UnityEngine;
using System.Collections;

public class OpeningPumpkinPosition : MonoBehaviour 
{
	float distanceFromPlanet;
	float phi;
	float theta;
	float phiSpeed;
	public float bound = 3;
	
	public Transform target;

	Vector3 position;
	
	void Start()
	{		
		//Generate distance from planet, phi, theta, phiSpeed
		distanceFromPlanet = Random.Range(2.5f, 4.5f);
		phi = Random.Range(2.5f, 4.5f);
		theta = Random.Range(-180, 180);
		phiSpeed = Random.Range(0.005f, 0.025f);
		//Convert theta and phi to radians
		theta = theta * (Mathf.PI / 180);
		phi = phi * (Mathf.PI / 180);
		
	}
	
	void Update()
	{
		position.x = distanceFromPlanet*Mathf.Sin(phi)*Mathf.Cos(theta);
		position.y = distanceFromPlanet*Mathf.Sin(phi)*Mathf.Sin(theta);
		position.z = distanceFromPlanet*Mathf.Cos(phi);
		
		transform.position = position;
		transform.LookAt(target);
		
		phi = phi + phiSpeed;
		if (phi >= bound)
		{
			phi = 0;
		}

	}
	
}

