using UnityEngine;
using System.Collections;

public class FogDistraction : MonoBehaviour {

	public int itemDuration = 15;
	// Use this for initialization
	void Start () {
		Destroy(gameObject, itemDuration);
	}
}
