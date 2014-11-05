using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour 
{
	public GameObject bullet;
	public int poolCount = 40;
	GameObject[] bullets;
	Vector3 outOfView;

	public GameObject laserPrefab;
	public GUIText laserGUI;
	public int numOfLaser = 3;
	int laserCount;
	GameObject laser;
	bool isLaserOn = false;
	
	int bulletCount = 0;

	public bool bossScene;

	public float bulletSpeed = 1f;
	
	public float shootDelay = 3f;
	public float lastShootTime = 0f;
	public float lifespan = 10f;
	public float laserLifespan = 10f;
	void Start()
	{
		laserCount = numOfLaser;
		laserGUI.guiText.text = "...";
		if (Application.loadedLevelName == "Boss") bossScene = true;
		outOfView = new Vector3(-1000, -1000, 0);
		// Instantiate bullets
		bullets = new GameObject[poolCount];
		for (int i = 0; i < poolCount; i++)
		{
			bullets[i] = Instantiate(bullet, outOfView, Quaternion.identity) as GameObject;
			bullets[i].name = "Bullet" + (i + 1);
			if (bossScene) bullets[i].GetComponent<BulletController>().forward = -1;
			bullets[i].SetActive(false);
		}

		// Instantiate laser
		laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
		laser.SetActive(false);
		laser.transform.position += new Vector3(0f, 0f, bossScene ? 3f : -3f);
		laser.transform.parent = transform;
	} 
	
	void Update ()
	{
		if (Input.GetButton("Fire") && Time.time > lastShootTime + shootDelay)
		{
			lastShootTime = Time.time;
			ShootBullet();
		}

		if (Input.GetButtonDown("Laser"))
		{
			if (!isLaserOn && laserCount > 0) ActivateLaser();
		}
	}

	void ActivateLaser()
	{
		isLaserOn = true;
		laserCount--;
		if (laserCount == 2) { laserGUI.guiText.text = "..";}
		else if (laserCount == 1) { laserGUI.guiText.text = ".";}
		else if (laserCount <= 0) { laserGUI.guiText.text = "";}
		laser.SetActive(true);
		Invoke("DeactivateLaser", laserLifespan);
	}

	void DeactivateLaser()
	{
		isLaserOn = false;
		laser.SetActive(false);
	}
	
	void ShootBullet()
	{
		//Move bullet to position and rotation
		bullets[bulletCount].transform.position = transform.position;
		bullets[bulletCount].transform.rotation = transform.rotation;
		//Activate bullet
		bullets[bulletCount].SetActive(true);
		//Increment bulletCount
		bulletCount++;
		if (bulletCount >= poolCount - 1) bulletCount = 0;
	}
}
