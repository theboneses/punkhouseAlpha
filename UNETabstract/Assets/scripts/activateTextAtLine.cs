using UnityEngine;
using System.Collections;

public class activateTextAtLine : MonoBehaviour {

	public TextAsset newText;
	public int startLine;
	public int endLine;

	public bool DestroyWhenActivated;
	public textboxmgr newie;
	 
	// Use this for initialization
	void Start () {
		newie = FindObjectOfType<textboxmgr>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			Debug.Log ("yup thats the player");
			newie.ReloadScript(newText);
			Debug.Log ("file loaded");
			newie.currentLine = startLine;
			newie.endAtLine = endLine;
			newie.EnableTextBox ();
			if (DestroyWhenActivated) {
				Destroy (gameObject);
			}
			gameControl.control.Save ();
		}

	}
}
