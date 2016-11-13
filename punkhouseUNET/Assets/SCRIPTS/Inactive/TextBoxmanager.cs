using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBoxmanager : MonoBehaviour {

	public GameObject textBox;
	public Text theText;
	public TextAsset textfile;
	public string[] textlines;
	public char splitter;
	public int currentLine;
	public int endAtLine;
	public GameObject player;
	public bool isActive;

	// Use this for initialization
	void Start () {
		splitter = '\n';
		player = GameObject.FindGameObjectWithTag ("Player");
		if (textfile != null) {
			textlines = (textfile.text.Split(splitter));
		}

		if (endAtLine == 0) {
			endAtLine = textlines.Length - 1;
		}
		if (isActive) {
			EnableTextBox();
		} else {
			DisableTextBox();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!isActive) {
			return;
		}
		theText.text = textlines [currentLine];
		if (Input.GetKeyDown (KeyCode.Return)) {
			currentLine +=1;
		}
		if (currentLine > endAtLine) {
			DisableTextBox();
		}
	}
	public void EnableTextBox(){
		textBox.SetActive(true );
		isActive = true;
	}
	public void DisableTextBox(){
		textBox.SetActive(false);
		isActive = false;
	}
	public void ReloadScript(TextAsset theText){
		if(theText != null){
			textlines = new string[1];
			textlines = (theText.text.Split(splitter));
	}
}

}