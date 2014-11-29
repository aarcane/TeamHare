using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Menu;

public class MenuMain : MonoBehaviour
{	Stack <Menu.Menu> Menus;
	void Start ()
	{	Jump.instance.gameObject.SetActive (false);
		Menus = new Stack<Menu.Menu> ();
		Menus.Push(new Menu.Menu());
		List<MenuBase> menuMain = Menus.Peek ().M;
		Menu.Menu MenuSettings = new Menu.Menu ();
		List<MenuBase> menuSettings = MenuSettings.M;
		//Time.timeScale = 0f;
		/***
		 * Add Main Menu items
		 */

		menuMain.Add(
			new MenuItem (
				"Play FlappyLand!",
				() => {	LoadLevel(1);
						
		}));
		menuMain.Add( new MenuItem ( "Play Infinite Mode" ) );
		menuMain.Add(
			new MenuItem (
				"Play Level 2",
				() => {	LoadLevel(2);
		}));
		menuMain.Add(
			new MenuItem (
				"Play Level 3",
				() => {	LoadLevel(3);
		}));
		menuMain.Add(
			new MenuItem (
				"Play Beach Level",
				() => {	LoadLevel(5);
		}));
		menuMain.Add(
			new MenuItem (
				"Play Final Level",
				() => {	LoadLevel(6);
		}));
		menuMain.Add(
			new MenuItem (
				"Play Plains Level",
				() => {	LoadLevel(4);
		}));
		menuMain.Add(
			new MenuSub (
				"Settings",
				MenuSettings
		));
		menuMain.Add( new MenuQuit () );

		/***
		 * Add Settings subMenu items
		 */
		menuSettings.Add ( new MenuItem ( "Screen Resolution" ) );
		menuSettings.Add ( new MenuItem ( "Music Volume" ) );
		menuSettings.Add ( new MenuItem ( "SFX Volume" ) );
		menuSettings.Add ( new MenuPrev () );
	}

	void Update()
	{	if (Input.GetKeyUp ("up"))
			Menus.Peek().Next (true);
		if (Input.GetKeyUp ("down"))
			Menus.Peek().Next (false);
	}
	void LoadLevel(int levelNum)
	{	Jump.instance.gameObject.SetActive (true);
		Application.LoadLevel (levelNum);
	}
	void OnGUI()
	{	int X = Screen.width / 2 - 50;
		int Y = Screen.height / 2 - 10;
		const int W = 120;
		const int H = 30;
		const int o = 35;
		Menus.Peek().Draw (X, Y, W, H, o, Menus);
	}
}