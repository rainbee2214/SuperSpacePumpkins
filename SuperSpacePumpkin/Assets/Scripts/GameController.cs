﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{

	//Static reference to the GameController class
	public static GameController controller;

	public GameObject[] explosions;
	public int pool;
	public bool toggleLevel = false;

	#region Properties
	private int score;
	public int Score
	{
		get{return score;}
		set{score += value;}
	}

	private int planetHealth = 100;
	public int PlanetHealth
	{
		get{return planetHealth;}
		set{planetHealth += value;}
	}

	private bool dead;
	public bool Dead
	{
		get{return dead;}
		set{dead = value;}
	}

	private int level;
	public int Level
	{
		get{return level;}
		set{level += value;}
	}

	private int pumpkinSpeed = 3;
	public int PumpkinSpeed
	{
		get {return pumpkinSpeed;}
		set {pumpkinSpeed += value;}
	}
	#endregion

	void Awake () 
	{
		//if control is not set, set it to this one and allow it to persist
		if (controller == null)
		{
			DontDestroyOnLoad(gameObject);
			controller = this;
		}
		//else if control exists and it isn't this instance, destroy this instance
		else if(controller != this)
		{
			Debug.Log ("Game control already exists, deleting this new one");
			Destroy (gameObject);
		}
	}

	void Start () 
	{

	}

	void Update () 
	{
		if((score >= (Mathf.Pow(2, level))) && !dead)
		{
			LevelUp();
		}
		if (toggleLevel)
		{
			LevelUp();
			toggleLevel = false;
		}
		if (planetHealth <= 0)
			dead = true;

		if (dead)
		{
			Application.LoadLevel("Death");
			dead = false;
			pumpkinSpeed = 3;
			level = 0;
			score = 0;
			planetHealth = 100;
		}

		if (Application.loadedLevelName == "Menu") 
		{
			score = 0;
			planetHealth = 100;
		}
	}

	public void Explode(string name, Vector3 position)
	{
		GameObject explosion;
		switch(name)
		{
		case "Planet":
			explosion = Instantiate(explosions[0], position, Quaternion.identity) as GameObject;
			break;
		case "Plane":
			explosion = Instantiate(explosions[1], position, Quaternion.identity) as GameObject;
			break;
		default:
			explosion = Instantiate(explosions[0], position, Quaternion.identity) as GameObject;
			break;
		}
		//explosion.transform.position = position;
		explosion.gameObject.particleSystem.Play();
	}

	public void LevelUp() 
	{
		pumpkinSpeed += 2;
		level++;
		if (level > 5)
		{
			//Go to boss scene
		}
		if (Application.loadedLevelName != "Death")
		{
			Camera.main.camera.GetComponent<CameraPosition>().distanceFromPlanet += 4;
		}
	}
}
