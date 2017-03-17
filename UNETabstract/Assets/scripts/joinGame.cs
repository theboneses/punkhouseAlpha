using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class joinGame : MonoBehaviour {

	List<GameObject> roomList = new List<GameObject>();
	private NetworkManager networkManager;

	[SerializeField]
	private Text status;

	[SerializeField]
	private GameObject roomListItemPrefab;

	[SerializeField]
	private Transform roomListParent;

	void Start(){
		networkManager = NetworkManager.singleton;
		if (networkManager.matchMaker == null) {
			networkManager.StartMatchMaker ();
		}
		RefreshRoomList ();
	}

	public void RefreshRoomList(){
		ClearRoomList ();
		networkManager.matchMaker.ListMatches (0, 20, "", true, 0, 0, OnMatchList);
		Debug.Log ("pulling matchlist");
		status.text = "Loading..";
	}

	public void OnMatchList (bool success, string extendedInfo, List<MatchInfoSnapshot> matchList){
		if (matchList == null) {
			status.text = "couldn't pull room list";
			return;
		}
	
		foreach (MatchInfoSnapshot match in matchList){
			GameObject _roomListItemGO = Instantiate(roomListItemPrefab);
			Debug.Log ("you made it this far");
			_roomListItemGO.transform.SetParent (roomListParent);
			Debug.Log("the parent of" +_roomListItemGO+ "is" +_roomListItemGO.transform.parent+"!");
			//Debug.Log(roomListParent+"has" +roomListParent.childCount+"children");
				
			RoomListItemScript _roomListItem = _roomListItemGO.GetComponent<RoomListItemScript> ();
			if (_roomListItem != null) {
				_roomListItem.Setup (match,JoinRoom);
			}

			roomList.Add (_roomListItemGO);  
		}
		if (roomList.Count == 0) {
			status.text = "no rooms.";
		}
	}

	void ClearRoomList(){
		for (int i = 0; i < roomList.Count; i++) {
			Destroy (roomList [i]);
		}
		roomList.Clear ();
	}
	public void JoinRoom(MatchInfoSnapshot _match){
		networkManager.matchMaker.JoinMatch (_match.networkId, "","", "", 0, 0, networkManager.OnMatchJoined);
		ClearRoomList ();
		status.text = "JOINING.. "; 
	}
}
