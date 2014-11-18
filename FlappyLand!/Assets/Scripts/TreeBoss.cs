using UnityEngine;
using System.Collections;

public class TreeBoss : MonoBehaviour
{

		public Transform needleShot;
		public Transform pineBombs;
		public int maxSpeed;
	
		// Use this for initialization,
		void Start ()
		{
				maxSpeed = 3;
				InvokeRepeating ("chooseWeapon", 10f, 3f);
		}
	
		// Update is called once per frame
		void Update ()
		{
				Spawn ();
		
		}
	
		void Spawn ()
		{
				transform.position = new Vector3 (4.528356f, Mathf.Sin (Time.time * maxSpeed), transform.position.z);
		
		}

		void chooseWeapon ()
		{
				int number = Random.Range (1, 10);
		
				if (number % 2 == 0) {
						shootNeedles ();
						Invoke ("shootNeedles", 1);
				} else if (number % 3 == 0) {
						shootBombs ();
				} 
		}

		void shootNeedles ()
		{
				needleShot.tag = "obstacle";
				for (int i = 0; i < 3; i++) {
						var needleShotTransform = Instantiate (needleShot) as Transform;
						needleShotTransform.position = transform.position;
				}
		}

		void shootBombs ()
		{
				pineBombs.tag = "obstacle";
				var pineBombsTransform = Instantiate (pineBombs) as Transform;
				pineBombsTransform.position = transform.position;
		}
}
