using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour 
{
	public bool WIN;
	public float speed;
	public float lerpTime;

	public Vector3 startPosition;
	public Transform target;
	public Vector3 nextPosition;

	public int numberOfSteps;
	public float xBound, yBound, zBound;
	public float nextXBound, nextYBound, nextZBound;

	int currentStep;
	int stepSize = 2;
	float zStep;

	bool isLerping = false;

	void Start () 
	{
		currentStep = 1;

		zBound = transform.position.z;
		zStep = zBound / numberOfSteps;
		nextZBound = zBound - zStep;

		xBound = zBound / 2;
		yBound = zBound / 3;
		nextXBound = xBound - stepSize;
		nextYBound = yBound - stepSize;

		Step();
	}
	
	void Update () 
	{
		if (WIN) Application.LoadLevel("Win");
		if (GameController.controller.BossHealth <= 0) Application.LoadLevel("Win");
		transform.LookAt(target);
		if (isLerping) transform.position = Vector3.Lerp(transform.position, nextPosition, Time.deltaTime * lerpTime);
		if (NearNextPosition()) Step();
		if (transform.position == target.transform.position) GameController.controller.IsDead = true;
	}

	bool NearNextPosition()
	{
		if (
			(transform.position.x >= nextPosition.x - 0.1) &&
			(transform.position.x <= nextPosition.x + 0.1) &&
			(transform.position.y >= nextPosition.y - 0.1) &&
			(transform.position.y <= nextPosition.y + 0.1) &&
			(transform.position.z >= nextPosition.z - 0.1) &&
			(transform.position.z <= nextPosition.z + 0.1)
			) return true;
		return false;
	}

	void Step()
	{
		isLerping = false;

		nextPosition.x = Random.Range(-xBound, xBound);
		nextPosition.y = Random.Range(-yBound, yBound);
		nextPosition.z = Random.Range(zBound, nextZBound);

		//Increment
		xBound = nextXBound;
		yBound = nextYBound;
		zBound = nextZBound;
		nextXBound = nextXBound - stepSize;
		nextYBound = nextYBound - stepSize;
		nextZBound = nextZBound - zStep;
		currentStep++;

		isLerping = true;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Bullet")
		{
			GameController.controller.BossHealth = -2;
			Debug.Log ("Boss health " + GameController.controller.BossHealth);
		}
		else if (other.tag == "Laser")
		{
			GameController.controller.BossHealth = -10;
		}
	}
}
