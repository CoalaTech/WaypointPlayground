using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Waypoint : MonoBehaviour
{
	public List<Waypoint> Children;

	public Vector3 Point {
		get {
			return transform.position;
		}
		set {
			transform.position.Set (value.x, value.y, value.z);
		}
	}

	// Use this for initialization
	void Start ()
	{
		Children = GetComponentsInChildren<Waypoint> ().ToList ();
	}


	void OnDrawGizmos ()
	{
		foreach (var item in Children) {
			Gizmos.color = Color.red;
			Gizmos.DrawLine (transform.position, item.Point);
		}
	}

}
