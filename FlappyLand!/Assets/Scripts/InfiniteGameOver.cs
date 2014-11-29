using UnityEngine;
using System.Collections;

public class InfiniteGameOver : MonoBehaviour {
	
	public GUIText yourScore;
	public GUIText highScore;
	int myScore;
	int bestScore;
	float oldTimeScale;
	// Use this for initialization
	void Start () {
//		yourScore = GameObject.Find ("yourscore").guiText;
//		highScore = GameObject.Find ("highscore").guiText;
		oldTimeScale = Time.timeScale;
		Time.timeScale = 0f;
		myScore = Jump.instance.score;
		bestScore = Jump.instance.bestScore;

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
		Jump.instance.score = 0;
		Jump.instance.bestScore = bestScore;
		Time.timeScale = oldTimeScale;
		Application.LoadLevel(1);
	}
}
