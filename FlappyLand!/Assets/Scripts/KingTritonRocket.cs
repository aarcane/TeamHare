using UnityEngine;
using System.Collections;

public class KingTritonRocket : MonoBehaviour {

	public Vector2 velocity = new Vector2 (-15, 0);
	// Use this for initialization
	void Start () {
		Destroy (gameObject, 3);
	}
	
	void Update ()
	{
		rigidbody2D.velocity = velocity;
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
