using UnityEngine;
using System.Collections;

public class PumpkingController : MonoBehaviour 
{
	public float speed;
	public float radius = 1f;
	public float rho;
	public float phi;
	public float theta;

	Vector3 position;
	public int startingPosition;

	void Start()
	{		
		//Convert theta and phi to radians
		theta = theta * (Mathf.PI / 180);
		phi = phi * (Mathf.PI / 180);
		
		rho = radius;
		startingPosition = Random.Range(0,3);
	}
	
	void Update()
	{		
		position.x = rho*Mathf.Sin(phi)*Mathf.Cos(theta);
		position.y = rho*Mathf.Sin(phi)*Mathf.Sin(theta);
		position.z = rho*Mathf.Cos(phi);

		rho += speed;
		float phiTemp = 1, thetaTemp = 1;
		switch (startingPosition)
		{
		case 0:
			phiTemp = 30;
			thetaTemp = 60;
			break;
		case 1:
			phiTemp = 45;
			thetaTemp = 45;
			break;
		case 2:
			phiTemp = -30;
			thetaTemp = 60;
			break;
		}
		phi = phiTemp * (Mathf.PI / 180);
		theta = thetaTemp * (Mathf.PI / 180);
		//phi = Random.Range (Mathf.PI / 2f, -(Mathf.PI / 2f));
		transform.position = position;
	}
	
}
