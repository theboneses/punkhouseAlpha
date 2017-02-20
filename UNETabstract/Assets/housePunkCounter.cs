using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class housePunkCounter : MonoBehaviour {

	public List<GameObject> occupants;
	private houseCamera hC;



	// Use this for initialization
	void Start () {
	
	}
	void OnTriggerStay(Collider others){
		if (others.tag == "Player") {
			if(!occupants.Contains(others.gameObject)){
				occupants.Add (others.gameObject);
			}
		}
		hC = others.GetComponentInChildren<houseCamera> ();
		hC.players = occupants;
	}
	void OnTriggerExit(Collider other){
		if (other.tag == "Player") {
			if (occupants.Contains (other.gameObject)) {
				occupants.Remove (other.gameObject);
			}
		}
	}
}
