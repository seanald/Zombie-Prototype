using UnityEngine;
using System.Collections;

public class DestroyerScript : MonoBehaviour {


	void OnTriggerEnter(Collider collision){
			Destroy(collision.gameObject);		
		}
}
