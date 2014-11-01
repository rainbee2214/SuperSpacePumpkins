using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class SphereTester : MonoBehaviour {
	
	public int subdivisions = 0;
	
	public float radius = 1f;

	public GameObject planetsplosion;
	GameObject explosion;
	Vector3 outOfView;

	void Start () 
	{
		explosion = Instantiate (planetsplosion, new Vector3(100,100,0), Quaternion.identity) as GameObject;
		outOfView = new Vector3(1000, 1000, 0);
	}

	private void Awake () 
	{
		GetComponent<MeshFilter>().mesh = SphereGenerator.Create(subdivisions, radius);
	}

	void Update()
	{
		//Debug.Log(GameController.controller.PlanetHealth);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Pumpkin")
		{
			GameController.controller.PlanetHealth = -5;
			explosion.transform.position = gameObject.transform.position;
			explosion.gameObject.particleSystem.Play();
			
			//Destroy(other.gameObject);
			
		}
	}

}