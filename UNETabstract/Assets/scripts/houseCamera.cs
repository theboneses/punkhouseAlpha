using UnityEngine;
using System.Collections;

public class houseCamera : MonoBehaviour {

	public Camera houseCam;
	public GameObject[] player;
	public Transform target;
	public Vector3 pCoM;

	// Use this for initialization
	void Awake() {
		houseCam = GameObject.FindObjectOfType<Camera>();

		target.position = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		player = GameObject.FindGameObjectsWithTag("Player");
		Debug.Log ("player length =" + player.Length);
		pCoM = playerCenter(pCoM,player);
		target.position = pCoM;
		houseCam.transform.LookAt(target);
	}

	//this computes a center for all players.
	public Vector3 playerCenter (Vector3 c, GameObject[] players){
		
		if (players.Length > 0) {
			float x = 0f;
			float y = 0f;
			float z = 0f;
			foreach (GameObject punk in players) {
				x += punk.gameObject.transform.position.x;
				y += punk.gameObject.transform.position.y;
				z += punk.gameObject.transform.position.z;
			}
			c = new Vector3(x / players.Length, y / players.Length, z / players.Length);
		}
		Debug.Log ("c = ( "+  c + ")");

		return c;
	}
}
