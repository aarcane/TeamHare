using UnityEngine;
using System.Collections;

public class GeneratePipes : MonoBehaviour
{

		public GameObject pipes;
		public GameObject cheapAssRockets;
		public GameObject spreadRocket;
		public GameObject surpriseItem;

		// Use this for initialization
		void Start ()
		{
				InvokeRepeating ("CreateObstacle", 1f, 4f);
				InvokeRepeating("CreateRandomItem", 1f, 6f);
				//	InvokeRepeating ("CreateSpreadRocketItem", 1f, 4f); 
				//	InvokeRepeating ("CreateSpurpriseItem", 1f, 6f); 
		}

		void CreateRandomItem ()
		{
				int number = Random.Range (1, 10);
		
				if (number % 2 == 0) {
						CreateSpreadRocketItem ();
				} else if (number % 3 == 0) {
						CreateCheapAssRockets ();
				} else {
						CreateSpurpriseItem ();
				}

		}

		void CreateObstacle ()
		{
				pipes.tag = "obstacle";
				Instantiate (pipes);
		}

		void CreateCheapAssRockets ()
		{
				cheapAssRockets.tag = "CheapAssRockets";
				Instantiate (cheapAssRockets);
		}

		void CreateSpreadRocketItem ()
		{
				spreadRocket.tag = "SpreadRocketItem";
				Instantiate (spreadRocket);
		}

		void CreateSpurpriseItem ()
		{
				spreadRocket.tag = "SurpriseItem";
				Instantiate (surpriseItem);
		}
}