using UnityEngine;
using System.Collections;

public class GeneratePipes : MonoBehaviour
{

		public GameObject pipes;
		public GameObject cheapAssRockets;
		public GameObject spreadRocket;
		public GameObject surpriseItem;
		public GameObject BubbleItem;
		public GameObject superRocketItem;
		public GameObject gravityItem;
		public GameObject moneyBags;
		// Use this for initialization
		void Start ()
		{
				InvokeRepeating ("CreateObstacle", 1f, 4f);
				InvokeRepeating ("CreateRandomItem", 1f, 6f);
		}

		void CreateRandomItem ()
		{
				int number = Random.Range (1, 10);
				int choice = Random.Range (1, 2);
				if (number % 2 == 0) {
						if (choice == 2) {
								CreateSpreadRocketItem ();
						} else {

								CreateSuperRocketItem ();
						}
				} else if (number % 3 == 0) {
						CreateCheapAssRockets ();
				} else if (number % 4 == 0) {
						CreateBubbleItem ();
				} else if (number % 5 == 0) {
						CreateGravityItem ();
				} else {
						CreateMoneyItem ();
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
				BubbleItem.tag = "BubbleShieldItem";
				Instantiate (BubbleItem);
		}

		void CreateSuperRocketItem ()
		{
				superRocketItem.tag = "SuperRocketItem";
				Instantiate (superRocketItem);
		}

		void CreateGravityItem ()
		{
				gravityItem.tag = "GravityItem";
				Instantiate (gravityItem);
		}
}