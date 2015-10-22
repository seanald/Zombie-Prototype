using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Plasma : MonoBehaviour
{

	public int maxPlasma = 100;
	private int curPlasma = 100;

	public Slider plasmaBar;

	void Start()
	{
		this.curPlasma = this.maxPlasma;
	}

	void Update()
	{
		if (this.plasmaBar != null)
		{
			this.plasmaBar.maxValue = this.maxPlasma;
			this.plasmaBar.value = this.curPlasma;
		}
	}


	public void AddPlasma(int hp)
	{
		curPlasma += hp;
		if (curPlasma > maxPlasma)
		{
			curPlasma = maxPlasma;
		}
	}

	public int CurPlasma
	{
		get {
			return curPlasma;
		}
		set {
			curPlasma = value;
		}
	}
}
