using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class houseCamera : MonoBehaviour {

	public Camera houseCam;
	public GameObject[] player;
	public List<GameObject> players;


	public Vector3 pCoM;
	//private Vector3 lastPCoM;
	[SerializeField]
	int offset;


	// Use this for initialization
	void Awake() {
		houseCam = GameObject.FindObjectOfType<Camera>();

	
	}
	
	// Update is called once per frame
	void Update () {
		//updateList (players);
		//Debug.Log ("we updated player");
		pCoM = playerCenter(pCoM,players);

		houseCam.transform.LookAt(pCoM);
		houseCam.transform.position=Vector3.Lerp(houseCam.transform.position, pCoM+ new Vector3(0,2,offset), Time.deltaTime);
		//lastPCoM=pCoM;	


	}
	public void updateList(List<GameObject> playerList){
		int i;
		for(i=0;i<playerList.Count;i++){
			player[i]=playerList[i];
			Debug.Log ("we def updated the player" + playerList.Count);
		}
	}


	//this computes a center for all players.
	public Vector3 playerCenter (Vector3 c, List<GameObject> players){
		
		if (players.Count > 0) {
			float x = 0f;
			float y = 0f;
			float z = 0f;
			foreach (GameObject punk in players) {
				x += punk.gameObject.transform.position.x;
				y += punk.gameObject.transform.position.y;
				z += punk.gameObject.transform.position.z;
			}
			c = new Vector3(x / players.Count, y / players.Count, z / players.Count);
		}
		//Debug.Log ("c = ( "+  c + ")");

		return c;
	}

}
