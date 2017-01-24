﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Player_Id : NetworkBehaviour {

	[SyncVar] public string playerUniqueIdentity;
	private NetworkInstanceId playerNetId;
	private Transform myTransform;

	public override void OnStartLocalPlayer ()
	{
		GetNetIdentity ();
		SetIdentity ();
	}

	// Use this for initialization
	void Awake () {
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (myTransform.name == "" || myTransform.name == "punkfBubbsC(Clone)") {
			SetIdentity ();
		}
	}

	[Client]
	void GetNetIdentity()
	{
		playerNetId = GetComponent<NetworkIdentity> ().netId;
		CmdTellServerMyIdentity (MakeUniqueIdentity ());
	}

	void SetIdentity()
	{
		if (isLocalPlayer) {
			myTransform.name = playerUniqueIdentity;
		}
		else {
			myTransform.name = MakeUniqueIdentity();
		}
	}

	string MakeUniqueIdentity()
	{
		string uniqueName = "Player" + playerNetId.ToString ();
		return uniqueName;
	}

	[Command]
	void CmdTellServerMyIdentity(string name)
	{
		playerUniqueIdentity = name;
	}
}
