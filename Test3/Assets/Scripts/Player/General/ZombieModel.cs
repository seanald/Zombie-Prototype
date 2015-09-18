using UnityEngine;
using System.Collections;

// Script for holding the general zombie information
public class ZombieModel : MonoBehaviour 
{
	public int health;

	public int Health
	{
		get {
			return health;
		}
		set {
			health = value;
		}
	}
}
