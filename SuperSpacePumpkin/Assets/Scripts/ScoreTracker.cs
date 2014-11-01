using UnityEngine;
using System.Collections;

public class ScoreTracker : MonoBehaviour 
{
	private int currentScoreDecimal = 0;
	private string currentScoreBinary = "0";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameController.controller.Score > currentScoreDecimal)
		{
			currentScoreDecimal = GameController.controller.Score;
			currentScoreBinary = System.Convert.ToString(currentScoreDecimal, 2);
			gameObject.guiText.text = "Score: " + currentScoreBinary;
		}

	}
}
