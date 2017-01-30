using UnityEngine;
using System.Collections;

public class cameraFNet : MonoBehaviour {

	public GameObject LPlayer;
	public Vector3 offset;

	void Start(){
		LPlayer = GameObject.FindGameObjectWithTag ("Player");
	}
	// Update is called once per frame
	void Update () 

	{
		transform.position = new Vector3 (LPlayer.transform.position.x + offset.x, LPlayer.transform.position.y + offset.y, offset.z); // Camera follows the player with specified offset position

}
}