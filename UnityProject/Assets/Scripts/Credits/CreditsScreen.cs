using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScreen : MonoBehaviour
{
	public string sceneToGoBackTo;
	
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			ExitCredits();
		}
	}

	public void ExitCredits ()
	{
		SceneManager.LoadScene(sceneToGoBackTo);
	}

	public void OpenImageCampusWebsite()
	{
		Application.OpenURL("http://www.imagecampus.com/");
	}

	public void OpenImageCampusLabsWebsite()
	{
		Application.OpenURL("http://www.imagecampus.com/game-labs");
	}
}
