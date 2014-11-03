using UnityEngine;
using System.Collections;

public class PumpkingController : MonoBehaviour {

	public float distanceFromPlanet;
	public float phi;
	public float theta;
	public float phiSpeed;
	public float thetaSpeed;

	public Transform target;
	Vector3 position;

	void Start()
	{	
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
		
		phi = phi + phiSpeed;		
		//theta = theta + thetaSpeed;
	}
	
}
