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
		public int bossHealth;
		public int horseHealth;
		public int slugShieldHealth;
		public bool BossSpawned = false;
		public bool trojanHorseDead = false;
		//Decrease score by 50
		public int cheapRockets;
		public int spreadRockets;
		public int itemDuration;
	
		//score shown on GUI
		public int score;

		//The "bullet" object that is referenced in the code
		public Transform shotPrefab;
		public Transform spreadRocketPrefab;


		// The force which is added when the player jumps
		// This can be changed in the Inspector window
		public Vector2 jumpForce = new Vector2 (0, 900);

	void Start()
	{	DontDestroyOnLoad(gameObject);
	}
	void OnLevelWasLoaded(int level) {
		if (level == 0)
						return;
		transform.position = new Vector3 (-3.553207f, 0f, -0.01f);
		bossHealth = 1;
		horseHealth = 1;
		slugShieldHealth = 1;
		BossSpawned = false;
		trojanHorseDead = false;
	}
		// Update is called once per frame
		void Update ()
		{	if (Application.loadedLevel == 0)
						return;
			if (Time.timeScale == 0f)
				return;	
			//if(BossSpawned)
				//Debug.Log ("Boss Health: " + bossHealth);
			++score;
				
				if (score >= 2000) {
						
						if (Application.loadedLevelName == "Sharky and Trees") {
								if (!BossSpawned) {
										Instantiate (SlugBoss);
										Instantiate (SlugBossShields);
										bossHealth = 2000;
										slugShieldHealth = 1000;
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
						Application.LoadLevel (Application.loadedLevel + 1);
				}
				
				if (cheapRockets > 0) {


						--cheapRockets;

				} 
				if (spreadRockets > 0) {

						--spreadRockets;

				}

				
				// Jump
				//if (Input.GetKeyUp ("space")) {
				if (Input.GetButtonDown ("Jump")) {
						rigidbody2D.velocity = Vector2.zero;
						rigidbody2D.AddForce (jumpForce);
				}
				if (Input.GetButtonDown ("Fire1")) {

			bool fire = false;
			if (cheapRockets > 0 && score >= 50) 
			{
				score -= 50;
				fire = true;
			}
			else if (score >= 500) {
				score -= 500;
				fire = true;
			}
			
			if(fire)
			{

				if (spreadRockets > 0)
				{	shootRocket (20, 800);
					shootRocket (0, 800);
					shootRocket (-20, 800);
				}
				else
				{	shootRocket (0, 800);
				}

			}
				}

				Vector2 screenPosition = Camera.main.WorldToScreenPoint (transform.position);
				if (screenPosition.y > Screen.height || screenPosition.y < 0) {
						Die ();
				}
		}

		void shootRocket(float angle, int speed)
	{	Transform shot;
		shot = Instantiate (shotPrefab, transform.position, Quaternion.Euler(0f, 30f, angle)) as Transform;
		shot.rigidbody2D.AddForce(new Vector2(Mathf.Cos (Mathf.Deg2Rad * angle), Mathf.Sin (Mathf.Deg2Rad * angle)) * speed);
		}
		void OnGUI ()
		{
		if (Application.loadedLevel == 0)
						return;
				GUIStyle myStyle = new GUIStyle ();
				myStyle.fontSize = 25;
				myStyle.normal.textColor = Color.white;
				GUI.Label (new Rect (10, 10, 400, 30), "Score: " + score + " SpreadRockets: " + spreadRockets + " cheapRockets: " + cheapRockets, myStyle);
		}

		void OnTriggerEnter2D (Collider2D other)
		{
				if (other.gameObject.tag == "CheapAssRockets") {
						
						//itemDuration = 700;
						//HitCheapAssRockets = true;
			cheapRockets += 700;
						Destroy (other.gameObject);
				} else if (other.gameObject.tag == "SpreadRocketItem") {

						//hasSpreadRocket = true;
						//itemDuration = 700;
			spreadRockets += 700;
						Destroy (other.gameObject);
				} else if (other.gameObject.tag == "SurpriseItem") {

						Instantiate (fog);
						Destroy (other.gameObject);
				}
			if (other.gameObject.tag == "obstacle")
						Die ();
		}

		void OnCollisionEnter2D (Collision2D other)
		{
				Die ();
		}
		
		public void decreaseBossHealth ()
		{

				bossHealth -= 100;
		}
		public void killBoss()
		{	bossHealth = 0;
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
