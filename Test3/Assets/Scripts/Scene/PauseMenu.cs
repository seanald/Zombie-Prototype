using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    public string mainMenu;

    public bool isPaused;

    public GameObject pauseMenucanvas;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;

			if (isPaused)
			{
				pauseMenucanvas.SetActive(true);
				Time.timeScale = 0f;
			}
			else
			{
				pauseMenucanvas.SetActive(false);
				Time.timeScale = 1f;
			}
        }
    }

    public void Resume()
    {
        isPaused = false;
    }

    public void Quit()
    {
        Application.LoadLevel(mainMenu);
    }
}
