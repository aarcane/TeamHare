using UnityEngine;
using System.Collections;

public class TrojanShieldScript : MonoBehaviour {

	public int maxSpeed;
	void Start ()
	{
		maxSpeed = 3;
		InvokeRepeating ("shootSword", 10f, 3f);
	}
	
	// Update is called once per frame
	void Update ()
	{
		Spawn ();
		
	}
	
	void Spawn ()
	{
		transform.position = new Vector3 (1.453648f, Mathf.Sin (Time.time * maxSpeed), transform.position.z);
	}
}
