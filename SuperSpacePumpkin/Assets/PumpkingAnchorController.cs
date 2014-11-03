using UnityEngine;
using System.Collections;

public class PumpkingAnchorController : MonoBehaviour 
{
	public Transform target;
	
	void Update () 
	{
		transform.LookAt(target);
	}
}
