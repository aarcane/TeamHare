using UnityEngine;
using System.Collections;

public class KingTritonBoss : MonoBehaviour {

	public Transform tritonShot;
	public int maxSpeed;
	
	// Use this for initialization,
	void Start ()
	{
		maxSpeed = 3;
		InvokeRepeating ("shootTriton", 10f, 3f);
	}
	
	// Update is called once per frame
	void Update ()
	{
		Spawn ();
		
	}
	
	void Spawn ()
	{
		transform.position = new Vector3 (4.528356f, Mathf.Sin (Time.time * maxSpeed), transform.position.z);
		
	}
	
	void shootTriton ()
	{
		shootProjectile (tritonShot, transform.position + new Vector3 (0f, 1.4f, 0f), 0f);
		shootProjectile (tritonShot, transform.position, 0f);
		shootProjectile (tritonShot, transform.position - new Vector3 (0f, 1.4f, 0f), 0f);
	}
	void shootProjectile (Transform shoot, Vector3 origin, float angle = 0, int speed = 1100)
	{
		Transform shot = Instantiate (shoot, origin, Quaternion.Euler (0f, 0f, 43)) as Transform;
		shot.rigidbody2D.AddForce (-(new Vector2 (Mathf.Cos (Mathf.Deg2Rad * angle), Mathf.Sin (Mathf.Deg2Rad * angle)) * speed));
	}
}
