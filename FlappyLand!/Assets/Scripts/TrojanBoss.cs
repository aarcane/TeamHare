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
		InvokeRepeating ("chooseWeapon", 1f, 2f);
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
		shootProjectile (swordShot, transform.position + new Vector3 (0f, 1.4f, 0f), 19f);
		shootProjectile (swordShot, transform.position, 0f);
		shootProjectile (swordShot, transform.position - new Vector3 (0f, 1.4f, 0f), -19f);
	}
	void makeShield ()
	{
		shield.tag = "obstacle";
		Instantiate (shield);
	}
	void shootProjectile (Transform shoot, Vector3 origin, float angle = 0, int speed = 600)
	{
		Transform shot = Instantiate (shoot, origin, Quaternion.Euler (0f, 0f, 153.1437f)) as Transform;
		shot.rigidbody2D.AddForce (-(new Vector2 (Mathf.Cos (Mathf.Deg2Rad * angle), Mathf.Sin (Mathf.Deg2Rad * angle)) * speed));
	}
}
