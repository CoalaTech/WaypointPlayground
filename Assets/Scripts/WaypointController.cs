using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaypointController : MonoBehaviour
{
	public Agent AgentInstance;
	public List<Waypoint> WayPoints;

	// Use this for initialization
	void Start ()
	{
		WayPoints = new List<Waypoint> ();
		Debug.Assert (AgentInstance != null, "Agent is null", AgentInstance);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
