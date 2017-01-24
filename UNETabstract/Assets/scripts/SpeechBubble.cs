using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[ExecuteInEditMode]
public class SpeechBubble : MonoBehaviour {

	// this game objects transform
	private Transform gameObTransform;
	// game objects pos. on screen (pixels)
	private Vector3 gameObScreenPos;
	// game objects pos. on screen
	private Vector3 gameObViewportPos;

	//speech bubble width
	public int bubbleWidth;
	//speech bubble height
	public int bubbleHeight;

	//offset for fine tuning
	public float offsetX=0;
	public float offsetY=150;

	//nother offset for centering
	public float centerOffsetX;
	public float centerOffsetY;

	//text
	public Text theText;

	//material for the triangle part of the bubble
	//(think i will want to replace this with 3 dots)
	//public Material mat;

	//guiskin for the round part of the bubble
	//(this will likely also get replaced)
	//public GUIText guiText;

	//early initialization
	void Awake(){
		gameObTransform = this.GetComponent<Transform> ();
	}

	// Use this for initialization
	void Start () {
	//if the material hasnt been found
		//if (!mat) {
		//	Debug.LogError("please assign a material in the inspector");
		//	return;
		//}
	//if the guiskin hasnt been found
		//if (!guiText) {
		//	Debug.LogError("please assign a gui skin in the inspector");
		//	return;
		//}
	//calc x&y offsets to center the speechbubble
		centerOffsetX = bubbleWidth / 2;
		centerOffsetY = bubbleHeight / 2;


	}
	
	// Update is called once per frame
	void LateUpdate () {
		//find screen position
		gameObScreenPos = Camera.main.WorldToScreenPoint (gameObTransform.position);

		gameObViewportPos.x = gameObScreenPos.x / (float)Screen.width;
		gameObViewportPos.y = gameObScreenPos.y / (float)Screen.height;
	}

	void OnGUI(){
	//begin gui group centering bubbles on gmae object
		GUI.BeginGroup (new Rect (gameObScreenPos.x-centerOffsetX-offsetX,Screen.height-gameObScreenPos.y-centerOffsetY-offsetY,bubbleWidth,bubbleHeight));
		
	//render round part of bubble
		//GUI.Label (new Rect(0,0,200,100),"");
		//GUIText ();
	//render the text
		
		GUI.EndGroup();		         
	}
	//called after camera has finished rendering scene
	//void OnPostRender(){
//	//push current matrix into GL stack
//		GL.PushMatrix ();
	//set material pass
//		mat.SetPass (0);
	//load orthagonal projection matrix
//		GL.LoadOrtho ();
	//triangle primitive
//		GL.Begin (GL.TRIANGLES);
	//set color
//		GL.Color (Color.white);
	//define vertices
//		GL.Vertex3(gameObViewportPos.x, gameObViewportPos.y+(offsetY/3)/Screen.height,0.1f);
//		GL.Vertex3(gameObViewportPos.x-(bubbleWidth/3)/(float)Screen.width, gameObViewportPos.y+(offsetY/3)/Screen.height,0.1f);
//		GL.Vertex3(gameObViewportPos.x-(bubbleWidth/8)/(float)Screen.width, gameObViewportPos.y+(offsetY/3)/Screen.height,0.1f);

//		GL.End();
//		GL.PopMatrix();
	}

