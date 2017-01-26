using UnityEngine;
using System.Collections;

public class itemCollision : MonoBehaviour {

	public bool isPickable;
	public GameObject pickMe;
	public float pushPower = 1.5F;
	public GameObject[] picks;
	public FixedJoint fj;

	void Start(){
		fj = GetComponent<FixedJoint> ();
	}

	void Update () {
		//if youve got an item loaded for picking
		if (pickMe) {
			//and if item is pickable...and if space is hit
			if (Input.GetKey (KeyCode.Space) && isPickable) {
				//set item as a hinged child
				fj.connectedBody = pickMe.GetComponent<Rigidbody>();
			//else clear hinge
			} else {
				fj.connectedBody = null;
			}
		//if something went wrong and we cant unparent
		}else{
			//just let go of space
			if(Input.GetKeyUp(KeyCode.Space)){
				//to clear the hinge
				fj.connectedBody = null;
			}
		}
	}
	//kicks stuff you run into
	void OnControllerColliderHit(ControllerColliderHit hit) {
		Rigidbody body = hit.collider.attachedRigidbody;
		if (body == null || body.isKinematic)
			return;

		if (hit.moveDirection.y < -0.3F)
			return;

		Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
		body.velocity = pushDir * pushPower;
	}
	//flags something as pickable and readys it for picking
	void OnTriggerStay(Collider other){
		if (other.tag == "item") {
			isPickable = true;
			pickMe = other.gameObject;
		}
	}
	//disables pickable flags && stands item down from picking
	void OnTriggerExit(Collider other){
		if (other.tag == "item") {
			isPickable = false;
			pickMe = null;
		}
	}
}
