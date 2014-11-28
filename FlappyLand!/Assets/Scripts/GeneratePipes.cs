using UnityEngine;
using System.Collections;

public class GeneratePipes : MonoBehaviour
{

		public GameObject pipes;
		public GameObject surpriseItem;
		public GameObject moneyBags;

		void Start ()
		{
		if (Application.loadedLevelName != "Frost Boss") {
						InvokeRepeating ("CreateObstacle", 1f, 4f);
				}
				InvokeRepeating("CreateRandomItem", 1f, 6f);
		}

		void CreateRandomItem ()
		{
				int number = Random.Range (0, 10);
		
				if (number == 1) {
					CreateCheapAssRockets ();
				} else if (number == 2) {
					CreateSpreadRocketItem ();
				} else if (number == 3){
					CreateBubbleItem ();
				} else if (number == 4 ) {
					CreateSuperRocketItem ();
				} else if (number == 5) {
					CreateGravityItem ();
				} else if (number == 6) {
					CreateGravityItem ();
				} else if (number == 7) {
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