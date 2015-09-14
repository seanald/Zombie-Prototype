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
		InvokeRepeating("restorePlasma", 0, 0.2f);
	}
	// Update is called once per frame
	void Update () 
	{
		this.plasmaSlider.value = this.curPlasma;
		if (this.curPlasma == 0)
		{

		}

	}

	private void restorePlasma()
	{
		curPlasma++;
	}

	void Example() {
		InvokeRepeating("restorePlasma", 2, 1);
	}

	public void usePlasma(int plasma)
	{
		if (this.curPlasma > 0)
		{
			this.curPlasma -= plasma;
		}
	}

	public int getCurPlasma()
	{
		return this.curPlasma;
	}
}
