using UnityEngine;
using System.Collections;

public class StoryGameOver : MonoBehaviour {

	public GUIText yourScore;
	
	// Use this for initialization
	void Start () {
//		yourScore = GameObject.Find ("yourscore").guiText;
		
		yourScore.text = Jump.score.ToString ();
		StartCoroutine(exit ());
	}

	IEnumerator exit() {
		yield return new WaitForSeconds(5);
		Jump.score = 0;
		Application.LoadLevel("Sharky and Trees");
	}
}
