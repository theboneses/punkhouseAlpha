using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.IO;

public class cubeControl : NetworkBehaviour {

	public static cubeControl cuControl;
	struct CubeState {
		public float x;
		public float y;
		public float z;
	}

	public bool canMove =true;
	[SyncVar] CubeState state;

	void Awake () {
		//i think ill need to put a check here to see if i have a save position..lets see in a sec
		gameControl.control.Load();
		if (File.Exists (Application.persistentDataPath + "/playerdata.dat")) {
			state = new CubeState {
				x = gameControl.control.playerPos.x,
				y = gameControl.control.playerPos.y,
				z = gameControl.control.playerPos.z,
			};}
		else {
			InitState ();
		}
	}

	[Server]void InitState () {
		state = new CubeState {
			x = 0,
			y = 0.5f,
			z = 0
		};
	}

	void Update () {
		if (!canMove) {
			return;
		}
		if (isLocalPlayer) {
			KeyCode[] arrowKeys = { KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.RightArrow, KeyCode.LeftArrow };
			foreach (KeyCode arrowKey in arrowKeys) {
				if (!Input.GetKeyDown (arrowKey))
					continue;
				CmdMoveOnServer(arrowKey);
			}
		}
		SyncState();
	}

	void SyncState () {
		transform.position = new Vector3(state.x, state.y, state.z);
	}

	[Command] void CmdMoveOnServer (KeyCode arrowKey)
	{
		state = Move (state, arrowKey);
	}

	CubeState Move(CubeState previous, KeyCode arrowKey) {
		int dx = 0;
		int dz = 0;
		switch (arrowKey) {
		case KeyCode.UpArrow:
			dz = 1;
			break;
		case KeyCode.DownArrow:
			dz = -1;
			break;
		case KeyCode.RightArrow:
			dx = 1;
			break;
		case KeyCode.LeftArrow:
			dx = -1;
			break;
		}
		return new CubeState {
			x = dx + previous.x,
			y = 0.5f,
			z = dz + previous.z
		};
	}

}
