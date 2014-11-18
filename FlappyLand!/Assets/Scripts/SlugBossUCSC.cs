using UnityEngine;
using System.Collections;

public class SlugBossUCSC : MonoBehaviour
{
		public Transform poopShot;
		public int maxSpeed;

		// Use this for initialization,
		void Start ()
		{
				maxSpeed = 3;
				InvokeRepeating ("shootPoop", 10f, 3f);
		}
	
		// Update is called once per frame
		void Update ()
		{
				Spawn ();

		}

		void Spawn ()
		{
				transform.position = new Vector3 (4.910788f, Mathf.Sin (Time.time * maxSpeed), transform.position.z);
		
		}

		void shootPoop ()
		{
				poopShot.tag = "obstacle";
				var poopShotTransform = Instantiate (poopShot) as Transform;
				poopShotTransform.position = transform.position;
		}
}
