using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{	
	private GameObject[] enemiesInScene;
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
		foreach(GameObject enemy in this.spawnNumberArray)
		{
			GameObject newEnemy = Instantiate(enemy, this.transform.position + rightoffest, this.transform.rotation) as GameObject;
		}
	}

	void OnTriggerEnter(Collider c)
	{
		if (!this.isActive)
		{
			this.isActive = true;
			tempLeft = Instantiate(leftBound, this.transform.position + leftoffset, this.transform.rotation);
			tempRight = Instantiate(rightBound, this.transform.position + rightoffest, this.transform.rotation);
		}

	}
}
