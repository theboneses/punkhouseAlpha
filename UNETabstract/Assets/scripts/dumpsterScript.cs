using UnityEngine;
using System.Collections;

public class dumpsterScript : MonoBehaviour {

	public bool isOpenable = false;
	public bool isOpen = false;

	public GameObject lid;
	public GameObject lidTo;
	public GameObject lidFrom;
	public float t;


	// Use this for initialization
	void Start () {
		lid = GameObject.Find ("Plane");
		lidTo= GameObject.Find ("to");
		lidFrom= GameObject.Find ("from");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && isOpenable) {
			lid.transform.rotation = Quaternion.Lerp (lid.transform.rotation,lidTo.transform.rotation,t);
			isOpen = true;
		}else{
		//just let go of space
			if(Input.GetKeyDown(KeyCode.Space) && isOpen){
				lid.transform.rotation = Quaternion.Lerp (lid.transform.rotation, lidFrom.transform.rotation, t);
			}
		}
	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			isOpenable = true;

		}
	}
	void OnTriggerExit(Collider other){
		if (other.tag == "Player") {
			isOpenable = false;

		}
	}

}
