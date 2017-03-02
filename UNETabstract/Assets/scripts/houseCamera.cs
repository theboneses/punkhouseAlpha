using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class houseCamera : MonoBehaviour {

	public Camera houseCam;
	public GameObject[] player;
	public List<GameObject> players;
	public GameObject iris;

	public Vector3 pCoM;

	[SerializeField]
	int offset;
	[SerializeField]
	int smooveH;


	// Use this for initialization
	void Awake() {
		houseCam = GameObject.FindObjectOfType<Camera>();


	
	}
	void OnEnable(){
		iris.SetActive (true);
		houseCam.fieldOfView = 30;
	}
	void OnDisable() {
		iris.SetActive (false);
	}
	// Update is called once per frame
	void Update () {
		pCoM=playerCenter(pCoM,players);

		houseCam.transform.LookAt(pCoM);
		houseCam.transform.position=Vector3.Lerp(houseCam.transform.position, new Vector3(pCoM.x,pCoM.y+3,offset), Time.deltaTime*smooveH);
		iris.transform.position = Vector3.Lerp (iris.transform.position,new Vector3(pCoM.x,pCoM.y+2,1),Time.deltaTime*smooveH);

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
