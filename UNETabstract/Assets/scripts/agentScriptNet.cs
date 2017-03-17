using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class agentScriptNet : NetworkBehaviour {

	public Animator anim;
	private UnityEngine.AI.NavMeshAgent agent;
	public enum MoveState {Idle, Walking}
	public MoveState moveState;

	// Use this for initialization
	void Start () 
	{
		agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
		//GetComponent<NavMeshAgent>();
		anim = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!isLocalPlayer)
		{
			return;
		}

		if(Input.GetMouseButtonDown(0))
		{
			if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) return;
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