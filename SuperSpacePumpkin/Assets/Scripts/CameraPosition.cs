using UnityEngine;
using System.Collections;

public class CameraPosition : MonoBehaviour 
{
	public float distanceFromPlanet;
	public float phi;
	public float theta;
	public float phiSpeed;
	public float thetaSpeed;
	public float bound = 3f;

	public Transform target;
	public GameObject GUI;
	public GameObject messageGUI;

	Vector3 origin = new Vector3(0,0,0);
	Vector3 position;

	bool pushingCamera = true;
	public float planetPushSpeed = 0.1f;
	public float targetDistance = 10f;

	public Material[] boxes;

	string[] SetMessages()
	{
		if (Application.loadedLevelName == "Tutorial")
		{
			string[] messages = {
				"move with W A S D!",
				"shoot with space!",
				"kill the pumpkin invaders!",
				"protect the planet!",
				"kill the evil PUMPKING!"
			};
			return messages;
		}
		else if (Application.loadedLevelName == "Win")
		{
			string[] messages = {
				"congratulations!",
				"you saved the humans!",
				"you killed the PUMPKING!",
				"you protected the planet!"
			};
			return messages;
		}
		else
		{
			string[] messages = {
				"save the planet!",
				"pumpkin invaders!",
				"death from above!",
				"much halloween!",
				"such jack o' lantern!",
				"defend the planet!",
				"all hail the pumpkin king!",
				"spooky!",
				"alien invaders!",
				"save the President!",
				"win all the candy!",
				"binary score?",
				"invaders!",
				"attack of the killer pumpkins!",
				"save the children!",
				"trick or treat!",
				"give me something good to eat!",
				"attack of the super space pumpkins!",
				"boo!",
				"protect the people!"
			};
			return messages;
		}
	}

	void Start()
	{
		if (Application.loadedLevelName == "Death")
		{
			pushingCamera = false;
		}
	
		string[] messages = SetMessages();
		GUI.gameObject.SetActive(false);
		if (Application.loadedLevelName != "Menu")
		{
			messageGUI.gameObject.guiText.text = messages[Random.Range (0, messages.Length)];
			messageGUI.gameObject.SetActive(true);
		}
		int i = Random.Range (0, boxes.Length);
		Skybox skybox = gameObject.GetComponent<Skybox>(); 
		skybox.material = boxes[i];
		position = origin;

		theta = Random.Range(-180, 180);
		//Convert theta and phi to radians
		theta = theta * (Mathf.PI / 180);
		phi = phi * (Mathf.PI / 180);

	}
	
	void Update()
	{
		if (pushingCamera)
		{
			pushCameraOut();
			if (distanceFromPlanet >= targetDistance)
			{
				pushingCamera = false;

				GUI.gameObject.SetActive(true);
				messageGUI.gameObject.SetActive(false);

			}
		}

		position.x = distanceFromPlanet*Mathf.Sin(phi)*Mathf.Cos(theta);
		position.y = distanceFromPlanet*Mathf.Sin(phi)*Mathf.Sin(theta);
		position.z = distanceFromPlanet*Mathf.Cos(phi);
		
		transform.position = position;
		transform.LookAt(target);

		phi = phi + phiSpeed;
		if (phi >= bound)
		{
			//phi = 0;
		}

		theta = theta + thetaSpeed;
		if (theta >= bound)
		{
			//phi = 0;
		}
	}

	void pushCameraOut() 
	{
		distanceFromPlanet += planetPushSpeed;
	}
	
}
