

using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class GameControl_Dumpster : NetworkBehaviour {

	[SerializeField]GameObject[] dumpsterItemPfb;
	private GameObject[] dumpsterItemSpwns;
	private int counter;
	public int numberDumpsterItems = 5;
	private int maxNumberDumpsterItems = 10;
	public float dumpRate = 10f;
	private bool isSpawnActivated = true;


	public override void OnStartServer (){
		dumpsterItemSpwns = GameObject.FindGameObjectsWithTag ("dumpster");
		StartCoroutine (Dump());
		//Debug.Log("coroutine started");
	}
	IEnumerator Dump(){
		for (;;) {
			yield return new WaitForSeconds (dumpRate);
			GameObject[] dumpsterItems = GameObject.FindGameObjectsWithTag ("item");
			if (dumpsterItems.Length < maxNumberDumpsterItems) {
				CommenceDump ();
				//Debug.Log ("yup. started that coroutine. see?");
			}
		}
	}

	void CommenceDump(){
		if (isSpawnActivated) {
			for (int i = 0; i < numberDumpsterItems; i++) {
				int RandomIndex = Random.Range (0, dumpsterItemSpwns.Length);
				CmdSpawnDumpsterItems (dumpsterItemSpwns[RandomIndex].transform.position);
			//	Debug.Log ("just doing our coroutine thing.");
			}
		}
	}
	[Command]
	void CmdSpawnDumpsterItems(Vector3 spwnPos){
		counter++;
		int RandomIndex = Random.Range (0, dumpsterItemPfb.Length);
		GameObject go = GameObject.Instantiate (dumpsterItemPfb [RandomIndex], spwnPos, Quaternion.identity)as GameObject;
		NetworkServer.Spawn (go);
		//Debug.Log ("woof. that took a minute huh?");
	}

	//[Command]
	
}
