using UnityEngine;
using System.Collections;

public class cameraFNet : MonoBehaviour {

	public Camera currentCamera;
	public GameObject target;
	public Vector3 offset;
	public int smoove;

	void Start(){
		//LPlayer = GameObject.FindGameObjectWithTag ("Player");
	}
	// Update is called once per frame
	void Update () 
	{
		currentCamera.transform.position = Vector3.Lerp(currentCamera.transform.position, target.transform.position+offset, Time.deltaTime*smoove);
}
}