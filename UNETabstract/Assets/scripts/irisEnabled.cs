using UnityEngine;
using System.Collections;

public class irisEnabled : MonoBehaviour {

	public GameObject house;
	public Material originalTex;
	public Material replacementTex;
	public Renderer[] rens;

	void Awake(){
		rens = house.GetComponentsInChildren<Renderer> ();
		foreach(Renderer ren in rens){
			ren.enabled = true;
		}
	}

	void OnTriggerEnter(Collider other){
		foreach (Renderer ren in rens) {
			ren.material = replacementTex;
		}
	}

}
