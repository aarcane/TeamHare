using UnityEngine;
using System.Collections;

public class TrojanBoss : MonoBehaviour {

	public Transform swordShot;
	public GameObject shield;
	public int maxSpeed;
	
	// Use this for initialization,
	void Start ()
	{
		maxSpeed = 3;
		InvokeRepeating ("chooseWeapon", 10f, 2f);
	}
	
	// Update is called once per frame
	void Update ()
	{
		Spawn ();
		
	}

	void chooseWeapon ()
	{
		int number = Random.Range (1, 20);
		
		if (number % 2 == 0) {
			shootSword ();
			Invoke ("shootNeedles", 1);
		} else if (number % 5 == 0) {
			makeShield ();
		} 
	}

	void Spawn ()
	{
		transform.position = new Vector3 (4.910788f, Mathf.Sin (Time.time * maxSpeed), transform.position.z);
		
	}
	
	void shootSword ()
	{
		swordShot.tag = "obstacle";
		var swordShotTransform = Instantiate (swordShot) as Transform;
		swordShotTransform.position = transform.position;
	}
	void makeShield ()
	{
		shield.tag = "obstacle";
		Instantiate (shield);
	}
}
