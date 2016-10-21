using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {

	public float spawnRate;//the rate at which capacity refreshes
	private float enemyCooldown;//the time since the last enemy spawn, it starts when the current Capacity becomes 0
	public float spawnCapacity;//the higher the capacity the more enemies can be summoned per spawn
	private float remainingCapacity = 0;//a counter for the spawnCapaciity
	public float spawnPulseTime;//each pulse an enemy could be spawn
	private float currentPulse;//a timer for the pulse

	public Object demonHarpy;//the Demon Harpy prefab
	public float harpySpeed;
	public float harpyThreatValue;
	public Object demonSkull;//the Demon Skull prefab
	public float skullThreatValue;
	//the threat value determines how many instances of the enemy can be summoned per spawn
	//the lower the value, the more enemies can be spawn

	public Transform cameraPosition;//the position of the player, duh

	public float graceTime;//the time in the beggining of the game during which enemies don't spawn

	private GameObject[] enemies;//a catalog of all enemie objects currently in the scene

	void Start () {
		enemyCooldown = Time.time + graceTime;//a time in the beginning of the game, when enemies don't spawn
		currentPulse = Time.time + spawnPulseTime;
	}
	
	// Update is called once per frame
	void Update () {
		enemies = GameObject.FindGameObjectsWithTag ("Enemy");//all enemie entities are found and saved into the array
		foreach (GameObject enemy in enemies) {//a cycle is run 
			Transform enemyPos = enemy.GetComponent<Transform>();
			if(enemyPos.position.x < cameraPosition.position.x - 30)//for each enemy it checks if it is so far back, that it can't be seen
				Destroy(enemy);//if it is than it is destroyed in order to reduce cpu and memory usage			
				}
		//the capacity remaining capacity is refilled after the amount of time
		if (Time.time > enemyCooldown) {
			remainingCapacity = spawnCapacity;
			enemyCooldown = Time.time + spawnRate;
				}
		
		//this code is activated each pulse
		if (Time.time >= currentPulse) {
			currentPulse = Time.time + spawnPulseTime;//the pulse timer is reset

			//harpy summoning code
			if(remainingCapacity >= harpyThreatValue)
				if(Random.Range (0,100) <= 10){
				remainingCapacity -= harpyThreatValue;//each pulse if the remaining capacity is more than the harpy threat value
				//there is a 25% chance for a harpy to be summoned, if that happens, the capaciry is reduced with the harpy threat value amount

				//the position in with the harpy will be summoned
				Vector3 harpyPos = new Vector3(cameraPosition.position.x + 30, Random.Range(-14f,14f),20);
				//a harpy is instantiated in that position
				GameObject harpy = Instantiate(demonHarpy,harpyPos,Quaternion.identity) as GameObject;

				HarpyMovement harpyScript = harpy.GetComponent<HarpyMovement>();// a reference to the script of the harpy
				harpyScript.curveDepth = 8*Mathf.Abs(harpyPos.y)/14;//we adjust the depth of the curve the harpy flies in depending on how low/high it was spawn
				harpyScript.speed = harpySpeed;//we set the speed at which the harpy is going to move
				harpy.renderer.sortingLayerName = "DemonHarpy";//we set the sorting layer of the harpy

				if(harpyPos.y > 0)//if the harpy is spawn below the equator we flip it
				{
					harpyScript.curveDepth = - harpyScript.curveDepth;
					Transform harpyTrans = harpy.GetComponent<Transform>();
					harpyTrans.localScale.Set(- harpyTrans.localScale.x,harpyTrans.localScale.y,harpyTrans.localScale.z);
				}

			}

			//skull summoning code
			if(remainingCapacity >= skullThreatValue)
				if(Random.Range (0,100) <= 15){
				remainingCapacity -= skullThreatValue;//simmilar to the harpy summmoning
				//each pulse there is a 25% for a skull to be summoned

				Vector3 skullPos = new Vector3(cameraPosition.position.x + 30, Random.Range(-12.5f,12.5f),20);
				GameObject skull = Instantiate(demonSkull,skullPos,new Quaternion(0,0,90,90)) as GameObject;
				skull.renderer.sortingLayerName = "DemonHarpy";
			}

			//alternate skull summoning - likely to be in the center
			if(remainingCapacity >= skullThreatValue)
			if(Random.Range (0,100) <= 7){
				remainingCapacity -= skullThreatValue;//simmilar to the harpy summmoning
				//each pulse there is a 25% for a skull to be summoned
				
				Vector3 skullPos = new Vector3(cameraPosition.position.x + 30, Random.Range(-5.5f,5.5f),20);
				GameObject skull = Instantiate(demonSkull,skullPos,new Quaternion(0,0,90,90)) as GameObject;
				skull.renderer.sortingLayerName = "DemonHarpy";
			}
		}		
	}
}
