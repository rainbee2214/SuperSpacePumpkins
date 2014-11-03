using UnityEngine;
using System.Collections;

public class OpeningPumpkinPosition : MonoBehaviour 
{
	float distanceFromPlanet;
	float phi;
	float theta;
	float phiSpeed;
	public float bound = 3;
	
	public Transform planet;

	Vector3 position;
	void Start()
	{	
		if (this.name == "Pumpking")
		{
			//Generate distance from planet, phi, theta, phiSpeed
			distanceFromPlanet = 4.5f;
			phi = Random.Range(2.5f, 4.5f);
			theta = 0;
			phiSpeed = 0.010f;
		}
		else
		{
			//Generate distance from planet, phi, theta, phiSpeed
			distanceFromPlanet = Random.Range(2.5f, 4.5f);
			phi = Random.Range(2.5f, 4.5f);
			theta = Random.Range(-180, 180);
			phiSpeed = Random.Range(0.005f, 0.025f);
		}

		//Convert theta and phi to radians
		theta = theta * (Mathf.PI / 180);
		phi = phi * (Mathf.PI / 180);
		
	}
	
	void Update()
	{
		if (Time.time > 19 && Application.loadedLevelName == "OpeningScene")
		{
			transform.position = position;
		}
		else
		{
			position.x = distanceFromPlanet*Mathf.Sin(phi)*Mathf.Cos(theta);
			position.y = distanceFromPlanet*Mathf.Sin(phi)*Mathf.Sin(theta);
			position.z = distanceFromPlanet*Mathf.Cos(phi);
			
			transform.position = position;
			if (this.name != "Pumpking")
			{
				transform.LookAt(planet);
				
			}
			
			phi = phi + phiSpeed;

		}
	}
	
}

