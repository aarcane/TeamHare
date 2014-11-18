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
		tritonShot.tag = "obstacle";
		var tritonShotTransform = Instantiate (tritonShot) as Transform;
		tritonShotTransform.position = transform.position;
	}
}
