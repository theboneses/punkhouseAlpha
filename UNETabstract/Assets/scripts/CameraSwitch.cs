using UnityEngine;
using System.Collections;

public class CameraSwitch : MonoBehaviour {

	public float transitionDuration = 0.5f;
	public Camera currentCamera;
	public Transform target;
	public bool enableHouseCam =false;
	public bool disableMove =false;
	public bool enableStreet=false;
	public houseCamera hC;
	public cameraFNet cFN;
	public float smoove;
	public bool isroom;

	public float roomFOV;
	public float houseFOV;
	IEnumerator Transition()
	{
		

		float t = 0.0f;
		Vector3 startingPos = currentCamera.transform.position;
		while (t < 1.0f)
		{
			t += Time.deltaTime * (Time.timeScale/transitionDuration);


			currentCamera.transform.position = Vector3.Lerp(startingPos, target.position, t*smoove);

			yield return 0;
		}
		if (isroom) {
			currentCamera.fieldOfView = Mathf.Lerp (currentCamera.fieldOfView, roomFOV, t*smoove);
		} else {
			currentCamera.fieldOfView = Mathf.Lerp (currentCamera.fieldOfView, houseFOV, t*smoove);
		}
	}

	//public Camera newCamera;

	void Start () {
		hC=GameObject.FindObjectOfType<houseCamera>();
		cFN=GameObject.FindObjectOfType<cameraFNet>();
	}


	void OnTriggerExit(Collider other){

		if (enableStreet) {
			cFN.enabled = true;
		}
		if (enableHouseCam) {
			hC.enabled = true;
			//disableHouseCam = !disableHouseCam;
		} else {
			hC.enabled = false;
		}
		if (disableMove) {
			return;
		}else{
			StartCoroutine (Transition ());
		}
	}
}
