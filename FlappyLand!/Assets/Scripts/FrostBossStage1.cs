using UnityEngine;
using System.Collections;

public class FrostBossStage1 : MonoBehaviour
{

		public Transform piShot;
		public Transform pieShot;
		public Transform trojanShield;
		public Transform mushroomShield;
		public int maxSpeed;
	
		// Use this for initialization,
		void Start ()
		{
				maxSpeed = 3;
				//InvokeRepeating ("bossPieShot", 2f, 2f);
				//StartCoroutine (bossPieShot ());
				InvokeRepeating ("shoot", 1f, 1f);
		}
	
		// Update is called once per frame
		void Update ()
		{
				Spawn ();
		
		}
	
		void Spawn ()
		{
				transform.position = new Vector3 (5.28607f, 2 * (Mathf.Sin (Time.time * maxSpeed)), transform.position.z);
		
		}

		void shoot ()
		{
				int number = Random.Range (1, 30);

				if (number % 2 == 0) {
						StartCoroutine (bossPieShot ());
				} 
				if (number % 3 == 0) {
						makeMushroomShield ();
				} else {
						makeShield ();
				}
		}

		IEnumerator bossPieShot ()
		{
				
				shootPi (0);
				yield return new WaitForSeconds (.1f);
				shootPie (0);
				yield return new WaitForSeconds (.2f);
				shootPie (0);
				yield return new WaitForSeconds (.3f);			
				shootPi (0);
				yield return new WaitForSeconds (.4f);
				
		}

		void shootPi (float position)
		{
				piShot.tag = "obstacle";
				Transform piShotTransform = Instantiate (piShot, transform.position + new Vector3 (0.0f, position, 0.0f), Quaternion.identity) as Transform;
		}

		void shootPie (float position)
		{
				pieShot.tag = "obstacle";
				Transform pieShotTransform = Instantiate (pieShot, transform.position + new Vector3 (0.0f, position, 0.0f), Quaternion.identity) as Transform;
		}

		void makeShield ()
		{
				trojanShield.tag = "obstacle";
				trojanShield.gameObject.GetComponent<HasHealth> ().health = 900;
				Instantiate (trojanShield);
		}

		void makeMushroomShield ()
		{
				mushroomShield.tag = "obstacle";
				mushroomShield.gameObject.GetComponent<HasHealth> ().health =  1000;
				Instantiate (mushroomShield);
		}
}
