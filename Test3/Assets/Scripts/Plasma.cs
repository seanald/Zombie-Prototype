using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Plasma : MonoBehaviour {

	public Slider plasmaSlider;
	public int maxPlasma;

	private int curPlasma;

	void Start()
	{
		this.plasmaSlider.maxValue = this.maxPlasma;
		this.curPlasma = this.maxPlasma;
	}
	// Update is called once per frame
	void Update () 
	{
		this.plasmaSlider.value = this.curPlasma;
		if(curPlasma < maxPlasma)
		{
			curPlasma++;
		}
	}
}
