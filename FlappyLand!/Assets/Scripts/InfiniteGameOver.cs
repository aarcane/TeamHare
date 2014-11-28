using UnityEngine;
using System.Collections;

public class InfiniteGameOver : MonoBehaviour {
	
	public GUIText yourScore;
	public GUIText highScore;
	public int myScore;
	public int bestScore;

	// Use this for initialization
	void Start () {
//		yourScore = GameObject.Find ("yourscore").guiText;
//		highScore = GameObject.Find ("highscore").guiText;

		myScore = Jump.score;
		bestScore = Jump.bestScore;

//		print (myScore);

		if (myScore > bestScore) 
		{
			bestScore = myScore;
		} 

		yourScore.text = myScore.ToString ();
		highScore.text = bestScore.ToString ();
		StartCoroutine(exit ());
	}
	
	// Update is called once per frame
	void Update () {
	}

	IEnumerator exit() {
		yield return new WaitForSeconds(5);
		Jump.score = 0;
		Jump.bestScore = bestScore;
		Application.LoadLevel("Sharky and Trees");
	}
}
