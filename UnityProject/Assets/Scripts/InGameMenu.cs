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
	}

	public void Unpause ()
	{
		pauseButton.SetActive(true);
		pauseMenu.SetActive(false);
	}
	
	public void ExitToMenu ()
	{
		SceneManager.LoadScene(sceneToGoBackTo);
	}
}
