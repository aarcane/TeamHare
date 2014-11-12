using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	//void Start()
	//{	Debug.Log("Start()");
	//}

	// Update is called once per frame
	//void Update()
	//{	Debug.Log("Update()");
	//}

	void OnGui()
	{	Debug.Log("OnGui()");
		// Make a background box
		GUI.Box(new Rect(10,10,100,90), "Loader Menu");
		
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(20,40,80,20), "Level 1")) {
			Application.LoadLevel(1);
		}
		
		// Make the second button.
		if(GUI.Button(new Rect(20,70,80,20), "Level 2")) {
			Application.LoadLevel(2);
		}

		//if(GUI.Button(new Rect (Screen.width / 2 - 50, Screen.height / 2 - 100, 100, 30), "Play FlappyLand!"))
		//new Rect (10, 10, 100, 30), 
		//if(GUILayout.Button("Play FlappyLand!"))
		//{	Debug.Log ("Play FlappyLand!");
		//}
	}
}
