using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Grid : MonoBehaviour
{
	public Agent AgentInstance;
	public List<Waypoint> Waypoints;

	Vector3 Target;

	// Use this for initialization
	void Start ()
	{
		Waypoints = GetComponentsInChildren<Waypoint> ().ToList ();
		Debug.Assert (AgentInstance != null, "Agent is null", AgentInstance);
		if (AgentInstance == null)
			Target = Vector3.zero;
		else
			Target = AgentInstance.transform.position;
	}

	void Update ()
	{
		if (Input.GetMouseButton (0)) {
			Target = FindNearest ();
			Debug.ClearDeveloperConsole ();
			Debug.Log (Target);
		}
		if (AgentInstance != null)
			AgentInstance.transform.position = Vector3.MoveTowards (AgentInstance.transform.position, Target, 2.0f * Time.deltaTime);
	}

	Vector3 FindNearest ()
	{
		if (Waypoints.Count () == 0) {
			Debug.LogWarning ("No Waypoints");
			return Target;
		}
		var mouse = GetMouse ();
		var current = Vector3.zero;
		foreach (var waypoint in Waypoints) {
			var nearest = waypoint.FindNearest (mouse);
			if ((nearest - mouse).magnitude > (current - mouse).magnitude) {
				current = nearest;

			}
		}

		return current;
	}

	Vector3 GetMouse ()
	{
		var target = Input.mousePosition;
		target = Camera.main.ScreenToWorldPoint (new Vector3 (target.x, target.y, 0));
		return target;
	}

	void OnDrawGizmos ()
	{
		foreach (var item in Waypoints) {
			Gizmos.color = Color.red;
			Gizmos.DrawLine (transform.position, item.transform.position);
		}
	}
}
