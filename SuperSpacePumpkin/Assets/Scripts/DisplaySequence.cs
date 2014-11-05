using UnityEngine;
using System.Collections;

public class DisplaySequence : MonoBehaviour 
{
	public GUIText guiTextMessage;
	//public string[] guiTextMessages;
	string[] guiTextMessages;
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
	public float turnOffAfter;

	Vector2 displayPosition;
	int currentlyDisplayed;
	float startTime;
	float lastDisplayTime;
	float nextDisplayTime = 0;

	int currentColor;
	bool turnOff;

	void Start()
	{ 
		startTime = Time.time;
		if (turnOffAfter != -1) 
		{
			turnOffAfter = turnOffAfter + startTime;
			turnOff = true;
		}
		guiTextMessages = SetMessages();
		displayPosition.x = xPosition;
		displayPosition.y = yPosition;
		lastDisplayTime = startTime;
		nextDisplayTime = startTime + betweenDelay;
		currentlyDisplayed = 0;
		if (randomize) currentlyDisplayed = Random.Range (0, guiTextMessages.Length);

		guiTextMessage.gameObject.transform.position = displayPosition;

		currentColor = randomizeColors ? Random.Range (0, colors.Length) : startingColorIndex;
		guiTextMessage.gameObject.guiText.color = colors[currentColor];
		guiTextMessage.gameObject.guiText.text = guiTextMessages[currentlyDisplayed];
	}

	void Update()
	{
		if (turnOff && Time.time > turnOffAfter)
		{
			turnOnOff = false;
			turnOff = false;
		}
		else
		{
			if ((Time.time > nextDisplayTime) && currentlyDisplayed < guiTextMessages.Length && !displayOnlyOne)
			{
				if (randomize) DisplayRandomGui(); 
				else DisplayGui();
				lastDisplayTime = Time.time;
				nextDisplayTime = lastDisplayTime + betweenDelay;
			}
		}

		guiTextMessage.gameObject.SetActive(turnOnOff);
		guiTextMessage.gameObject.transform.position = displayPosition;

		displayPosition.x = xPosition;
		displayPosition.y = yPosition;
		guiTextMessage.gameObject.transform.position = displayPosition;
	}

	void DisplayGui()
	{
		currentlyDisplayed++;
		if (currentlyDisplayed >= guiTextMessages.Length) 
		{
			currentlyDisplayed = loopMessages ? 0 : guiTextMessages.Length - 1;
			randomizeColors = false;
		}
		if (randomizeColors) guiTextMessage.gameObject.guiText.color = colors[Random.Range (0, colors.Length)];
		guiTextMessage.gameObject.guiText.text = guiTextMessages[currentlyDisplayed];
	}

	void DisplayRandomGui()
	{
		currentlyDisplayed = Random.Range (0, guiTextMessages.Length);
		guiTextMessage.gameObject.guiText.text = guiTextMessages[currentlyDisplayed];
	}

	string[] SetMessages()
	{
		if (Application.loadedLevelName == "Tutorial")
		{
			string[] messages = {
				"move with arrow keys or WASD!",
				"shoot with space or e!",
				"activate laser with z or q!",
				"return to the menu with m!",
				"keep your shield centered!"
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
		else if (Application.loadedLevelName == "Level")
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
		else
		{
			string[] messages = {
				"No messages!"
			};
			return messages;
		}
	}
}
