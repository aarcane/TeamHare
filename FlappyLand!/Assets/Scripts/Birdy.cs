using UnityEngine;
using System.Collections;

public class Birdy : MonoBehaviour {
	
	// Use this for initialization
	public Vector2 velocity = new Vector2(-9, 0);
	public Vector2 tmp;
	
	// Use this for initialization
	void Start ()
	{	
		//The bird comes from the back of the anteater.
		tmp = transform.position;
		float y = Random.Range (1.0f, 3.2f);
		tmp.y = y;
		transform.position = tmp;
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
