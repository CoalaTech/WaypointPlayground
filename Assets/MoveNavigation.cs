using UnityEngine;
using System.Collections;

public class MoveNavigation : MonoBehaviour
{
    public Animator animator;
    NavMeshAgent NavAgent;
    SpriteRenderer Renderer;

    Vector3 Direction = new Vector3(1.0f, 0, 0);
    Vector3 lastPosition;

    // Use this for initialization
    void Start()
    {
        lastPosition = transform.position;
        NavAgent = GetComponent<NavMeshAgent>();
        Renderer = GetComponentInChildren<SpriteRenderer>();
    }
	
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            NavAgent.updateRotation = false;
            NavAgent.SetDestination(GetMouse());
        }

        // set animation
        animator.SetBool("Walking", NavAgent.remainingDistance > 0);

        // path direction
        Direction = (transform.position - lastPosition).normalized;
        lastPosition = transform.position;

        // Flip
        Renderer.flipX = Direction.x > 0;           
    }

    Vector3 GetMouse()
    {
        var target = Input.mousePosition;
        target = Camera.main.ScreenToWorldPoint(new Vector3(target.x, target.y, 0));
        return target;
    }
}