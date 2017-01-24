using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking.Match;

public class RoomListItemScript : MonoBehaviour {

	public delegate void JoinRoomDelegate(MatchDesc _match );
	public JoinRoomDelegate joinRoomCallback; 

	[SerializeField]
	private Text roomListItemText;

	private MatchDesc match; 

	public void Setup(MatchDesc _match, JoinRoomDelegate _joinRoomCallback){
		match = _match;
		joinRoomCallback = _joinRoomCallback;
		roomListItemText.text = match.name + "(" + match.currentSize + "/" + match.maxSize+  ")";
	}
	public void JoinRoom (){
		joinRoomCallback.Invoke (match);
	}
}
