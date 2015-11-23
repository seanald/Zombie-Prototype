using UnityEngine;
using System.Collections;

public class zKingDead : MonoBehaviour {
    public GameObject textBox;
    public bool once = false;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (this.GetComponent<Health>().CurHealth < 2)
        {
            if (once == false)
            {
                textBox.transform.localPosition = new Vector3(textBox.transform.localPosition.x - 12000.0f, textBox.transform.localPosition.y, textBox.transform.localPosition.z);
                once = true;
                dialogue_beforeZombieKing.counter = 10;
                Time.timeScale = 0f;
            }
        }
	}
}
