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
		public bool hasBubbleShield = false;
		public bool hasSuperSpreadRocket = false;
		public bool hasGravityItem = false;
		public int itemDuration = 700;
		public int textDuration = 0;
		//score shown on GUI
		public int score = 0;
		
		//The "bullet" object that is referenced in the code
		public Transform shotPrefab;
		public Transform spreadRocketPrefab;
		public Transform BubbleShield;


		// The force which is added when the player jumps
		// This can be changed in the Inspector window
		public Vector2 jumpForce = new Vector2 (0, 600);
	
		// Update is called once per frame
		void Update ()
		{		
				if (textDuration > 0) {

						textDuration --;
				}
				score++;
				
				if (score >= 2000) {
						
						if (Application.loadedLevelName == "Forest Level") {
								if (!BossSpawned) {
										Instantiate (SlugBoss);
										Instantiate (SlugBossShields);
										bossHealth = 2000;
										BossSpawned = true;
								}
						} else if (Application.loadedLevelName == "Beach Level") {
								if (!BossSpawned) {
										Instantiate (TritonBoss);
										bossHealth = 2500;
										BossSpawned = true;
								}
						} else if (Application.loadedLevelName == "Snow Level") {
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
						if (Application.loadedLevelName == "City Level") {
								Application.LoadLevel ("Forest Level");
						} else if (Application.loadedLevelName == "Forest Level") {
								Application.LoadLevel ("Beach Level");
						} else if (Application.loadedLevelName == "Beach Level") {
								Application.LoadLevel ("Grassy Plains Level");
						} else if (Application.loadedLevelName == "Grassy Plains Level") {
								Application.LoadLevel ("Snow Level");
						} else if (Application.loadedLevelName == "Snow Level") {
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

				if (hasSuperSpreadRocket) {
			
						itemDuration --;
			
						if (itemDuration <= 0) {
								hasSuperSpreadRocket = false;
						}
			
				}

				if (hasGravityItem) {
						itemDuration --;

						if (itemDuration <= 0) {
								hasGravityItem = false;
								jumpForce = new Vector2 (0, 600);
						}
				} 
		
				if (hasBubbleShield) {
						var bubbleShieldItem = Instantiate (BubbleShield) as Transform;
			
						bubbleShieldItem.position = transform.position;
			
				}

				
				// Jump
				if (Input.GetKeyUp ("space")) {
						rigidbody2D.velocity = Vector2.zero;
						rigidbody2D.AddForce (jumpForce);
				}
				if (Input.GetKeyDown ("x")) {
						// Instantiate the projectile at the position and rotation of this "transform" - e.g GameObject/Shark
						//Only allow shots if score > 1000
							
						if (hasSuperSpreadRocket) {
								if (!HitCheapAssRockets) {
					
										if ((score - 500) > 0) {
												score -= 500;
												var spreadRocketTransform = Instantiate (shotPrefab, transform.position + new Vector3 (0.0f, 0.7f, 0.0f), Quaternion.identity) as Transform;
												var spreadRocketTransform2 = Instantiate (shotPrefab, transform.position - new Vector3 (0.0f, 0.7f, 0.0f), Quaternion.identity) as Transform;
												var spreadRocketTransform3 = Instantiate (shotPrefab, transform.position, Quaternion.identity) as Transform;
												var spreadRocketTransform4 = Instantiate (shotPrefab, transform.position + new Vector3 (0.0f, 1.4f, 0.0f), Quaternion.identity) as Transform;
										}
								} else {
										if ((score - 50) > 0) {
												score -= 50;
												var spreadRocketTransform = Instantiate (shotPrefab, transform.position + new Vector3 (0.0f, 0.7f, 0.0f), Quaternion.identity) as Transform;
												var spreadRocketTransform2 = Instantiate (shotPrefab, transform.position - new Vector3 (0.0f, 0.7f, 0.0f), Quaternion.identity) as Transform;
												var spreadRocketTransform3 = Instantiate (shotPrefab, transform.position, Quaternion.identity) as Transform;
												var spreadRocketTransform4 = Instantiate (shotPrefab, transform.position + new Vector3 (0.0f, 1.4f, 0.0f), Quaternion.identity) as Transform;
										}
								}
						} else if (hasSpreadRocket) {
								
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

				if (textDuration > 0) {

						if (hasBubbleShield) {
								GUI.Label (new Rect (200, 10, 400, 30), "SICK! STRONG BUBBLE SHIELD, BUDDY!", myStyle);
						}
				}
				
				if (itemDuration > 400) {
						if (hasGravityItem) {
								GUI.Label (new Rect (200, 10, 400, 30), "DAMN! FUCKIN' GRAVITY, BRO!", myStyle);
						} else if (hasSpreadRocket) {
								GUI.Label (new Rect (200, 10, 400, 30), "SPREAD ROCKETS, BABY!", myStyle);
						} else if (hasSuperSpreadRocket) {
								GUI.Label (new Rect (200, 10, 400, 30), "HOLY SHIT SUPER ROCKETS, DUDE!", myStyle);
						} else if (HitCheapAssRockets) {
								GUI.Label (new Rect (200, 10, 400, 30), "CHEAP ASS ROCKETS, SON!", myStyle);
						}
				}
		}

		void OnTriggerEnter2D (Collider2D other)
		{
				if (other.gameObject.tag == "CheapAssRockets") {
						itemDuration = 700;
						HitCheapAssRockets = true;
						Destroy (other.gameObject);
				} else if (other.gameObject.tag == "SpreadRocketItem") {
						hasSpreadRocket = true;
						hasSuperSpreadRocket = false;
						itemDuration = 700;
						Destroy (other.gameObject);
				} else if (other.gameObject.tag == "SurpriseItem") {
						Instantiate (fog);
						Destroy (other.gameObject);
				} else if (other.gameObject.tag == "MoneyItem") {
						int number = Random.Range (500, 5000);
						score += number;
						Destroy (other.gameObject);
				} else if (other.gameObject.tag == "BubbleShieldItem") {
						hasBubbleShield = true;
						textDuration = 300;
						Destroy (other.gameObject);
				} else if (other.gameObject.tag == "SuperRocketItem") {
						hasSuperSpreadRocket = true;
						hasSpreadRocket = false;
						itemDuration = 700;
						Destroy (other.gameObject);
				} else if (other.gameObject.tag == "GravityItem") {
						hasGravityItem = true;
						int randomForce = Random.Range (375, 550);
						setJumpForce (randomForce);
						itemDuration = 700;
						Destroy (other.gameObject);
				}
		}

		void OnCollisionEnter2D (Collision2D other)
		{
				Die ();
		}
		
		public void decreaseBossHealth ()
		{

				if (hasSpreadRocket) {
						bossHealth -= -300;
				} else {
			
						bossHealth -= 100;
				}
		}
		
		public void decreaseHorseHealth ()
		{
				if (hasSpreadRocket) {
						horseHealth -= -300;
				} else {
		
						horseHealth -= 100;
				}
		}

		public void decreaseSlugShieldHealth ()
		{
				if (hasSpreadRocket) {
						slugShieldHealth -= -300;
				} else {
			
						slugShieldHealth -= 100;
				}
		}

		public void setJumpForce (int newforce)
		{
				jumpForce = new Vector2 (0, newforce);
		}

		public void disableBubbleShield ()
	{	
				hasBubbleShield = false;
		}

		public void Die ()
		{
				Application.LoadLevel (Application.loadedLevel);
		}

}
