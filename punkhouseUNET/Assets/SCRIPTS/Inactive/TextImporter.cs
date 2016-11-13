using UnityEngine;
using System.Collections;

public class TextImporter : MonoBehaviour {

	public TextAsset textfile;
	public string[] textlines;
	public char splitter;
	// Use this for initialization
	void Start () {
		splitter = '\n';

		if (textfile != null) {
			textlines = (textfile.text.Split(splitter));
		}
	}
	

}
