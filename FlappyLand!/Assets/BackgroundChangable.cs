using UnityEngine;
using System.Collections;

public class BackgroundChangable : MonoBehaviour
{
	/***
	 * This array contains the available backgrounds, one of which is
	 * chosen randomly.
	 */
	public SpriteRenderer[] backgrounds;
	int prev;
	int current;
	bool fadeIn = false;
	bool fadeOut = false;
	public float fadeTime;
	public int CycleTime;
	int currentCycleTime;
	float fadeStart = 0f;
	// Use this for initialization
	void Start ()
	{	for (int i = 0; i < backgrounds.Length; ++i)
		{	backgrounds[i] = Instantiate(backgrounds[i]) as SpriteRenderer;
			backgrounds[i].color = new Color(1f, 1f, 1f, 0f);
		}
		Time.timeScale = 1f;
		current = prev = 0;
		SelectNextBackground ();
		fadeOut = false;
		fadeIn = false;
		backgrounds [current].color = new Color (1f, 1f, 1f, 1f);
		if(CycleTime > 0)
			InvokeRepeating ("SwitchBackground", 1f, 1f);
	}

	// Update is called once per frame
	void Update ()
	{	float Fade = Mathf.SmoothStep(0f, 1f, ((Time.time - fadeStart) / fadeTime));
		if (fadeIn)
			backgrounds[current].color = new Color(1f, 1f, 1f, Fade);

		if (fadeOut)
			backgrounds[prev].color = new Color(1f, 1f, 1f, (1-Fade));

		if (Fade >= 1f)
		{	fadeIn = false;
			fadeOut = false;
			backgrounds[current].color = new Color(1f, 1f, 1f, 1f);
			backgrounds[prev].color = new Color(1f, 1f, 1f, 0f);
	}	}
	void SelectNextBackground ()
	{	prev = current;
		Debug.Log ("SelectNextBackground()");
		while (prev == current)
			current = Random.Range (0, backgrounds.Length);
		currentCycleTime = CycleTime;
		fadeStart = Time.time;
		fadeIn = true;
		fadeOut = true;
	}
	void SwitchBackground()
	{	Debug.Log ("Random.Range(0, " + currentCycleTime);
		if (Random.Range (0, currentCycleTime) == 0)
			SelectNextBackground();
		else
			--currentCycleTime;
}	}
