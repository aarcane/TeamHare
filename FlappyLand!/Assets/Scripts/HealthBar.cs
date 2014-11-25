using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {
	public int maxHealth = 100; //Jump.bossHealth
	public int currentHealth = 100;
	public GUIStyle healthStyle = null;
	public float healthBarLength;
	
	// Use this for initialization
	void Start () {
		healthBarLength = Screen.width/3;
		//		healthStyle = new GUIStyle (GUI.skin.box);
	}
	
	// Update is called once per frame
	void Update () {
		//healthBarLength = (Screen.width/3) * (currentHealth/maxHealth);
		currentHealth--; //connect it to when the boss has been hit
	}
	
	void OnGUI() {
		//		GUI.backgroundColor = Color.green;
		//		healthStyle.normal.background = Color.red;
		//make it disappear when boss dies instead
		healthStyle = new GUIStyle( GUI.skin.box );
		InitStyles ();
		if (currentHealth >= 0) {
			GUI.Box (new Rect (700, 10, healthBarLength, 20), "<color=black><size=12> <b>" + currentHealth + "</b> /" + maxHealth + "</size></color>", healthStyle);
		}
	}
	
	private void InitStyles()
	{	
		if(currentHealth > (maxHealth/2))
		{
			healthStyle.normal.background = MakeTexture(700, 10, new Color( 0f, 1f, 0f, 0.5f ) );
		}
		else
		{
			healthStyle.normal.background = MakeTexture(700, 10, new Color( 1f, 0f, 0f, 0.5f ) );
		}
	}
	
	private Texture2D MakeTexture(int width, int height, Color col )
	{
		Color[] pix = new Color[width * height];
		for( int i = 0; i < pix.Length; ++i )
		{
			pix[ i ] = col;
		}
		Texture2D result = new Texture2D( width, height );
		result.SetPixels( pix );
		result.Apply();
		return result;
	}
}
