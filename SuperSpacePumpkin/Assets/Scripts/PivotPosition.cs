﻿using UnityEngine;
using System.Collections;

public class PivotPosition : MonoBehaviour 
{
	public float radius = 1f;
	public float rho;
	public float phi;
	public float theta;
	
	Vector3 origin = new Vector3(0,0,0);
	Vector3 position;
	
	void Start()
	{
		position = origin;
		
		//Convert theta and phi to radians
		theta = theta * (Mathf.PI / 180);
		phi = phi * (Mathf.PI / 180);
		
		rho = radius;
	}
	
	void Update()
	{
		position.x = rho*Mathf.Sin(phi)*Mathf.Cos(theta);
		position.y = rho*Mathf.Sin(phi)*Mathf.Sin(theta);
		position.z = rho*Mathf.Cos(phi);
		
		transform.position = position;
	}
	
}
