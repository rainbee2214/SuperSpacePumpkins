using UnityEngine;
using System.Collections;

public class scoreDeath : MonoBehaviour 
{

	public GUIText text;
	void Start () 
	{
		text.guiText.text = "Score: " +  System.Convert.ToString(GameController.controller.Score, 2);
	}

}
