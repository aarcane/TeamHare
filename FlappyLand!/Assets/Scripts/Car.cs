using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {
	
	// Use this for initialization
	public Vector2 velocity;
	
	// Use this for initialization
	void Start ()
	{
		//Each car has a random velocity.
		int number = Random.Range (1, 9);
		velocity = new Vector2(-number, 0);
		rigidbody2D.velocity = velocity;
		transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
	}
	
	void Update()
	{
		Vector2 screenPosition = Camera.main.WorldToScreenPoint (transform.position);
		if (screenPosition.x > Screen.width || screenPosition.x < 0) {
			Destroy(gameObject);
		}
	}
}
