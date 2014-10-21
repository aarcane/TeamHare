using UnityEngine;
using System.Collections;

public class GeneratePipes : MonoBehaviour {

	public GameObject pipes;
	public GameObject cheapAssRockets;
	public GameObject spreadRocket;

	// Use this for initialization
	void Start()
	{
		InvokeRepeating("CreateObstacle", 1f, 4f);
		InvokeRepeating("CreateCheapAssRockets", 1f, 4f);
		InvokeRepeating ("CreateSpreadRocketItem", 1f, 4f); 
	}


	void CreateObstacle()
	{
		pipes.tag = "obstacle";
		Instantiate(pipes);
	}

	void CreateCheapAssRockets()
	{
		cheapAssRockets.tag = "CheapAssRockets";
		Instantiate(cheapAssRockets);
	}

	void CreateSpreadRocketItem()
	{
		spreadRocket.tag = "SpreadRocketItem";
		Instantiate (spreadRocket);
	}
	
}