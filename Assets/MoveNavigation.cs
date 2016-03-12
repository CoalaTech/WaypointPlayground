using UnityEngine;
using System.Collections;

public class MoveNavigation : MonoBehaviour
{
	public Animator animator;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButton (0)) {
			NavMeshAgent agent = GetComponent<NavMeshAgent> ();
			agent.updateRotation = false;
			agent.destination = GetMouse ();
		}
	}

	Vector3 GetMouse ()
	{
		var target = Input.mousePosition;
		target = Camera.main.ScreenToWorldPoint (new Vector3 (target.x, target.y, 0));
		return target;
	}
}
