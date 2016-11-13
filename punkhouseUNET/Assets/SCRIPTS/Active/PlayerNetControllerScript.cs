using UnityEngine;
using System.Collections;

public class PlayerNetControllerScript : MonoBehaviour {
	//serialize these later
	private Animator myAnimator;
	public float directionSpeed;
	public float rotationDegreePerSecond = 120f;
	public Camera gamecam;
	private AnimatorStateInfo stateInfo;
	public float horizontal;
	public float vertical;
	public float speed = 0.0f;
	public float direction = 0.0f;
	//public float directionDampTime = 0.25f;
	public float charAngle = 0.0f;
	public int m_LocomotionId = 0;
	public int m_LocoPivotR = 0;
	public int m_LocoPivotL = 0;
	public float LocomotionThreshold { get { return 0.2f; } }
	public bool isPickable = false;

	// Use this for initialization
	void Start () {
		myAnimator = GetComponent<Animator> ();
		if(myAnimator.layerCount >= 2)
		{
			myAnimator.SetLayerWeight(1, 1);
		}		

		m_LocomotionId = Animator.StringToHash ("BaseLayer.Locomotion");
		m_LocoPivotR = Animator.StringToHash ("BaseLayer.locoPvtR");
		m_LocoPivotL = Animator.StringToHash ("BaseLayer.locoPvtL");

	}
	
	// Update is called once per frame
	void Update () {
		if (gamecam==null) 
		{
			gamecam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		}
		stateInfo = myAnimator.GetCurrentAnimatorStateInfo(0);
		horizontal = Input.GetAxis ("Horizontal");
		vertical = Input.GetAxis ("Vertical");

		speed = horizontal * horizontal + vertical * vertical;

		charAngle = 0f;
		direction = 0f;

		StickToWorldSpace (this.transform, gamecam.transform, ref direction, ref speed, ref charAngle, IsInPivot());

		myAnimator.SetFloat ("speed", speed);
		myAnimator.SetFloat ("direction", direction);

		if (speed > LocomotionThreshold) 
		{
			if (!IsInPivot ()) {
				myAnimator.SetFloat ("angle", charAngle);
			}
		}
		if (speed < LocomotionThreshold && Mathf.Abs(horizontal)<0.05f) 
		{
			myAnimator.SetFloat ("direction", 0);
			myAnimator.SetFloat ("angle", 0);

		}



	}
	void FixedUpdate()
	{

		if (IsInLocomotion () && ((direction >= 0 && horizontal >= 0) || (direction < 0 && horizontal < 0))) 
		{
			Vector3 rotationAmount = Vector3.Lerp(Vector3.zero,new Vector3(0f,rotationDegreePerSecond * (horizontal < 0f ? -1f:1f),0f),Mathf.Abs(horizontal));
			Quaternion deltaRotation = Quaternion.Euler (rotationAmount * Time.deltaTime);
			
			this.transform.rotation = (this.transform.rotation * deltaRotation);

		}
		if (isPickable) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				myAnimator.SetInteger ("isPickable",1);
				myAnimator.SetInteger ("currentAction",3);
				myAnimator.SetLayerWeight (1, 1f);
			}
			if (Input.GetKeyUp (KeyCode.Space)) {
				myAnimator.SetLayerWeight (1, 0f);
				myAnimator.SetInteger ("currentAction",0);
			}
				else{
				myAnimator.SetInteger ("isPickable",0);
				//myAnimator.SetLayerWeight (1, 0f);
			}

		}
	}
	public void StickToWorldSpace(Transform root, Transform camera, ref float directionOut, ref float speedOut, ref float angleOut, bool isPivoting)
	{
		Vector3 rootDirection = root.forward;

		Vector3 stickDirection = new Vector3 (horizontal, 0, vertical);

		speedOut = stickDirection.sqrMagnitude;
	
		//Get camera dir
		Vector3 cameraDirection = camera.forward;
		cameraDirection.y = 0.0f;
		Quaternion referentialShift = Quaternion.FromToRotation (Vector3.forward, cameraDirection);

		//Convert stick position to worldSpace coords
		Vector3 moveDirection = referentialShift*stickDirection;
		Vector3 axisSign = Vector3.Cross (moveDirection,rootDirection);
	
		Debug.DrawRay (new Vector3 (root.position.x,root.position.y+2f,root.transform.position.z), moveDirection, Color.green);
		Debug.DrawRay (new Vector3 (root.position.x,root.position.y+2f,root.transform.position.z), axisSign, Color.magenta);
		Debug.DrawRay (new Vector3 (root.position.x,root.position.y,root.transform.position.z), rootDirection, Color.yellow);
		Debug.DrawRay (new Vector3 (root.position.x,root.position.y+2f,root.transform.position.z), stickDirection, Color.blue);
	//
		float angleRootToMove = Vector3.Angle (rootDirection, moveDirection) * (axisSign.y >= 0 ? -1f : 1f);
		float angleLocalRootToMove = Vector3.Angle(rootDirection,stickDirection);
		if(!isPivoting)
		{
			angleOut = angleLocalRootToMove;
		}
		angleRootToMove /= 180f;
		directionOut = angleRootToMove * directionSpeed;
	}
	public void OnTriggerStay(Collider other)
	{
		if (other.tag == "item") 
		{
			isPickable = true;
		}
	}
	public void OnTriggerExit(Collider other)
	{
		if (other.tag == "item") 
		{
			isPickable = false;
		}
	}
	public bool IsInPivot()
	{
		return ((stateInfo.fullPathHash == m_LocoPivotL) || (stateInfo.fullPathHash == m_LocoPivotR));
	}
	public bool IsInLocomotion()
	{
		return stateInfo.fullPathHash == m_LocomotionId;
	}
}
