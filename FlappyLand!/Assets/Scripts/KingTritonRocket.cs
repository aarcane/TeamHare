using UnityEngine;
using System.Collections;

public class KingTritonRocket : MonoBehaviour {

	Vector3 lastPosition;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, 3);
		lastPosition = transform.position;
	}
	
	void Update ()
	{
		lastPosition = transform.position;
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			GameObject player = GameObject.FindGameObjectWithTag ("Player");
			player.gameObject.GetComponent<Jump> ().Die ();
			Destroy (this.gameObject);
		}
	}
}
