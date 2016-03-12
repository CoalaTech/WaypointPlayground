using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Waypoint : MonoBehaviour
{
	public List<Waypoint> Children;

	// Use this for initialization
	void Start ()
	{
		Children = GetComponentsInChildren<Waypoint> (true).ToList ();
		Children.Remove (this); // because Unity3d add parent
	}

	public Vector3 FindNearest (Vector3 agent)
	{
		if (Children.Count () == 0)
			return transform.position;

		var current = transform.position;
		foreach (var waypoint in Children) {
			var nearest = waypoint.FindNearest (agent);
			if ((nearest - agent).magnitude > (current - agent).magnitude)
				current = nearest;
		}
		return current;
	}

	void OnDrawGizmos ()
	{
		foreach (var item in Children) {
			Gizmos.color = Color.red;
			Gizmos.DrawLine (transform.position, item.transform.position);
		}
	}

}
