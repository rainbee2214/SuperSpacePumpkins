using UnityEngine;
using System.Collections;

public class PlayerBossController : MonoBehaviour 
{
	public Vector3 position;
	public float xBound;
	public float yBound;
	public float speed = 1f;

	void Update () 
	{
		if (Input.GetButton("w"))
		{
			position.x -= speed;
		}
		if (Input.GetButton("s"))
		{
			position.x += speed;
		}
		if (Input.GetButton("a"))
		{
			position.y -= speed;
		}
		if (Input.GetButton("d"))
		{
			position.y += speed;
		}
		if (position.x <= -xBound) position.x = -xBound;
		if (position.x >= xBound) position.x = xBound;
		if (position.y <= -yBound) position.y = -yBound;
		if (position.y >= yBound) position.y = yBound;

		transform.rotation = Quaternion.Euler(transform.rotation.x + position.x, transform.rotation.y + position.y, transform.rotation.z);
	}
}
