using UnityEngine;
using System.Collections;

public class SpreadRocket : MonoBehaviour
{
		public Vector2 velocity = new Vector2 (10, 0);

		// Use this for initialization
		void Start ()
		{
				Destroy (gameObject, 3);
		}
	
		// Update is called once per frame
		void Update ()
		{
				rigidbody2D.velocity = velocity;
		}

		void OnTriggerEnter2D (Collider2D other)
		{
		if (other.gameObject.tag == "Player")
			return;
		other.gameObject.BroadcastMessage ("adjustHealth", -100);
		Destroy (this.gameObject);

/*		if (other.gameObject.tag == "obstacle") {
						Destroy (this.gameObject);
				}
				if (other.gameObject.tag == "BossSlug") {
						GameObject player = GameObject.FindGameObjectWithTag ("Player");
						player.gameObject.GetComponent<Jump> ().decreaseBossHealth ();
				}
				if (other.gameObject.tag == "BossTriton") {
						GameObject player = GameObject.FindGameObjectWithTag ("Player");
						player.gameObject.GetComponent<Jump> ().decreaseBossHealth ();
				}
				if (other.gameObject.tag == "SlugBossShields") {
						GameObject player = GameObject.FindGameObjectWithTag ("Player");
						player.gameObject.GetComponent<Jump> ().decreaseSlugShieldHealth ();
						
						if (player.gameObject.GetComponent<Jump> ().slugShieldHealth <= 0) {
								Destroy (other.gameObject);
						}
				}
				if (other.gameObject.tag == "BossTree") {
						GameObject player = GameObject.FindGameObjectWithTag ("Player");
						player.gameObject.GetComponent<Jump> ().decreaseBossHealth ();
				}
				if (other.gameObject.tag == "BossBullDog") {
						GameObject player = GameObject.FindGameObjectWithTag ("Player");
						player.gameObject.GetComponent<Jump> ().decreaseBossHealth ();
				}
				if (other.gameObject.tag == "BossTrojanHorse") {
						GameObject player = GameObject.FindGameObjectWithTag ("Player");
						player.gameObject.GetComponent<Jump> ().decreaseHorseHealth ();
				}
				if (other.gameObject.tag == "BossTrojan") {
						GameObject player = GameObject.FindGameObjectWithTag ("Player");
						player.gameObject.GetComponent<Jump> ().decreaseBossHealth ();
				}
				*/
		}
}

