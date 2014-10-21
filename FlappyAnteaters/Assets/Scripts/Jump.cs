using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour
{
		//Decrease score by 50
		public bool HitCheapAssRockets = false;
		public bool hasSpreadRocket = false;
		public int itemDuration = 700;
	
		//score shown on GUI
		int score = 0;

		//The "bullet" object that is referenced in the code
		public Transform shotPrefab;
		public Transform spreadRocketPrefab;


		// The force which is added when the player jumps
		// This can be changed in the Inspector window
		public Vector2 jumpForce = new Vector2 (0, 300);
	
		// Update is called once per frame
		void Update ()
		{
				score++;
				

				if (HitCheapAssRockets) {


						itemDuration --;

						if (itemDuration <= 0) {
								HitCheapAssRockets = false;
						}
				} 
				if (hasSpreadRocket) {

						itemDuration --;

						if (itemDuration <= 0) {
								hasSpreadRocket = false;
						}

				}

				
				// Jump
				if (Input.GetKeyUp ("space")) {
						rigidbody2D.velocity = Vector2.zero;
						rigidbody2D.AddForce (jumpForce);
				}
				if (Input.GetKeyDown ("x")) {
						// Instantiate the projectile at the position and rotation of this "transform" - e.g GameObject/Shark
						//Only allow shots if score > 1000
						
						if (hasSpreadRocket) {
								
								if (!HitCheapAssRockets) {
								
										if ((score - 500) > 0) {
												score -= 500;

												var spreadRocketTransform = Instantiate (spreadRocketPrefab) as Transform;
					
												spreadRocketTransform.position = transform.position;
										}
								} else {
										if ((score - 50) > 0) {
												score -= 50;
												var spreadRocketTransform = Instantiate (spreadRocketPrefab) as Transform;
					
												spreadRocketTransform.position = transform.position;
										}
								}
								
						} else if (HitCheapAssRockets && (score > 50)) {
				
								var shotTransform = Instantiate (shotPrefab) as Transform;
				
								shotTransform.position = transform.position;
				
								score -= 50;
								
				
						} else if (score - 500 > 0) {

								var shotTransform = Instantiate (shotPrefab) as Transform;

								shotTransform.position = transform.position;

								score -= 500;
						}

				}

				Vector2 screenPosition = Camera.main.WorldToScreenPoint (transform.position);
				if (screenPosition.y > Screen.height || screenPosition.y < 0) {
						Die ();
				}
	
		}

		void OnGUI ()
		{
				GUIStyle myStyle = new GUIStyle ();
				myStyle.fontSize = 25;
				myStyle.normal.textColor = Color.white;
				GUI.Label (new Rect (10, 10, 400, 30), "Score: " + score.ToString (), myStyle);
		}

		void OnTriggerEnter2D (Collider2D other)
		{
				Debug.Log ("COLIDED IN JUMP");
				if (other.gameObject.tag == "CheapAssRockets") {
						
						itemDuration = 700;
						HitCheapAssRockets = true;
						Destroy (other.gameObject);
				} else if (other.gameObject.tag == "SpreadRocketItem") {

						hasSpreadRocket = true;
						itemDuration = 700;
						Destroy (other.gameObject);
				}
		}

		void OnCollisionEnter2D (Collision2D other)
		{
				Die ();
		}
	
		void Die ()
		{
				Application.LoadLevel (Application.loadedLevel);
		}

}
