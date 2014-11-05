using UnityEngine;
using System.Collections;

public class DisplaySequence : MonoBehaviour 
{
	public GUIText guiElement;
	public string[] guiTextMessages;
	public Color[] colors;
	public int startingColorIndex;
	public float betweenDelay;
	[Range(0.0f, 1.0f)]
	public float xPosition;
	[Range(0.0f, 1.0f)]
	public float yPosition;
	
	public bool turnOnOff = true;
	public bool displayOnlyOne = false;
	public bool loopMessages = false;
	public bool randomize = false;
	public bool randomizeColors = true;

	Vector2 displayPosition;
	int currentlyDisplayed;
	float startTime;
	float lastDisplayTime;
	float nextDisplayTime = 0;

	int currentColor;
	

	void Start()
	{ 
		displayPosition.x = xPosition;
		displayPosition.y = yPosition;
		startTime = Time.time;
		lastDisplayTime = startTime;
		nextDisplayTime = startTime + betweenDelay;
		currentlyDisplayed = 0;
		if (randomize) currentlyDisplayed = Random.Range (0, guiTextMessages.Length);

		if(displayOnlyOne)
		{
			guiElement.gameObject.guiText.text = guiTextMessages[currentlyDisplayed];
		}

		guiElement.gameObject.transform.position = displayPosition;

		currentColor = randomizeColors ? Random.Range (0, colors.Length) : startingColorIndex;
		guiElement.gameObject.guiText.color = colors[currentColor];
	}

	void Update()
	{
		guiElement.gameObject.SetActive(turnOnOff);
		guiElement.gameObject.transform.position = displayPosition;
		if ((Time.time > nextDisplayTime) && currentlyDisplayed < guiTextMessages.Length && !displayOnlyOne)
		{
			if (randomize) DisplayRandomGui(); 
			else DisplayGui();
			lastDisplayTime = Time.time;
			nextDisplayTime = lastDisplayTime + betweenDelay;
		}

		displayPosition.x = xPosition;
		displayPosition.y = yPosition;
		guiElement.gameObject.transform.position = displayPosition;
	}

	void DisplayGui()
	{
		if (randomizeColors) guiElement.gameObject.guiText.color = colors[Random.Range (0, colors.Length)];
		guiElement.gameObject.guiText.text = guiTextMessages[currentlyDisplayed];
		currentlyDisplayed++;
		if (currentlyDisplayed >= guiTextMessages.Length) 
		{
			currentlyDisplayed = loopMessages ? 0 : guiTextMessages.Length - 1;
			randomizeColors = false;
		}
	}

	void DisplayRandomGui()
	{
		currentlyDisplayed = Random.Range (0, guiTextMessages.Length);
		guiElement.gameObject.guiText.text = guiTextMessages[currentlyDisplayed];
	}
}
