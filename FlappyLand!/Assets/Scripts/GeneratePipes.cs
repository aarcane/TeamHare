using UnityEngine;
using System.Collections;

public class GeneratePipes : MonoBehaviour
{

		public GameObject pipes;
		public GameObject surpriseItem;

		void Start ()
		{
				InvokeRepeating ("CreateObstacle", 1f, 4f);
				InvokeRepeating("CreateRandomItem", 1f, 6f);
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
}