using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MenuMain : MonoBehaviour
{	class MenuItem
	{	public string N { get; set; }
		public Action T { get; set; }
		public MenuItem( String N, Action T)
		{	this.N = N;
			this.T = T;
		}
	}
	List <MenuItem> menuOptions;
	int menuSelection;

	void Start ()
	{	menuOptions = new List<MenuItem>();
		menuSelection = 0;
		menuOptions.Add(
			new MenuItem (
				"Play FlappyLand!",
				() => {	Debug.Log ("Play FlappyLand!");
						Application.LoadLevel(1);
		}));
		menuOptions.Add(
			new MenuItem (
				"Play Infinite Mode",
				() => {	Debug.Log ("Play Infinite Mode");
						//Application.LoadLevel(0);
		}));
		menuOptions.Add(
			new MenuItem (
				"Play Level 2",
				() => {	Debug.Log ("Play Infinite Mode");
						Application.LoadLevel(2);
		}));
		menuOptions.Add(
			new MenuItem (
				"Play Level 3",
		        () => {	Debug.Log ("Play Level 3");
						Application.LoadLevel(3);
		}));
		menuOptions.Add(
			new MenuItem (
				"Settings",
				() => {	Debug.Log ("Settings");
						//Application.LoadLevel(0);
		}));
		menuOptions.Add(
			new MenuItem (
				"Quit",
				() => {	Debug.Log ("Quit");
						Application.Quit ();
		}));
	}

	void updateMenuSelection (bool up)
	{	if (up)
		{	if (menuSelection == 0)
				menuSelection = menuOptions.Count - 1;
			else
				menuSelection -= 1;
		} else
		{	if (menuSelection == menuOptions.Count - 1)
				menuSelection = 0;
			else
				menuSelection += 1;
		}
		//return menuSelection;
	}

	void Update()
	{	if (Input.GetKeyUp ("up"))
			updateMenuSelection (true);
		if (Input.GetKeyUp ("down"))
			updateMenuSelection (false);
	}

	void OnGUI()
	{	int X = Screen.width / 2 - 50;
		int Y = Screen.height / 2 - 10;
		const int W = 120;
		const int H = 30;
		const int o = 35;

		foreach (MenuItem M in menuOptions)
		{	GUI.SetNextControlName( M.N);
			if(GUI.Button ( new Rect( X, Y, W, H), M.N))
			{	M.T();
			}
			Y += o;
		}
		GUI.FocusControl (menuOptions[menuSelection].N);
		//GUILayout.EndArea ();
	}
}
