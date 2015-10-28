using UnityEngine;
using System.Collections;

public class Possessable : MonoBehaviour
{
	private bool possessed;

	void Start()
	{
	
	}

	void Update()
	{
	
	}

	public bool Possessed
	{
		get {
			return possessed;
		}
		set {
			possessed = value;
		}
	}
}
