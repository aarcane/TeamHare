using UnityEngine;
using System.Collections;

public class ProtectionBubbleItem : MonoBehaviour
{

		void OnTriggerEnter2D (Collider2D other)
		{
				if (other.tag != "Player" && other.tag != "Rocket" && other.tag != "SurpriseItem" 
						&& other.tag != "MoneyItem" && other.tag != "CheapAssRockets" && other.tag != "SpreadRocketItem"
		    && other.tag != "BubbleShieldItem" && other.tag != "SuperRocketItem" && other.tag != "GravityItem" && other.tag != "Friendly") {
						Destroy (other.gameObject);			
						GameObject player = GameObject.FindGameObjectWithTag ("Player");
						player.gameObject.GetComponent<Jump> ().disableBubbleShield ();
						Destroy (this.gameObject);
						
				}
		}
}
