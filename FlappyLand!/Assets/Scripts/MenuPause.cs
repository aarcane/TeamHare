using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Menu;

public class MenuPause : MonoBehaviour
{	Stack <Menu.Menu> Menus;
	bool showGui = false;
	Jump J;
	void Awake ()
	{	J = Jump.instance;
		Menus = new Stack<Menu.Menu> ();
		Menus.Push(new Menu.Menu());
		List<MenuBase> menuMain = Menus.Peek ().M;
		Menu.Menu MenuCheat = new Menu.Menu ();
		List<MenuBase> menuCheat = MenuCheat.M;

		menuMain.Add (
			new MenuItem (
				"Resume",
				() => {	TogglePauseMenu();
		}));
		menuMain.Add (
			new MenuSub (
				"Cheats",
				MenuCheat
		));
		menuMain.Add ( new MenuQuit() );

		/***
		 * Add Settings subMenu items
		 */
		menuCheat.Add (
			new MenuItem (
				"Score",
				() => { J.score += 1000; 
		}));
		menuCheat.Add (
			new MenuItem (
				"Cheap",
				() => { J.cheapRockets += 1000; 
		}));
		menuCheat.Add (
			new MenuItem (
				"Spread",
				() => { J.spreadRockets += 1000; 
		}));
		menuCheat.Add (
			new MenuItem (
				"Super",
				() => { J.superSpreadRockets += 1000; 
		}));

		menuCheat.Add ( new MenuPrev () );
	}

	float savedTimeScale;
	void TogglePauseMenu ()
	{	showGui = !showGui;
		if (showGui)
		{	savedTimeScale = Time.timeScale;
			Time.timeScale = 0f;
			//Jump.instance.gameObject.SetActive(false);
		}
		else
		{	Time.timeScale = savedTimeScale;
			//Jump.instance.gameObject.SetActive(true);
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