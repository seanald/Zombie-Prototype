using UnityEngine;
using System.Collections;

public class Plasma : MonoBehaviour {

	public int maxPlasma;

	private int curPlasma;
	// Update is called once per frame
	void Update () 
	{
		if(curPlasma < maxPlasma)
		{
			curPlasma++;
		}
	}
}
