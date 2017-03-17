using UnityEngine;
using System.Collections;

public class agentScriptCC : MonoBehaviour {

	public Animator anim;
	private UnityEngine.AI.NavMeshAgent agent;
	public enum MoveState {Idle, Walking}
	public MoveState moveState;

	// Use this for initialization
	void Start () 
	{
		agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
		//GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit))
			{
				if(hit.collider.tag == "Ground")
				{
					agent.SetDestination(hit.point);
				}
			}
		}
		if (agent.hasPath) {
			moveState = MoveState.Walking;
		} else {
			moveState = MoveState.Idle;
		}

		//send move state info to animator controller
		anim.SetInteger("MoveState", (int)moveState);	
		//anim.speed = agent.speed;
	}

	void OnAnimatorMove()
	{
		if (moveState == MoveState.Walking) 
		{
			agent.velocity = anim.deltaPosition / Time.deltaTime;

			Quaternion lookRotation = Quaternion.LookRotation (agent.desiredVelocity);
			transform.rotation = Quaternion.RotateTowards (transform.rotation, lookRotation, agent.angularSpeed * Time.deltaTime);
		}
	}
}