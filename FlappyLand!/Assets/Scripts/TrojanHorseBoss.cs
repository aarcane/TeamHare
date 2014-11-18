using UnityEngine;
using System.Collections;

public class TrojanHorseBoss : MonoBehaviour {

	public int maxSpeed;
	
	// Use this for initialization,
	void Start ()
	{
		maxSpeed = 4;
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
}
