using UnityEngine;
using System.Collections;

public class HasHealth : MonoBehaviour
{
		public int health = 1;
		public bool isBoss = false;

		void Update ()
		{
		}

		public void adjustHealth (int delta)
		{
				Debug.Log ("Old Health: " + health + ", New Health: " + (health + delta));
				health += delta;
				if (dead ()) {
						if (this.gameObject.tag == "FrostBoss1") {
								GameObject.FindGameObjectWithTag ("Player").gameObject.GetComponent<Jump> ().setBossDead ("FrostBoss1");
								GameObject.FindGameObjectWithTag ("Player").gameObject.GetComponent<Jump> ().BossSpawned = false;
						}
						if (this.gameObject.tag == "BossTrojanHorse") {
								GameObject.FindGameObjectWithTag ("Player").gameObject.GetComponent<Jump> ().setBossDead ("BossTrojanHorse");

						}
						Destroy (this.gameObject);
				}
		}

		public bool dead ()
		{
				return (health <= 0);
		}

		public void onDestroy ()
		{
				Debug.Log ("Destroying " + ToString ());
				if (isBoss) {
						GameObject.FindGameObjectWithTag ("Player").gameObject.GetComponent<Jump> ().BossSpawned = false;
						Application.LoadLevel (Application.loadedLevel + 1);
				}
		}

		public void setHealth (int delta)
		{
				Debug.Log ("Old Health: " + health + ", New Health: " + (health + delta));
				health = delta;
		}
}
