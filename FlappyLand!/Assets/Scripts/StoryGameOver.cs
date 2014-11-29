using UnityEngine;
using System.Collections;

public class StoryGameOver : MonoBehaviour {

	public GUIText yourScore;
	float oldTimeScale;
	// Use this for initialization
	void Start () {
//		yourScore = GameObject.Find ("yourscore").guiText;
		oldTimeScale = Time.timeScale;
		Time.timeScale = 0f;
		yourScore.text = Jump.instance.score.ToString ();
		StartCoroutine(exit ());
	}

	IEnumerator exit() {
		yield return new WaitForSeconds(5);
		Jump.instance.score = 0;
		Application.LoadLevel("Sharky and Trees");
	}
}
