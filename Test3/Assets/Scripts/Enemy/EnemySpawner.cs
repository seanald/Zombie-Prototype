using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{	
	private GameObject[] enemiesInScene;
    //public Transform[] spawnPointsLeft; //chris added
    //public Transform[] spawnPointsRight; // chris added
	private List<GameObject> spawnNumberArray;
	public List<GameObject> spawnQueueArray;
	public int spawnNumber;
	public GameObject leftBound;
	public GameObject rightBound;
	private Vector3 rightoffest = new Vector3(1000,0,0);
	private Vector3 leftoffset = new Vector3(-1000,0,0);
	public Object tempLeft;
	public Object tempRight;
	private bool isActive;
	public List<string> side;

    //int spawnPointIndex = Random.Range (0, spawnPointsLeft.Length);
    //int spawnPointIndexRight = Random.Range(0, spawnPointsRight.Length); 

	// Use this for initialization
	void Start()
	{
		this.spawnNumberArray = this.spawnQueueArray.GetRange(0, this.spawnNumber);
		this.spawnQueueArray.RemoveRange(0, this.spawnNumber);
	}
	
	// Update is called once per frame
	void Update()
	{
		if (this.isActive)
		{
			enemiesInScene = GameObject.FindGameObjectsWithTag("Enemy");
			if (enemiesInScene.Length > 0)
			{
				print(enemiesInScene.Length);
			}

			if (enemiesInScene.Length == 0)
			{
				this.spawnNumberArray.Clear();
				if (this.spawnNumber > this.spawnQueueArray.Count)
				{
					this.spawnNumber = this.spawnQueueArray.Count;
				}
				this.spawnNumberArray = this.spawnQueueArray.GetRange(0, this.spawnNumber);
				this.spawnQueueArray.RemoveRange(0, this.spawnNumber);
				this.side.RemoveRange(0, this.spawnNumber);
				this.Spawn();
			}
			if (enemiesInScene.Length == 0 && this.spawnNumber == 0)
			{
				Destroy(tempRight);
				Destroy(tempLeft);
				Destroy(this.gameObject);
			}
		}
	}

	public void Spawn()
	{
		int i = 0;
		foreach(GameObject enemy in this.spawnNumberArray)
		{
			if(side[i]=="right"){
				GameObject newEnemy = Instantiate(enemy, this.transform.position + rightoffest, this.transform.rotation) as GameObject;
			}
			if(side[i]=="left"){
				GameObject newEnemy = Instantiate(enemy, this.transform.position - rightoffest, this.transform.rotation) as GameObject;
			}
			i++;
		}
	}

	void OnTriggerEnter(Collider c)
	{
		if(c.gameObject.tag == "Player")
		{
			if (!this.isActive)
			{
				this.isActive = true;
				tempLeft = Instantiate(leftBound, this.transform.position + leftoffset, this.transform.rotation);
				tempRight = Instantiate(rightBound, this.transform.position + rightoffest, this.transform.rotation);
				this.Spawn();
			}
		}

	}
}
