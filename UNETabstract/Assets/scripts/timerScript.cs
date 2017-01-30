using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class timerScript : MonoBehaviour {

	public Text timerText;
	private float startTime = 20;
	public string gameover = "gameover";
	//Spublic textboxmgr newie;
	// Use this for initialization
	void Start () {
		
		//newie = FindObjectOfType<textboxmgr>();
	}
	
	// Update is called once per frame
	void OnTriggerStay(Collider other) {
		
		if (other.tag == "Player") {
			//timerText = ":" + 20;
			  startTime -= Time.deltaTime;

			string seconds = (startTime % 60).ToString ("F1");
			timerText.text = ":" + seconds;
			if (startTime <= 0) {
				timerText.text = gameover;
			}
		}
	}

}
