using UnityEngine;
using System.Collections;

public class Possessible : MonoBehaviour {

	private GhostModel player;
	private bool possessed;

	public void getPossessed()
	{

	}

	public GhostModel Player
	{
		get {
			return player;
		}
		set {
			player = value;
		}
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
