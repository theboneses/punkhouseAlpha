using UnityEngine;
using System.Collections;

public class DemoScript : MonoBehaviour {

	public UnityEngine.AI.NavMeshAgent myAgent;
	private Animator myAnimator;
	public float Zvelocity;
	public float Xvelocity;
	public float agentRotCur;
	public float agentRotLast;

	// Use this for initialization
	void Start () {
		myAnimator = GetComponent<Animator>();
		myAgent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		Zvelocity = myAgent.velocity.z;
		Xvelocity = myAgent.velocity.x;
		agentRotCur = myAgent.transform.eulerAngles.y;
		myAnimator.SetFloat ("VSpeed", Zvelocity);
		myAnimator.SetFloat ("HSpeed", Xvelocity);
		
		//if(Input.GetButtonDown ("Jump")){
			//myAnimator.SetBool ("Jumping", true);
			//Invoke ("StopJumping", 0.1f);
		//}
		
		
		if(agentRotCur - agentRotLast >10.0f){
			//transform.Rotate (Vector3.down * Time.deltaTime * 100.0f);
			//if((Input.GetAxis ("Vertical") == 0f) && (Input.GetAxis ("Horizontal") == 0)){
				myAnimator.SetBool ("TurningLeft", true);
				//agentRotLast = agentRotCur;

		} else {
			myAnimator.SetBool ("TurningLeft", false);
			//agentRotLast = agentRotCur;
		}

		
		if(agentRotCur - agentRotLast > -10.0f){
			transform.Rotate (Vector3.down * Time.deltaTime * -100.0f);
			if(myAgent.angularSpeed > 0.1f){
				myAnimator.SetBool ("TurningRight", true);
			}
		} else {
			myAnimator.SetBool ("TurningRight", false);
		}
		
		if(Input.GetKeyDown ("1")){
			if(myAnimator.GetInteger("CurrentAction") == 0){
				myAnimator.SetInteger("CurrentAction", 1);				
			} else if (myAnimator.GetInteger ("CurrentAction") == 1){
				myAnimator.SetInteger ("CurrentAction", 0);
			}
		}
		
		//if(Input.GetKeyDown ("2")){
		//	if(myAnimator.GetInteger ("CurrentAction") == 0){
		//		myAnimator.SetInteger ("CurrentAction", 2);				
		//	} else if (myAnimator.GetInteger ("CurrentAction") == 2){
		//		myAnimator.SetInteger ("CurrentAction", 0);
		//	}
		//}
		
		//if(Input.GetKeyDown ("3")){
		//	myAnimator.SetLayerWeight (1, 1f);
		//	myAnimator.SetInteger("CurrentAction", 3);
		//}
		
		if(Input.GetKeyUp ("3")){
			myAnimator.SetInteger ("CurrentAction", 0);
		}
		agentRotLast = agentRotCur;
		
	}
	
	void StopJumping(){
		myAnimator.SetBool ("Jumping", false);
	}
	
}
