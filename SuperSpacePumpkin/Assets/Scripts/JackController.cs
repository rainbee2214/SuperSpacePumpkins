using UnityEngine;
using System.Collections;

public class JackController : MonoBehaviour 
{

	public Vector3 from;
	public Vector3 to;

	float speed = 1.0f;
	private float startTime;
	private float journeyLength = 1;

	public Transform target;
	public float smooth = 5.0F;
	public Vector3 outOfView;
	Vector3 origin;
	Vector3 random;

	public float variance = 0.6f;

	public bool fired;

	void Start()
	{
		origin = new Vector3(0,0,0);
		outOfView = new Vector3(1000,1000,0);
		Fire();
	}

	public void Fire() 
	{
		from = transform.parent.position;
		random = new Vector3(origin.x + Random.Range(-variance, variance), origin.y + Random.Range (-variance, variance), origin.z + Random.Range(-variance, variance));
		to = random;
		startTime = Time.time;
		journeyLength = Vector3.Distance(from, to);
		fired = true;
	} 

	void Die()
	{
		fired = false;
		transform.position = outOfView;
		gameObject.SetActive(false);
	}

	void Update() 
	{
		if (fired)
		{
			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / journeyLength;
			transform.position = Vector3.Lerp(from, to, fracJourney);
		}
		if (GameController.controller.PumpkinSpeed != speed)
		{
			speed = GameController.controller.PumpkinSpeed;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Planet")
		{
			GameController.controller.PlanetHealth = -5;
		}
		else if (other.tag == "Plane" || other.tag == "Laser" || other.tag == "Bullet")
		{
			GameController.controller.Score = 1;
			if (other.tag == "Bullet") other.gameObject.SetActive(false);
		}
		else if (other.tag == "Boss") return;
	
		GameController.controller.Explode(other.tag, other.gameObject.transform.position);
				
		Die();
	}
}
