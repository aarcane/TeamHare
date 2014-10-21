using UnityEngine;
using System.Collections;

public class PipeObstacle : MonoBehaviour {

	public Vector2 velocity = new Vector2(-4, 0);
	public float rangeY = 4;
	
	// Use this for initialization
	void Start()
	{
		rigidbody2D.velocity = velocity * Random.value;
		transform.position = new Vector3(transform.position.x, transform.position.y - rangeY * Random.value, transform.position.z);
		Destroy(gameObject, 80);
	}
}
