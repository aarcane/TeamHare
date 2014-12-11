using UnityEngine;
using System.Collections;

public class Horsey : MonoBehaviour {
	
	// Use this for initialization
	public Vector2 velocity = new Vector2 (-9, 0);
	public Vector2 tmp;
	
	// Use this for initialization
	void Start ()
	{
		tmp = transform.position;
		float y = Random.Range (1.0f, 3.1f);
		int posOrNeg = Random.Range (0, 2);
		print (posOrNeg);
		if (posOrNeg == 0) {
			tmp.y = y;
		} else {
			tmp.y = -y;
		}
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
