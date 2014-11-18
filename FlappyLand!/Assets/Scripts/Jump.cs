using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour
{
		public GameObject fog;
		public GameObject TrojanHorseBoss;
		public GameObject TrojanBoss;
		public GameObject BullDogBoss;
		public GameObject SlugBoss;
		public GameObject TritonBoss;
		public GameObject TreeBoss;
		public GameObject SlugBossShields;

		//Boss Killed Will be set here 
		public int bossHealth = 10;
		public int horseHealth = 1500;
		public int slugShieldHealth = 1000;
		public bool BossSpawned = false;
		public bool trojanHorseDead = false;
		//Decrease score by 50
		public bool HitCheapAssRockets = false;
		public bool hasSpreadRocket = false;
		public int itemDuration = 700;
	
		//score shown on GUI
		public int score = 0;

		//The "bullet" object that is referenced in the code
		public Transform shotPrefab;
		public Transform spreadRocketPrefab;


		// The force which is added when the player jumps
		// This can be changed in the Inspector window
		public Vector2 jumpForce = new Vector2 (0, 900);
	
		// Update is called once per frame
		void Update ()
		{		
				Debug.Log (bossHealth);
				score++;
				
				if (score >= 2000) {
						
						if (Application.loadedLevelName == "Sharky and Trees") {
								if (!BossSpawned) {
										Instantiate (SlugBoss);
										Instantiate (SlugBossShields);
										bossHealth = 2000;
										BossSpawned = true;
								}
						} else if (Application.loadedLevelName == "Level 3") {
								if (!BossSpawned) {
										Instantiate (TritonBoss);
										bossHealth = 2500;
										BossSpawned = true;
								}
						} else if (Application.loadedLevelName == "Level 2") {
								if (!BossSpawned) {
										Instantiate (TreeBoss);
										bossHealth = 1800;
										BossSpawned = true;
								}
						} else if (Application.loadedLevelName == "City Level") {
								if (!BossSpawned) {
										Instantiate (BullDogBoss);
										bossHealth = 1200;
										BossSpawned = true;
								}
						} else if (Application.loadedLevelName == "Grassy Plains Level") {
								if (!BossSpawned) {
										Instantiate (TrojanHorseBoss);
										horseHealth = 1500;
										BossSpawned = true;
										trojanHorseDead = true;
								}
						}
				}
				
				if (horseHealth <= 0 && BossSpawned) {
						if (trojanHorseDead) {
								GameObject TJBoss = GameObject.FindWithTag ("BossTrojanHorse");				
								Destroy (TJBoss);
								trojanHorseDead = false;			
								Instantiate (TrojanBoss);
								bossHealth = 2000;
						}

				}
				if (bossHealth <= 0) {
						BossSpawned = false;
						if (Application.loadedLevelName == "Sharky and Trees") {
								Application.LoadLevel ("Level 2");
						} else if (Application.loadedLevelName == "Level 2") {
								Application.LoadLevel ("Level 3");
						} else if (Application.loadedLevelName == "Level 3") {
								Application.LoadLevel ("Grassy Plains Level");
						} else if (Application.loadedLevelName == "Grassy Plains Level") {
								Application.LoadLevel ("City Level");
						}
				}
				
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
				if (other.gameObject.tag == "CheapAssRockets") {
						
						itemDuration = 700;
						HitCheapAssRockets = true;
						Destroy (other.gameObject);
				} else if (other.gameObject.tag == "SpreadRocketItem") {

						hasSpreadRocket = true;
						itemDuration = 700;
						Destroy (other.gameObject);
				} else if (other.gameObject.tag == "SurpriseItem") {

						Instantiate (fog);
						Destroy (other.gameObject);
				}
		}

		void OnCollisionEnter2D (Collision2D other)
		{
				Die ();
		}
		
		public void decreaseBossHealth ()
		{

				bossHealth -= 100;
		}
		
		public void decreaseHorseHealth ()
		{
		
				horseHealth -= 100;
		}

		public void decreaseSlugShieldHealth ()
		{
				slugShieldHealth -= 200;
		}

		public void Die ()
		{
				Application.LoadLevel (Application.loadedLevel);
		}

}
