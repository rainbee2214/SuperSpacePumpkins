using UnityEngine;
using System.Collections;

/*
 * Music tracks from : https://www.jamendo.com/en/artist/438921/demonic-sweaters (demonicsweaters.tumblr.com)
 * Music tracks made from NASA (https://soundcloud.com/nasa)
 * And also : http://brackeys.com/
 */

public class DisableSound : MonoBehaviour 
{
	public bool play = true;
	AudioSource[] allAudios;
	Color startingColor;

	void Start()
	{
		allAudios = Camera.main.gameObject.GetComponents<AudioSource>();
		allAudios[0].Play();
		startingColor = gameObject.guiTexture.color;
	}
	void Update () 
	{
		if (gameObject.guiTexture.HitTest(Input.mousePosition) && (Input.GetMouseButtonDown(0)))
		{
			play = !play;
		}

		//Weird issue here where the camera speed is slower without music playing...
		if (!play) // I feel like this should be if (play) however, that doesn't work logically. But !play does... when play is true the music plays and when play is false it stops (by clicking on the button in the corner)
		{
			allAudios[0].Play(); //Background
			gameObject.guiTexture.color = Color.white;
		}
		else
		{
			gameObject.guiTexture.color = startingColor;
		}
	}
}
