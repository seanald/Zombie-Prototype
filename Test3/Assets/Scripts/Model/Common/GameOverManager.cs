using UnityEngine;

public class GameOverManager : MonoBehaviour
{
	public Health playerHealth;
	public float restartDelay = 5f;

	Animator anim;
	float restartTimer;


	void Awake()
	{
		anim = GetComponent <Animator>();
	}


	void Update()
	{
		if (playerHealth.CurHealth <= 0)
		{
			anim.SetTrigger("GameOver");

			restartTimer += Time.deltaTime;

			if (restartTimer >= restartDelay)
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
}