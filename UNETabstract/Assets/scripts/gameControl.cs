using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class gameControl : MonoBehaviour {

	public static gameControl control;

	public string playerName; 
	public string teamName;
	public Vector3 playerPos;
	public GameObject player;
	void Awake () {
		if (control == null){
			DontDestroyOnLoad (gameObject);
			control = this;
		}
		else if (control != this){
			Destroy (gameObject);
		}
	}

	void OnGUI(){
		GUI.Label (new Rect (10, 200, 100, 30), "name:" + playerName);
	}
	// Update is called once per frame
	void Update () {
		player = GameObject.FindGameObjectWithTag ("Player");
		Debug.Log ("i found a :" + player);
		playerPos = player.transform.position;
	}
	public void Save(){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/playerdata.dat");

		playerData data = new playerData ();
		data.playerName = playerName;
		data.teamName = teamName;
		data.playerPosX = playerPos.x.ToString();
		data.playerPosY = playerPos.y.ToString();
		data.playerPosZ = playerPos.z.ToString();
		bf.Serialize(file,data);
		file.Close();
	}
	public void Load(){
		if (File.Exists (Application.persistentDataPath + "/playerdata.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerdata.dat",FileMode.Open);
			playerData data = (playerData)bf.Deserialize(file);
			file.Close();

			playerName = data.playerName;
			teamName = data.teamName;
			float.TryParse(data.playerPosX,out playerPos.x);
			float.TryParse(data.playerPosY,out playerPos.y);
			float.TryParse(data.playerPosZ,out playerPos.z);
		}
	}
}
[Serializable]
class playerData
{
	public string playerName;
	public string teamName;
	public string playerPosX;
	public string playerPosY;
	public string playerPosZ;
}