using UnityEngine;
using System.Collections;

public class CheapAssRocketsScript : MonoBehaviour
{
	
		public Vector2 velocity = new Vector2 (-9, 0);
		public float rangeY = 1.5f;
	
		// Use this for initialization
		void Start ()
		{
				Destroy (gameObject, 30);
				rigidbody2D.velocity = velocity;
				transform.position = new Vector3 (transform.position.x, transform.position.y - rangeY * Random.value, transform.position.z);
		}

		/*void OnTriggerEnter2D (Collider2D other)
		{
				if (other.gameObject.tag == "Player") {
						Destroy (this.gameObject);
						Debug.Log ("CAR Collide");
				}
		}*/

		/*void OnCollisionEnter2D (Collision2D other)
		{
				if (other.gameObject.tag == "Player") {
						Destroy (this.gameObject);
						Debug.Log ("CAR Collide");
				}
		}*/
}
