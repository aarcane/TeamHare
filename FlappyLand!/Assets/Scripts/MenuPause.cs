using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Menu;

public class MenuPause : MonoBehaviour
{	Stack <Menu.Menu> Menus;
	bool showGui = false;
	void Start ()
	{	Menus = new Stack<Menu.Menu> ();
		Menus.Push(new Menu.Menu());
		List<MenuBase> menuMain = Menus.Peek ().M;
		Menu.Menu MenuSettings = new Menu.Menu ();
		List<MenuBase> menuSettings = MenuSettings.M;

		menuMain.Add (
			new MenuItem (
				"Resume",
				() => {	TogglePauseMenu();
		}));
		menuMain.Add (
			new MenuSub (
				"Settings",
				MenuSettings
		));
		menuMain.Add ( new MenuQuit() );

		/***
		 * Add Settings subMenu items
		 */
		menuSettings.Add (
			new MenuItem (
				"Screen Resolution",
				() => {	}
		));
		menuSettings.Add (
			new MenuItem (
				"Music Volume",
				() => {	Debug.Log ("Music Volume");
		}));
		menuSettings.Add (
			new MenuItem (
				"SFX Volume",
				() => {	Debug.Log ("SFX Volume");
		}));
		menuSettings.Add (new MenuPrev ());
	}

	float savedTimeScale;
	void TogglePauseMenu ()
	{	showGui = !showGui;
		if (showGui)
		{	savedTimeScale = Time.timeScale;
			Time.timeScale = 0f;
		}
		else
		{	Time.timeScale = savedTimeScale;	
		}
	}

	void Update()
	{	if (Input.GetKeyDown (KeyCode.Escape))
			TogglePauseMenu ();

		if (showGui)
		{	if (Input.GetKeyUp ("up"))
				Menus.Peek ().Next (true);
			if (Input.GetKeyUp ("down"))
				Menus.Peek ().Next (false);
		}
	}
	
	void OnGUI()
	{	if(showGui)
		{	int X = Screen.width / 2 - 50;
			int Y = Screen.height / 2 - 10;
			const int W = 120;
			const int H = 30;
			const int o = 35;
			Menus.Peek().Draw (X, Y, W, H, o, Menus);
		}
	}
}