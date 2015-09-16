using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlasmaController : MonoBehaviour {

	public Slider plasmaSlider;
	public GhostModel ghostModel;

	private int maxPlasma;
	private int curPlasma;

	void Start()
	{
		this.MaxPlasma = this.ghostModel.Plasma;

		this.plasmaSlider.maxValue = this.maxPlasma;
		this.CurPlasma = this.MaxPlasma;

		InvokeRepeating("restorePlasma", 0, 0.2f);
	}
	// Update is called once per frame
	void Update () 
	{
		this.plasmaSlider.value = this.curPlasma;
	}

	private void restorePlasma()
	{
		curPlasma++;
	}

	public void usePlasma(int plasma)
	{
		if (this.curPlasma > 0)
		{
			this.curPlasma -= plasma;
		}
	}

	public int MaxPlasma
	{
		get {
			return maxPlasma;
		}
		set {
			maxPlasma = value;
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
