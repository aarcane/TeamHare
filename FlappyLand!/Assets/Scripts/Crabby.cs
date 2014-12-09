using UnityEngine;
using System.Collections;

public class Crabby : MonoBehaviour {

	// Use this for initialization
	public Vector2 velocity = new Vector2 (-9, 0);
	
	// Use this for initialization
	void Start ()
	{
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
