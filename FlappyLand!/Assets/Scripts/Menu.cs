using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Menu
{
	public class Menu
	{	public List <MenuBase> M { get; set; }
		public int menuSelection;
		public Menu()
		{	this.M = new List<MenuBase> ();
			menuSelection = 0;
		}
		public Menu( List<MenuBase> M)
		{	this.M = M;
			menuSelection = 0;
		}
		public void Draw (int X, int Y, int W, int H, int o, Stack<Menu> St)
		{	foreach (MenuBase m in M)
			{	m.Draw(X,ref Y, W, H, o, St);
			}
			GUI.FocusControl (M[menuSelection].N);

		}
		public void Next (bool up)
		{	if (up)
			{	if (menuSelection == 0)
					menuSelection = M.Count - 1;
				else
					menuSelection -= 1;
			} else
			{	if (menuSelection == M.Count - 1)
					menuSelection = 0;
				else
					menuSelection += 1;
			}
		}
	}
	public abstract class MenuBase
	{	public String N { get; set; }
		public MenuBase( String N )
		{	this.N = N;
		}
		public abstract void Run (Stack<Menu> St);
		public abstract void Draw (int X, ref int Y, int W, int H, int o, Stack<Menu> St);
	}
	public abstract class MenuButton: MenuBase
	{
		public MenuButton(String N): base(N) {}
		public override void Draw (int X, ref int Y, int W, int H, int o, Stack<Menu> St)
		{	GUI.SetNextControlName( N);
			if(GUI.Button ( new Rect( X, Y, W, H), new GUIContent(N, N)))
			{	Run(St);
			}
			Y += o;
		}
	}
	public class MenuItem : MenuButton
	{	public Action T { get; set; }
		public MenuItem( String N) : base(N)
		{	this.T = () => {};
		}
		public MenuItem( String N, Action T) : base(N)
		{	this.T = T;
		}
		public override void Run(Stack<Menu> St)
		{	Debug.Log (N);
			this.T ();
		}
	}
	public class MenuSub : MenuButton
	{	public Menu M { get; set; }
		public MenuSub (string N, Menu M) : base(N)
		{	this.M = M;
		}
		public MenuSub (string N) : base(N) {}
		public override void Run(Stack<Menu> St)
		{	Debug.Log ("Menu " + N);
			St.Push (this.M);
		}
	}
	public class MenuPrev : MenuButton
	{	public MenuPrev () : base("Previous") {}
		public MenuPrev (String N) : base(N) {}
		public override void Run(Stack<Menu> St)
		{	Debug.Log (N);
			St.Pop ();
		}
	}
	public class MenuQuit : MenuButton
	{	public MenuQuit () : base("Quit") {}
		public MenuQuit (String N) : base(N) {}
		public override void Run(Stack<Menu> St)
		{	Debug.Log (N);
			Application.Quit ();
		}

	}
}