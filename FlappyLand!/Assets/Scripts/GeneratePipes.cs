using UnityEngine;
using System.Collections;

public class GeneratePipes : MonoBehaviour
{

		public GameObject pipes;
		public GameObject surpriseItem;
		public GameObject moneyBags;
		public GameObject spawnBoss;
		public GameObject[] spawnEnemies;
		public float spawnEnemiesTime;
		public int spawnBossThreshold = 2000;
		public bool spawnPipes = true;
		public bool spawnItems = true;
		bool bossSpawned = false;
		Jump J;

		void Start ()
		{
				J = GameObject.FindGameObjectWithTag ("Player").GetComponent<Jump> (); 
				if (spawnPipes)
						InvokeRepeating ("CreateObstacle", 1f, 4f);
				if (spawnItems)
						InvokeRepeating ("CreateRandomItem", 1f, 6f);
				if(spawnEnemiesTime > 0 && spawnEnemies.Length > 0)
					InvokeRepeating ("CreateRandomEnemy", 1f, spawnEnemiesTime);
		}

		void Update ()
		{
				if (J.score > spawnBossThreshold && !bossSpawned) {
						Debug.Log ("Spawning Boss: " + spawnBoss.ToString ());
						Instantiate (spawnBoss);
						bossSpawned = true;
				}
		}

		void CreateRandomItem ()
		{
				int number = Random.Range (0, 10);

				if (number == 1) {
						CreateCheapAssRockets ();
				} else if (number == 2) {
						CreateSpreadRocketItem ();
				} else if (number == 3) {
						CreateBubbleItem ();
				} else if (number == 4) {
						CreateSuperRocketItem ();
				} else if (number == 5) {
						CreateGravityItem ();
				} else if (number == 6) {
						CreateSpurpriseItem ();
				} else if (number == 7) {
						CreateMoneyItem ();
				}
		}
		void CreateRandomEnemy ()
		{	int sp = Random.Range (0, spawnEnemies.Length);
			GameObject spawn = Instantiate(spawnEnemies[sp]) as GameObject;
		}
		void CreateObstacle ()
		{
				pipes.tag = "obstacle";
				Instantiate (pipes);
		}

		void CreateCheapAssRockets ()
		{
				surpriseItem.tag = "CheapAssRockets";
				Instantiate (surpriseItem);
		}

		void CreateSpreadRocketItem ()
		{
				surpriseItem.tag = "SpreadRocketItem";
				Instantiate (surpriseItem);
		}

		void CreateSpurpriseItem ()
		{
				surpriseItem.tag = "SurpriseItem";
				Instantiate (surpriseItem);
		}

		void CreateMoneyItem ()
		{
				moneyBags.tag = "MoneyItem";
				Instantiate (moneyBags);
		}

		void CreateBubbleItem ()
		{
				surpriseItem.tag = "BubbleShieldItem";
				Instantiate (surpriseItem);
		}
	
		void CreateSuperRocketItem ()
		{
				surpriseItem.tag = "SuperRocketItem";
				Instantiate (surpriseItem);
		}
	
		void CreateGravityItem ()
		{
				surpriseItem.tag = "GravityItem";
				Instantiate (surpriseItem);
		}

}