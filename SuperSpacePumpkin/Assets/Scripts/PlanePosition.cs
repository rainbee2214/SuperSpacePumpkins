using UnityEngine;
using System.Collections;

public class PlanePosition : MonoBehaviour 
{
	Quaternion rotation;
	
	void Start () 
	{
		
	}
	
	void Update () 
	{
		float x = transform.position.x;
		float y = transform.position.y;
		float z = transform.position.z;

		rotation.x = -(y) - Mathf.Sqrt(2)*z + 2;
		rotation.y = -(x) - Mathf.Sqrt(2)*z + 2;
		rotation.z = (-(x) - (y) + 2) / Mathf.Sqrt(2);

		transform.rotation = rotation;
	}
}
