using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class SphereTester : MonoBehaviour {
	
	public int subdivisions = 0;
	
	public float radius = 1f;

	void Start () 
	{

	}

	private void Awake () 
	{
		GetComponent<MeshFilter>().mesh = SphereGenerator.Create(subdivisions, radius);
	}

	void Update()
	{
	}
}