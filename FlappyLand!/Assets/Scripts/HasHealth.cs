using UnityEngine;
using System.Collections;

public class HasHealth : MonoBehaviour {
	public int health = 1;
	public bool isBoss = false;
	void Update() {}
	public void adjustHealth(int delta)
	{
		Debug.Log ("Old Health: " + health + ", New Health: " + (health + delta));
		health += delta;
		if (dead ())
			Destroy (this.gameObject);
	}
	bool dead()
	{
		return (health <= 0);
	}
	public void onDestroy()
	{	Debug.Log ("Destroying " + ToString());
		if (isBoss)
		{	GameObject.FindGameObjectWithTag ("Player").gameObject.GetComponent<Jump> ().BossSpawned = false;
			Application.LoadLevel (Application.loadedLevel + 1);
		}
	}
}
