using UnityEngine;
using System.Collections;

public class ActivateTextByLine : MonoBehaviour {

	public TextAsset theText;
	public int startLine;
	public int endLine;
	public TextBoxmanager theTextBox;
	public bool DestroyWhenActviated;
	//public GUIText speechBubs;

	// Use this for initialization
	void Start () {
		theTextBox = FindObjectOfType<TextBoxmanager> ();
		//speechBubs = FindObjectOfType<GUIText> ();
	}
	
	// Update is called once per frame
	void Update () {
		//speechBubs.text = theTextBox.textlines[1];
	}
	void OnTriggerEnter(Collider other){
	if (other.tag == "Player") {
			theTextBox.ReloadScript(theText);
			theTextBox.currentLine = startLine;
			theTextBox.endAtLine = endLine;
			theTextBox.EnableTextBox();
			if(DestroyWhenActviated == true){
				Destroy(gameObject);
			}

		}
	}

}
