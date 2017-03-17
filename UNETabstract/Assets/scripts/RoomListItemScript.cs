using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking.Match;

public class RoomListItemScript : MonoBehaviour {

	public delegate void JoinRoomDelegate(MatchInfoSnapshot _match );
	public JoinRoomDelegate joinRoomCallback; 

	[SerializeField]
	private Text roomListItemText;

	private MatchInfoSnapshot match; 

	public void Setup(MatchInfoSnapshot _match, JoinRoomDelegate _joinRoomCallback){
		match = _match;
		joinRoomCallback = _joinRoomCallback;
		roomListItemText.text = match.name + "(" + match.currentSize + "/" + match.maxSize+  ")";
	}
	public void JoinRoom (){
		joinRoomCallback.Invoke (match);
	}
}
