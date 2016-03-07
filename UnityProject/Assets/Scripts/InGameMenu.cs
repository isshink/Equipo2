using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
	public string sceneToGoBackTo;

	public GameObject pauseButton;
	public GameObject pauseMenu;

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			pauseButton.SetActive(!pauseButton.activeSelf);
			pauseMenu.SetActive(!pauseMenu.activeSelf);
		}
	}

	void OnApplicationPause(bool pause)
	{
		if (pause)
		{
			Pause();
		}
	}
	
	public void Pause ()
	{
		pauseButton.SetActive(false);
		pauseMenu.SetActive(true);

        Time.timeScale = 0;
        AudioListener.pause = true;
	}

	public void Unpause ()
	{
		pauseButton.SetActive(true);
		pauseMenu.SetActive(false);

        Time.timeScale = 1;
        AudioListener.pause = false;
	}
	
	public void ExitToMenu ()
	{
        Unpause();
        SceneManager.LoadScene(sceneToGoBackTo);
	}

    public void Restart() {
        Unpause();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
