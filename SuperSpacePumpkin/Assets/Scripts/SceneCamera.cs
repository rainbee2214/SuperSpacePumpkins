using UnityEngine;
using System.Collections;

public class SceneCamera : MonoBehaviour 
{
	public float radius;
	public float phi;
	public float theta;
	public float phiSpeed;
	public float thetaSpeed;
	public float bound = 3f;

	public GameObject messageGUI;
	public GameObject messageGUI2;

	Vector3 origin;
	Vector3 position;

	public Transform planet;
	public Transform king;

	public Material[] boxes;


	string[] messages;
	string[] messages2;

	float startingTime;
	public Color[] colors;
	void Start()
	{
		startingTime = Time.time;
		origin = transform.position;
		//position = origin;
		messages = new string[4]{
			"alien message", 
			"alien message 2",
			"alien message 3",
			"kill all humans!"
		};

		messages2 = new string[3]{
			"alien message ", 
			"alien message 2",
			"alien message 3"
		};

		messageGUI.gameObject.guiText.text = messages[0];
		messageGUI.gameObject.SetActive(true);
		messageGUI.guiText.color = colors[0];
		messageGUI2.guiText.color = colors[1];
		messageGUI2.gameObject.guiText.text = "";
		messageGUI2.gameObject.SetActive(true);

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
		if (Time.time < 19f + startingTime)
		{
			phi = phi + phiSpeed;
			
			position.x = radius*Mathf.Sin(phi)*Mathf.Cos(theta);
			position.y = radius*Mathf.Sin(phi)*Mathf.Sin(theta);
			position.z = radius*Mathf.Cos(phi);
			
			transform.position = position;
			transform.LookAt(planet);
			if (Time.time > 1.5f)
			{
				messageGUI2.gameObject.guiText.text = messages2[0];
			}
			if (Time.time > 5.5f + startingTime)
			{
				messageGUI.guiText.color = colors[2];
				messageGUI2.guiText.color = colors[3];
				messageGUI2.gameObject.guiText.text = "";
				messageGUI.gameObject.guiText.text = messages[1];
				if (Time.time > 7f + startingTime)
				messageGUI2.gameObject.guiText.text = messages2[1];
			}
			if (Time.time > 11f + startingTime)
			{
				messageGUI.guiText.color = colors[4];
				messageGUI2.guiText.color = colors[5];
				messageGUI2.gameObject.guiText.text = "";
				messageGUI.gameObject.guiText.text = messages[2];
				if (Time.time > 12.5f + startingTime)
				messageGUI2.gameObject.guiText.text = messages2[2];
				
			}
			if (Time.time > 17.25f + startingTime)
			{
				messageGUI.guiText.color = colors[6];
				Vector3 currentPosition = messageGUI.transform.position;
				currentPosition.y = 0.5f;

				messageGUI.transform.position = currentPosition;
				messageGUI.gameObject.guiText.text = messages[3];
				messageGUI2.gameObject.guiText.text = "";
			}

		}
		else
		{
			messageGUI.gameObject.guiText.text = "";
			transform.position = new Vector3(0,0,0);
			transform.LookAt(king);
		}

		if (Time.time > 20 + startingTime)
		{
			Application.LoadLevel("Boss");
		}
	}
	
}
