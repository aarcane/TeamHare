﻿using UnityEngine;
using System.Collections;

public class HasHealth : MonoBehaviour {
	public int health = 1;
	public bool isBoss = false;
	int currentHealth;
	GUIStyle healthBarStyle;
	GUIStyle healthBoxStyle;
	int healthBarLength;
	public GameObject spawnNext = null;

	//Only used in Infinite mode to provide a callback for the bosses 
	// to notify the objectSpawner so it knows when the boss has died.
	public bool doCallOnDie = false;
	public delegate void delegateCallOnDie ();
	public delegateCallOnDie callOnDie;

	void Update() {}

	void Start () {
		healthBarLength = Screen.width/3;
		currentHealth = health;
	}

	void OnGUI() {
		if (!isBoss)
			return;
		healthBarStyle = new GUIStyle( GUI.skin.box );
		healthBoxStyle = new GUIStyle (GUI.skin.box);
		InitStyles ();
		if (currentHealth >= 0) {
			float healthPercent = (float)currentHealth / (float)health;
			Rect currentHealthBar = new Rect (900, 15, healthBarLength * healthPercent, 20);
			Rect fullHealthBar = new Rect (900, 15, healthBarLength, 20); 
			//GUI.Box (new Rect(699, 9, healthBarLength+2, 22), string.Empty);
			//GUI.Box (new Rect (700, 10, healthBarLength, 20), "<color=black><size=12> <b>" + currentHealth + "</b> /" + health + "</size></color>", healthStyle);
			GUI.Box (fullHealthBar, "" + currentHealth + " / " + health + "", healthBoxStyle);
			GUI.Label (currentHealthBar,  "", healthBarStyle);
		}
	}

	private void InitStyles()
	{	healthBoxStyle.fontSize = 12;
		healthBoxStyle.fontStyle = FontStyle.Bold;
		healthBoxStyle.border.left = 1;
		healthBoxStyle.border.right = 1;
		healthBoxStyle.border.top = 1;
		healthBoxStyle.border.bottom = 1;
		healthBarStyle.normal.background = MakeTexture (healthBarLength, 10, new Color (2.0f *(1- ((float)currentHealth / (float)health)), 2.0f*((float)currentHealth / (float)health), 0f, 0.5f));
	}

	private Texture2D MakeTexture(int width, int height, Color col )
	{
		Color[] pix = new Color[width * height];
		for( int i = 0; i < pix.Length; ++i )
			pix[ i ] = col;
		Texture2D result = new Texture2D( width, height );
		result.SetPixels( pix );
		result.Apply();
		return result;
	}

	public void adjustHealth(int delta)
	{	Debug.Log ("Old Health: " + currentHealth + ", New Health: " + (currentHealth + delta));
		currentHealth += delta;
		die ();
	}

	bool dead() { return (currentHealth <= 0); }

	public void die(bool force = false)
	{	if (!dead () && !force)
			return;
		Debug.Log ("Destroying " + ToString());
		if (doCallOnDie)
		{	callOnDie ();
		} else if (spawnNext != null)
		{	HasHealth H = Instantiate(spawnNext) as HasHealth;
			//if(doCallOnDie)
			//{	H.doCallOnDie = doCallOnDie;
			//	H.callOnDie = callOnDie;
			//}
		} else if (isBoss)
		{	Application.LoadLevel (Application.loadedLevel + 1);
		}

		Destroy (this.gameObject);
	}
}
