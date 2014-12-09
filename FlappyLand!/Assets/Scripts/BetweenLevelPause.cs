using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Menu;

public class BetweenLevelPause : MonoBehaviour
{	public float delay = 10f;
	void Start ()
	{	Jump.instance.gameObject.SetActive (false);
		Invoke ("LoadLevel", delay);
	}

	void LoadLevel()
	{	Jump.instance.gameObject.SetActive (true);
		Application.LoadLevel (Application.loadedLevel+1);
	}
}