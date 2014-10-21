using UnityEngine;
using System.Collections;

public class SpreadRocket : MonoBehaviour {

	public Vector2 velocity = new Vector2(10, 0);

	// Use this for initialization
	void Start () {

		Destroy(gameObject, 3);
	
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody2D.velocity = velocity;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.tag == "obstacle"){
			Destroy(this.gameObject);
			Destroy(other.gameObject);
		}
	}
}
