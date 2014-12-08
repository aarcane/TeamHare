using UnityEngine;
using System.Collections;

public class InfiniteGenerator : MonoBehaviour
{

	public GameObject pipes;
	public GameObject surpriseItem;
	public GameObject moneyBags;
	public HasHealth[] Bosses;
	public int spawnBossThreshold = 2000;
	public bool spawnPipes = true;
	public bool spawnItems = true;
	public int minimumCycleTime = 5;
	public int stepCycle = 1;
	public float maximumFadeTime = 3f;
	public float fadeStep = 0.1f;

	int spawnBossTargetScore;

	bool bossSpawned = false;

	Jump J;

	void Start ()
	{	J = GameObject.FindGameObjectWithTag ("Player").GetComponent<Jump> ();
		J.isInfiniteMode = true;
		spawnBossTargetScore = spawnBossThreshold;
		InvokeRepeating ("CreateObstacle", 1f, 4f);
		InvokeRepeating("CreateRandomItem", 1f, 6f);
	}

	void Update()
	{	if (J.score > spawnBossTargetScore && !bossSpawned)
		{	int toSpawn = Random.Range (0, Bosses.Length);
			Debug.Log ("Spawning Boss: " + Bosses[toSpawn].ToString());
			HasHealth boss = Instantiate (Bosses[toSpawn]) as HasHealth;
			boss.callOnDie = bossDied;
			boss.doCallOnDie = true;
			bossSpawned = true;
	}	}

	public void bossDied()
	{	bossSpawned = false;
		makeHarder ();
		spawnBossTargetScore += spawnBossThreshold;
	}
	void makeHarder ()
	{	int backgroundCycleTime = BackgroundChangable.instance.CycleTime;
		if (backgroundCycleTime > minimumCycleTime)
		{	backgroundCycleTime -= stepCycle;
			BackgroundChangable.instance.CycleTime = backgroundCycleTime;
		}
		float backgroundCycleDuration = BackgroundChangable.instance.fadeTime;
		if (backgroundCycleDuration < maximumFadeTime)
		{	backgroundCycleDuration += fadeStep;
			BackgroundChangable.instance.fadeTime = backgroundCycleDuration;
		}
		spawnBossThreshold += 100;
	}
	void CreateRandomItem ()
	{	if (!spawnItems)
			return;
		int number = Random.Range (0, 10);

		if (number == 1) {
			CreateCheapAssRockets ();
		} else if (number == 2) {
			CreateSpreadRocketItem ();
		} else if (number == 3){
			CreateBubbleItem ();
		} else if (number == 4 ) {
			CreateSuperRocketItem ();
		} else if (number == 5) {
			CreateGravityItem ();
		} else if (number == 6) {
			CreateSpurpriseItem ();
		} else if (number == 7) {
			CreateMoneyItem ();
	}	}
	
	void CreateObstacle ()
	{	if (!spawnPipes)
			return;
		pipes.tag = "obstacle";
		Instantiate (pipes);
	}

	void CreateCheapAssRockets ()
	{
		surpriseItem.tag = "CheapAssRockets";
		Instantiate (surpriseItem);
	}

	void CreateSpreadRocketItem ()
	{
		surpriseItem.tag = "SpreadRocketItem";
		Instantiate (surpriseItem);
	}

	void CreateSpurpriseItem ()
	{
		surpriseItem.tag = "SurpriseItem";
		Instantiate (surpriseItem);
	}
	void CreateMoneyItem ()
	{
		moneyBags.tag = "MoneyItem";
		Instantiate (moneyBags);
	}

	void CreateBubbleItem ()
	{
		surpriseItem.tag = "BubbleShieldItem";
		Instantiate (surpriseItem);
	}
	
	void CreateSuperRocketItem ()
	{
		surpriseItem.tag = "SuperRocketItem";
		Instantiate (surpriseItem);
	}
	
	void CreateGravityItem ()
	{
		surpriseItem.tag = "GravityItem";
		Instantiate (surpriseItem);
	}

}