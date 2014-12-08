using UnityEngine;
using System.Collections;

public class SlugBossUCSC : MonoBehaviour
{
		public Transform poopShot;
		public int maxSpeed;

		// Use this for initialization,
		void Start ()
		{
				InvokeRepeating ("shootPoop", 7f, 3f);
		}
	
		// Update is called once per frame
		void Update ()
		{
				transform.position = new Vector3 (4.910788f, Mathf.Sin (Time.time * maxSpeed), transform.position.z);

		}

		void shootPoop ()
		{
				shootProjectile (poopShot, transform.position, 0);
		}

		void shootProjectile (Transform shoot, Vector3 origin, float angle = 0, int speed = 1000)
		{
				Transform shot = Instantiate (shoot, origin, Quaternion.Euler (0f, 30f, angle)) as Transform;
				shot.rigidbody2D.AddForce (-(new Vector2 (Mathf.Cos (Mathf.Deg2Rad * angle), Mathf.Sin (Mathf.Deg2Rad * angle)) * speed));
		}

}
