using UnityEngine;
using System.Collections;

public class Flicker : MonoBehaviour
{
	private Renderer obj;

	public void Awake()
	{
		obj = GetComponentInChildren<Renderer>();
	}

	// Use this for initialization
	public void Flash()
	{
		StartCoroutine(Flash(3f, 0.05f));
	}

	IEnumerator Flash(float time, float intervalTime)
	{
		float elapsedTime = 0f;
		int index = 0;
		while(elapsedTime < time)
		{
			if (index % 2 == 1)
			{
				this.obj.enabled = true;
			}
			else
			{
				this.obj.enabled = false;
			}
			index++;
			yield return new WaitForSeconds(intervalTime);
		}
	}
}
