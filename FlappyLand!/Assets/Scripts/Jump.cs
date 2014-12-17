using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour
{
		public GameObject fog;
		//Decrease score by 50
		public int cheapRockets;
		public int spreadRockets;
		public int superSpreadRockets;
		public int gravityItem;
//		public int itemDuration;
		public bool hasBubbleShield = false;
		public bool isInfiniteMode = false;
//		public bool hasSuperSpreadRocket = false;
//		public bool hasGravityItem = false;
		public int textDuration = 0;

		//score shown on GUI
		public int score;
		public int bestScore;

		//The "bullet" object that is referenced in the code
		public Transform shotPrefab;
		public Transform BubbleShield;


		// The force which is added when the player jumps
		// This can be changed in the Inspector window
		public int defaultJumpForce = 900;
		Vector2 jumpForce;
		public static Jump instance;

		void Start ()
		{
				instance = this;
				DontDestroyOnLoad (gameObject);
				this.gameObject.SetActive (false);
		}

		void OnLevelWasLoaded (int level)
		{
				if (level == 0)
						return;
				transform.position = new Vector3 (-3.553207f, 0f, -0.01f);
				setJumpForce (defaultJumpForce);
				gravityItem = 0;
				Time.timeScale = 1.0f;
		}

		// Update is called once per frame
		void Update ()
		{
				if (Application.loadedLevel == 0)
						return;
				if (Time.timeScale == 0f)
						return;	

				++score;



				if (gravityItem > 0) {
						--gravityItem;
						if (gravityItem <= 0) {
								gravityItem = 0;
								setJumpForce (defaultJumpForce);
						}
				}

				if (hasBubbleShield) {
						Transform bubbleShieldItem = Instantiate (BubbleShield) as Transform;
						bubbleShieldItem.position = transform.position;
				}

				// Jump
				if (Input.GetButtonDown ("Jump")) {
						rigidbody2D.velocity = Vector2.zero;
						rigidbody2D.AddForce (jumpForce);
				}
				
				// Fire various rockets!
				if (Input.GetButtonDown ("Fire1")) {
						if (CanLaunchRocket (ref score, 500)) {
								shootRocket (transform.position);
						}
				}
				if (Input.GetButtonDown ("Fire2")) {
						if (spreadRockets > 0 && CanLaunchRocket (ref spreadRockets)) {
								shootRocket (transform.position, 20);
								shootRocket (transform.position);
								shootRocket (transform.position, -20);
						}
				}
				if (Input.GetButtonDown ("Fire3")) {
						if (superSpreadRockets > 0 && CanLaunchRocket (ref superSpreadRockets)) {
								Vector3[] origins = new Vector3[4];
								int i = 0;
								origins [i++] = transform.position + new Vector3 (0f, 1.8f, 0f);
								origins [i++] = transform.position + new Vector3 (0f, 0.9f, 0f);
								origins [i++] = transform.position - new Vector3 (0f, 0.9f, 0f);
								origins [i++] = transform.position - new Vector3 (0f, 1.8f, 0f);
								;
								
								foreach (Vector3 o in origins) {
										shootRocket (o, 20);
										shootRocket (o);
										shootRocket (o, -20);
								}
						}
				}


				Vector2 screenPosition = Camera.main.WorldToScreenPoint (transform.position);
				if (screenPosition.y > Screen.height || screenPosition.y < 0) {
						Die ();
				}
		}

		void shootRocket (Vector3 origin, float angle = 0, int speed = 800)
		{
				Transform shot;
				shot = Instantiate (shotPrefab, origin, Quaternion.Euler (0f, 30f, angle)) as Transform;
				shot.rigidbody2D.AddForce (new Vector2 (Mathf.Cos (Mathf.Deg2Rad * angle), Mathf.Sin (Mathf.Deg2Rad * angle)) * speed);
		}

		void OnGUI ()
		{
				if (Application.loadedLevel == 0)
						return;
				GUIStyle myStyle = new GUIStyle ();
				myStyle.fontSize = 25;
				myStyle.normal.textColor = Color.white;
				GUI.Label (new Rect (10, 10, 400, 30), "Score: " + score + " SpreadRockets: " + spreadRockets + " Cheap Ass Rockets: " + cheapRockets + " Super Ass Rockets: " + superSpreadRockets, myStyle);

				if (gravityItem > 0) {
						GUI.Label (new Rect (200, 40, 400, 30), "DAMN! FUCKIN' GRAVITY, BRO! (" + gravityItem + ")", myStyle);
				}
				if (spreadRockets > 0) {
						GUI.Label (new Rect (200, 70, 400, 30), "SPREAD ROCKETS, BABY! (" + spreadRockets + ")", myStyle);
				}
				if (superSpreadRockets > 0) {
						GUI.Label (new Rect (200, 100, 400, 30), "HOLY SHIT SUPER ROCKETS, DUDE! (" + superSpreadRockets + ")", myStyle);
				}
				if (cheapRockets > 0) {
						GUI.Label (new Rect (200, 130, 400, 30), "CHEAP ASS ROCKETS, SON! (" + cheapRockets + ")", myStyle);
				}
				if (textDuration > 0 && hasBubbleShield) {
						GUI.Label (new Rect (200, 160, 400, 30), "SICK! STRONG BUBBLE SHIELD, BUDDY!", myStyle);
				}
		}

		void OnTriggerEnter2D (Collider2D other)
		{
				if (other.gameObject.tag == "CheapAssRockets") {
						cheapRockets += 700;
						Destroy (other.gameObject);
				} else if (other.gameObject.tag == "SpreadRocketItem") {
						spreadRockets += 700;
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
						superSpreadRockets += 700;
						Destroy (other.gameObject);
				} else if (other.gameObject.tag == "GravityItem") {
						gravityItem += 700;
						setJumpForce (Random.Range (375, 550));
						Destroy (other.gameObject);
				} else if (other.gameObject.tag == "obstacle")
						Die ();
		}

		void OnCollisionEnter2D (Collision2D other)
		{
				Die ();
		}

		public void Die ()
		{
				Application.LoadLevel ("InfiniteGameOver");
		}

		public void setJumpForce (int newforce)
		{
				jumpForce = new Vector2 (0, newforce);
		}

		public void disableBubbleShield ()
		{
				hasBubbleShield = false;
		}

		bool CanLaunchRocket (ref int rocketInventory, int cost = 1)
		{
				bool fire = false;
				if (cheapRockets > 0) {
						--cheapRockets;
						fire = true;
				} else if (rocketInventory > 0) {
						rocketInventory -= cost;
						fire = true;
				}
				return fire;
		}
}
