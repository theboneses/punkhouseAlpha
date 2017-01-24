using UnityEngine;
using System.Collections;

public class enterScript : MonoBehaviour {

	void OnGUI(){
		gameControl.control.playerName = GUI.TextField(new Rect(10, 10, 200, 20), gameControl.control.playerName, 25);
	}
}
