using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour 
{
	public GameObject bullet;
	public int poolCount = 40;
	GameObject[] bullets;
	Vector3 outOfView;

	public GameObject laserPrefab;
	GameObject laser;
	bool isLaserOn = false;
	
	int bulletCount = 0;

	public float bulletSpeed = 1f;
	
	public float shootDelay = 3f;
	public float lastShootTime = 0f;
	public float lifespan = 10f;
	public float laserLifespan = 10f;
	void Start()
	{
		outOfView = new Vector3(-1000, -1000, 0);
		// Instantiate bullets
		bullets = new GameObject[poolCount];
		for (int i = 0; i < poolCount; i++)
		{
			bullets[i] = Instantiate(bullet, outOfView, Quaternion.identity) as GameObject;
			bullets[i].name = "Bullet" + (i + 1);
			bullets[i].SetActive(false);
		}

		// Instantiate laser
		laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
		laser.SetActive(false);
		laser.transform.position += new Vector3(0f, 0f, 6f);
		laser.transform.parent = transform;
	}
	
	void Update ()
	{
		if (Input.GetButtonDown("Fire") && Time.time > lastShootTime + shootDelay)
		{
			lastShootTime = Time.time;
			ShootBullet();
		}

		if (Input.GetButtonDown("Laser"))
		{
			if (!isLaserOn) ActivateLaser();
		}
	}

	void ActivateLaser()
	{
		isLaserOn = true;
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
