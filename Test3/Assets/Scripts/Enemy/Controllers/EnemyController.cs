using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
	public int health;
	public float walkSpeed;
	public Animator animator;

	public int Health
	{
		get {
			return health;
		}
		set {
			health = value;
		}
	}
	
	public Animator Animator
	{
		get {
			return animator;
		}
		set {
			animator = value;
		}
	}
	
	public float WalkSpeed
	{
		get {
			return walkSpeed;
		}
		set {
			walkSpeed = value;
		}
	}

}
