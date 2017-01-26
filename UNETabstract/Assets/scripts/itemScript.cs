using UnityEngine;
using System.Collections;

public class itemScript : MonoBehaviour {
	public Rigidbody rb;
	public bool isAlone;
	public GameObject player;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame

	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			rb = GetComponent<Rigidbody> ();
			Destroy (rb);
			this.transform.parent = player.transform;
			this.transform.position = new Vector3 (player.transform.position.x, player.transform.position.y + 1.2f, player.transform.position.z + .44f);
		}
			if (Input.GetKeyUp (KeyCode.Space)) {
			Rigidbody rb = this.gameObject.AddComponent<Rigidbody> () as Rigidbody;
				this.transform.parent = null;
				rb.constraints = RigidbodyConstraints.None;
				rb.useGravity = true;
			}
			if (isAlone == true) {
				rb = GetComponent<Rigidbody> ();
			}
		
		}

	void OnTriggerStay(Collider other)
	{
		isAlone = false;
		if (other.tag == "Player") {
			GetComponent<Renderer> ().material.shader = Shader.Find ("Self-Illumin/Outlined Diffuse");
			player = other.gameObject;
		}
	}
	void OnTriggerExit(Collider other)
	{
			isAlone = true;
			player = null;
			rb = GetComponent<Rigidbody> ();
			rb.useGravity = true;
			//other.gameObject.GetComponent<IKControl> ().ikActive = false;
			GetComponent<Renderer> ().material.shader = Shader.Find ("Diffuse");

	}

}
