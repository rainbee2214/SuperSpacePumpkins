using UnityEngine;
using System.Collections;

public class CameraPosition : MonoBehaviour 
{
	public float distanceFromPlanet;
	public float phi;
	public float theta;
	public float speed;
	public float bound = 3;

	public Transform target;
	
	Vector3 origin = new Vector3(0,0,0);
	Vector3 position;
	
	void Start()
	{
		position = origin;
		
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

		phi = phi + speed;
		if (phi >= bound)
		{
			phi = 0;
		}
	}
	
}
