using UnityEngine;
using System.Collections;

public class scoreDeath : MonoBehaviour {

	public GUIText text;
	// Use this for initialization
	void Start () {
		text.guiText.text = "Score: " +  System.Convert.ToString(GameController.controller.Score, 2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
