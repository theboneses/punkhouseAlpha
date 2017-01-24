using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//using UnityEngine.Networking;
public class textboxmgr : MonoBehaviour {

	public static textboxmgr TBMgr;
	public GameObject textBox;
	public Text theText;
	public TextAsset textFile;
	public string[] textLines;

	public bool isActive;
	public bool stopPlayerMovement;

	public char[] lineBreak = {'\n'};
	public int currentLine;
	public int endAtLine;

	//public

	// Use this for initialization
	void Start () {
		
		if (textFile != null) {
			textLines = (textFile.text.Split (lineBreak,System.StringSplitOptions.None));
		}
		if (endAtLine == 0) {
		
			endAtLine = textLines.Length-1;
		}
		if (isActive) {
			EnableTextBox ();
		} else {
			DisableTextBox ();
		}
	}
	
	// Update is called once per frame
	void Update () {

		if(!isActive){
			return;
		}
		
		theText.text = textLines[currentLine];
		if (Input.GetKeyDown (KeyCode.Return)) {
				currentLine += 1;
			}

		if (currentLine > endAtLine) {
			currentLine = 0;
			DisableTextBox();

		}
	}
	public void EnableTextBox(){
		textBox.SetActive(true);
		isActive = true;
		if (stopPlayerMovement) {
			}
	}
	public void DisableTextBox(){
		textBox.SetActive(false);
		}
	public void ReloadScript(TextAsset newText){
		Debug.Log ("reloading");
		if (newText != null) {
			Debug.Log ("got a file for ya");
			textLines = new string [0];
			textLines = (newText.text.Split (lineBreak, System.StringSplitOptions.None));
			Debug.Log ("array loaded");
		}
	}
} 
