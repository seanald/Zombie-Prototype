using UnityEngine;
using System.Collections;

public class LevelTransition : MonoBehaviour {
    private GameObject[] enemiesInScene;
    public string levelSelect;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        enemiesInScene = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Player" && enemiesInScene.Length == 0)
        {
            Application.LoadLevel(levelSelect);
        }
    }
}
