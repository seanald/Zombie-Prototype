using UnityEngine;
using System.Collections;

public class GhostPossess : MonoBehaviour
{
	public FearPossess mytarget;
	float targetLifeTime = 20f;
	private float startTime = 20000;
	
	// Update is called once per frame
	void Update()
	{
		print(mytarget);
		if ((Input.GetKeyDown(KeyCode.T) || Input.GetKeyDown(KeyCode.JoystickButton2))&& mytarget != null)
		{
			//mytarget.Possessable.Possessed = true;
			if(this.gameObject.activeSelf)
			{
				this.gameObject.SetActive(false);
			}
			else if(!this.gameObject.activeSelf)
			{
				this.gameObject.SetActive(true);
			}
//			mytarget.GetComponent<Enemy>().moveSpeed = -100;
//			mytarget.GetComponent<BaseballWolfMovement>().dangerDistance = 2000;
//			mytarget.GetComponent<BaseballWolfMovement>().attackDistance = -1;
//			startTime = Time.time;
			
		}
//		if (Time.time - startTime >= targetLifeTime)
//		{
//			Destroy(mytarget);
//		}

	}
}
