using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerBubble : MonoBehaviour {

	// this game objects transform
	private Transform gameObTransform;
	// game objects pos. on screen (pixels)
	private Vector3 gameObScreenPos;
	// game objects pos. on screen
	private Vector3 gameObViewportPos;


	//nother offset for centering
	public float centerOffsetX;
	public float centerOffsetY;
	
	//text
	public Text theText;
	public Vector2 canvasCoord;

	void Awake(){
		gameObTransform = this.GetComponent<Transform> ();
	}

	// Use this for initialization
	void Start () {
		//centerOffsetX = 50	;
		//centerOffsetY = 150;
		//Vector2 canvasCoord = new Vector2 (0f,0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void LateUpdate () {
		//find screen position
		gameObScreenPos = Camera.main.WorldToScreenPoint (gameObTransform.position);
		//gameObViewportPos.x = gameObScreenPos.x / (float)Screen.width;
		//gameObViewportPos.y = gameObScreenPos.y / (float)Screen.height;
		canvasCoord.x = gameObScreenPos.x;
		canvasCoord.y = gameObScreenPos.y + centerOffsetY;
		theText.rectTransform.position = canvasCoord;
	}
}
