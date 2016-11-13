using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(Animator))] 

public class IKControl : MonoBehaviour {

	protected Animator animator;

	public bool ikActive = false;
	public Transform rightHandObj = null;
	public Transform lookObj = null;

	float state = 0;
	float elapsedTime = 0;
	public float timeReaction = 0.5f;

	void Start () 
	{
		animator = GetComponent<Animator>();
	}

	//a callback for calculating IK
	void OnAnimatorIK()
	{
		if(animator) {

			//if the IK is active, set the position and rotation directly to the goal. 
			if(ikActive) {


				// Set the right hand target position and rotation, if one has been assigned
				if (rightHandObj != null)
				{
					//animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
					//animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0.5f);

					if (state < 1.0f)
					{
						elapsedTime += Time.deltaTime;
						state = Mathf.Lerp(0, 1, elapsedTime / timeReaction);
					}
					else
					{
						state = 1.0f;
						elapsedTime = 0;
					}
					//print("elapsedTime:" + elapsedTime.ToString());
					//print(state);


					if (lookObj != null)
					{
						animator.SetLookAtWeight(state);
						animator.SetLookAtPosition(lookObj.position);
					}



					animator.SetIKPositionWeight(AvatarIKGoal.RightHand, state);
					animator.SetIKRotationWeight(AvatarIKGoal.RightHand, state);

					animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
					animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandObj.rotation);
				}

			}

			//if the IK is not active, set the position and rotation of the hand and head back to the original position
			else
			{
				if (state > 0f)
				{
					elapsedTime += Time.deltaTime;
					state = Mathf.Lerp(0, 1, elapsedTime / timeReaction);
					state = 1 - state;

					animator.SetIKPositionWeight(AvatarIKGoal.RightHand, state);
					animator.SetIKRotationWeight(AvatarIKGoal.RightHand, state);

					animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
					animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandObj.rotation);

				}
				else
				{
					state = 0;
					elapsedTime = 0;
					animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
					animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
					animator.SetLookAtWeight(0);

				}

			}
		}
	}
}