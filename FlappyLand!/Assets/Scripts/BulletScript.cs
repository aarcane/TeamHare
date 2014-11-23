using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour
{

	public float distanceTravelled = 0;
	Vector3 lastPosition;
	
	void Start() {
		lastPosition = transform.position;
	}
	
	void Update() {
		if (distanceTravelled > 10)
			Destroy (gameObject);
		distanceTravelled += Vector3.Distance(transform.position, lastPosition);
		lastPosition = transform.position;
	}

		void OnTriggerEnter2D (Collider2D other)
		{
			if (other.gameObject.tag == "Player" | other.gameObject.tag == "Friendly")
						return;
		Debug.Log ("Sending Message adjustHealth -100 to " + other.gameObject.ToString());
		other.gameObject.BroadcastMessage ("adjustHealth", -100);//, SendMessageOptions.DontRequireReceiver);
		//GameObject player = GameObject.FindGameObjectWithTag ("Player");

				//if (other.gameObject.tag == "obstacle") {
				//		Destroy (other.gameObject);
				//}
				//if (other.gameObject.tag == "BossSlug") {
				//		player.GetComponent<Jump> ().decreaseBossHealth ();
				//}
				//if (other.gameObject.tag == "BossTriton") {
				///		player.gameObject.GetComponent<Jump> ().decreaseBossHealth ();
				//}
				//if (other.gameObject.tag == "SlugBossShields") {
				//		player.gameObject.GetComponent<Jump> ().decreaseSlugShieldHealth ();
				//		if (player.gameObject.GetComponent<Jump> ().slugShieldHealth <= 0) {
				//				Destroy (other.gameObject);
					//}
				//}
				//if (other.gameObject.tag == "BossTree") {
				//		player.gameObject.GetComponent<Jump> ().decreaseBossHealth ();
				//}
				//if (other.gameObject.tag == "BossBullDog") {
				//		player.gameObject.GetComponent<Jump> ().decreaseBossHealth ();
				//}
				//if (other.gameObject.tag == "BossTrojanHorse") {
				//		player.gameObject.GetComponent<Jump> ().decreaseHorseHealth ();
				//}
				//if (other.gameObject.tag == "BossTrojan") {
				//		player.gameObject.GetComponent<Jump> ().decreaseBossHealth ();
				//}
		Destroy (this.gameObject);

		}
}
