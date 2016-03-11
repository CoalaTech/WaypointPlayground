using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Grid : MonoBehaviour
{
	public List<Waypoint> Waypoints;

	// Use this for initialization
	void Start ()
	{
		Waypoints = GetComponentsInChildren<Waypoint> ().ToList ();
	}


	void OnDrawGizmos ()
	{
		foreach (var item in Waypoints) {
			Gizmos.color = Color.red;
			Gizmos.DrawLine (transform.position, item.Point);
		}
	}
}
