using UnityEngine;
using System.Collections;

public class MoneyBagItem : MonoBehaviour {

	public Vector2 velocity = new Vector2 (-9, 0);
	public float rangeY = 2.5f;
	
	// Use this for initialization
	void Start ()
	{
		Destroy (gameObject, 30);
		rigidbody2D.velocity = velocity;
		transform.position = new Vector3 (transform.position.x, transform.position.y - rangeY * Random.value, transform.position.z);
	}
}
