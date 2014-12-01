using UnityEngine;
using System.Collections;

public class FrostBossStage3 : MonoBehaviour
{
	
	public Transform piShot;
	public Transform pieShot;
	public Transform tritonShot;
	public Transform needleShot;
	public Transform spartanShot;
	public Transform trojanShield;
	public Transform mushroomShield;

	public int maxSpeed;
	
	// Use this for initialization
	void Start ()
	{
		maxSpeed = 3;
		//InvokeRepeating ("bossPieShot", 2f, 2f);
		//StartCoroutine (bossPieShot ());
		InvokeRepeating ("shoot", 1f, 1f);
	}
	
	// Update is called once per frame
	void Update ()
	{
		Spawn ();
		
	}
	
	void Spawn ()
	{
		transform.position = new Vector3 (5.28607f, 2 * (Mathf.Sin (Time.time * maxSpeed)), transform.position.z);
		
	}
	
	void shoot ()
	{
		int number = Random.Range (1, 30);
		
		if (number % 2 == 0) {
			makeShield ();
			StartCoroutine (bossPieShot ());
			makeShield ();
		} 
		if (number % 3 == 0) {
			makeMushroomShield ();
			bossProjectiles ();
			Invoke("bossProjectiles", .7f);
		} else {
			//makeShield ();
		}
	}
	
	IEnumerator bossPieShot ()
	{
		
		shootPi (0);
		yield return new WaitForSeconds (.1f);
		shootPie (0);
		yield return new WaitForSeconds (.2f);
		shootPie (0);
		yield return new WaitForSeconds (.3f);			
		shootPi (0);
		yield return new WaitForSeconds (.4f);
		
	}
	
	void bossProjectiles ()
	{
		
		shootProjectile (tritonShot, transform.position, 43.30508f, 15);
		shootProjectile (needleShot, transform.position, 135.4196f, 0);	
		shootProjectile (spartanShot, transform.position, 134.3804f, -15);
		
	}
	
	void shootPi (float position)
	{
		piShot.tag = "obstacle";
		Transform piShotTransform = Instantiate (piShot, transform.position + new Vector3 (0.0f, position, 0.0f), Quaternion.identity) as Transform;
	}
	
	void shootPie (float position)
	{
		pieShot.tag = "obstacle";
		Transform pieShotTransform = Instantiate (pieShot, transform.position + new Vector3 (0.0f, position, 0.0f), Quaternion.identity) as Transform;
	}
	
	void shootProjectile (Transform shoot, Vector3 origin, float prefabAngle, float angle = 0, int speed = 900)
	{
		Transform shot = Instantiate (shoot, origin, Quaternion.Euler (0f, 30f, prefabAngle)) as Transform;
		shot.rigidbody2D.AddForce (-(new Vector2 (Mathf.Cos (Mathf.Deg2Rad * angle), Mathf.Sin (Mathf.Deg2Rad * angle)) * speed));
	}
	void makeShield ()
	{
		trojanShield.tag = "obstacle";
		trojanShield.gameObject.GetComponent<HasHealth> ().health = 900;
		Instantiate (trojanShield);
	}
	
	void makeMushroomShield ()
	{
		mushroomShield.tag = "obstacle";
		mushroomShield.gameObject.GetComponent<HasHealth> ().health =  1000;
		Instantiate (mushroomShield);
	}
}
