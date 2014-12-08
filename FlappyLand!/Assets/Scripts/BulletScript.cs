using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour
{
	public float maxDistance;
	float distanceTravelled = 0;
	Vector3 lastPosition;
	
	void Start()
	{	lastPosition = transform.position;
	}
	
	void Update()
	{	distanceTravelled += Vector3.Distance(transform.position, lastPosition);
		lastPosition = transform.position;
		if (distanceTravelled > maxDistance)
			Destroy (gameObject);
	}

	void OnTriggerEnter2D (Collider2D other)
	{	if (other.gameObject.tag == "Player" | other.gameObject.tag == "Friendly")
			return;
		HasHealth otherHealth = other.GetComponent<HasHealth> ();
		if (otherHealth != null)
		{	otherHealth.adjustHealth (-100);
			Destroy (this.gameObject);
		} else
		{	Debug.Log ("Unknown Object: " + other.ToString());
		}
	}
}
