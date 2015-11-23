using UnityEngine;
using System.Collections;

public class KillOnContact : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		Destroy(other.gameObject);
	}
}
