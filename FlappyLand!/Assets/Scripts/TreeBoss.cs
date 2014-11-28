using UnityEngine;
using System.Collections;

public class TreeBoss : MonoBehaviour
{

		public Transform needleShot;
		public Transform pineBombs;
		public int maxSpeed;
	
		// Use this for initialization,
		void Start ()
		{
				maxSpeed = 3;
				InvokeRepeating ("chooseWeapon", 8f, 3f);
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

		void chooseWeapon ()
		{
				int number = Random.Range (1, 10);
		
				if (number % 2 == 0) {
						shootNeedles ();
						Invoke ("shootNeedles", .3f);
				} else if (number % 3 == 0) {
						shootBombs ();
				} 
		}

		void shootNeedles ()
		{
				shootProjectileNeedle (needleShot, transform.position, 0f);
		}

		void shootBombs ()
		{
				shootProjectileCone (pineBombs, transform.position, 0f);
		}

		void shootProjectileNeedle (Transform shoot, Vector3 origin, float angle = 0, int speed = 1200)
		{
				Transform shot = Instantiate (shoot, origin, Quaternion.Euler (0f, 0f, 135.4196f)) as Transform;
				shot.rigidbody2D.AddForce (-(new Vector2 (Mathf.Cos (Mathf.Deg2Rad * angle), Mathf.Sin (Mathf.Deg2Rad * angle)) * speed));
		}

		void shootProjectileCone (Transform shoot, Vector3 origin, float angle = 0, int speed = 1200)
		{
				Transform shot = Instantiate (shoot, origin, Quaternion.Euler (0f, 0f, angle)) as Transform;
				shot.rigidbody2D.AddForce (-(new Vector2 (Mathf.Cos (Mathf.Deg2Rad * angle), Mathf.Sin (Mathf.Deg2Rad * angle)) * speed));
		}


}
