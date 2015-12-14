using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Plasma : MonoBehaviour
{

	public float maxPlasma = 100f;
	private float curPlasma = 100f;

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

	void FixedUpdate()
	{
		if(this.curPlasma >= 1)
		{
			AddPlasma();
		}
		else
		{
			StartCoroutine(WaitForPlasma());
		}
	}


	public void AddPlasma()
	{
		curPlasma += .05f;
		if (curPlasma > maxPlasma)
		{
			curPlasma = maxPlasma;
		}
	}

	public float CurPlasma
	{
		get {
			return curPlasma;
		}
		set {
			curPlasma = value;
		}
	}

	IEnumerator WaitForPlasma()
	{
		yield return new WaitForSeconds(5f);
		this.curPlasma = 1;
	}
}
