using UnityEngine;
using System.Collections;

public class roomdoor : MonoBehaviour {

	public float transitionDuration = 0.5f;
	public Camera currentCamera;
	public Transform target;

	private houseCamera hC;
	private cameraFNet cFN;

	public float smoove;
	public float roomFOV;
	public float houseFOV;

	IEnumerator Transition()
	{
		float t = 0.0f;
		Vector3 startingPos = currentCamera.transform.position;
		while (t < 1.0f)
		{
			t += Time.deltaTime;

			currentCamera.transform.position = Vector3.Lerp(startingPos, target.position, t*smoove);

			yield return 0;
		}
	}


	void OnTriggerExit(Collider other){
		currentCamera = other.GetComponentInChildren<Camera> ();
		hC = other.GetComponentInChildren<houseCamera> ();
		cFN = other.GetComponentInChildren<cameraFNet> ();
		StartCoroutine (Transition ());
		cFN.enabled = !cFN.enabled;
		hC.enabled = !hC.enabled;
		}
	}

