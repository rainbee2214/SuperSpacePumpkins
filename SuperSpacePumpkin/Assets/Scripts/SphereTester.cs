using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class SphereTester : MonoBehaviour {
	
	public int subdivisions = 0;
	
	public float radius = 1f;
	
	private void Awake () {
		GetComponent<MeshFilter>().mesh = SphereGenerator.Create(subdivisions, radius);
	}
}