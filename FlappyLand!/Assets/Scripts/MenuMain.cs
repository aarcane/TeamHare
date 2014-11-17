using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Menu;

//namespace Menu
//{
public class MenuMain : MonoBehaviour
{	Stack <Menu.Menu> Menus;
	void Start ()
	{	Menus = new Stack<Menu.Menu> ();
		Menus.Push(new Menu.Menu());
		List<MenuBase> menuMain = Menus.Peek ().M;
		Menu.Menu MenuSettings = new Menu.Menu ();
		List<MenuBase> menuSettings = MenuSettings.M;
		menuMain.Add(
			new MenuItem (
				"Play FlappyLand!",
				() => {	Application.LoadLevel(1);
		}));
		menuMain.Add( new MenuItem ( "Play Infinite Mode" ) );
		menuMain.Add(
			new MenuItem (
				"Play Level 2",
				() => {	Application.LoadLevel(2);
		}));
		menuMain.Add(
			new MenuItem (
				"Play Level 3",
				() => {	Application.LoadLevel(3);
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

	void OnGUI()
	{	int X = Screen.width / 2 - 50;
		int Y = Screen.height / 2 - 10;
		const int W = 120;
		const int H = 30;
		const int o = 35;
		Menus.Peek().Draw (X, Y, W, H, o, Menus);
	}
}
//}