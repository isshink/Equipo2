using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;
			#elif UNITY_WEBPLAYER || UNITY_WEBGL
				OpenWebURL();
			#else
				Application.Quit();
			#endif
		}
	}

	public void LoadMoreGames ()
	{
		#if UNITY_ANDROID
			Application.OpenURL("market://search?q=pub:Image%20Campus");
		#elif UNITY_IOS
			Application.OpenURL("https://itunes.apple.com/developer/image-campus/id939914919");
		#elif UNITY_WINRT || UNITY_WINRT_8_0 || UNITY_WINRT_8_1
			Application.OpenURL("zune:search?publisher=Image%20Campus");
		#elif UNITY_WEBPLAYER || UNITY_WEBGL
			OpenWebURL();
		#else
			Application.OpenURL("http://www.imagecampus.com/game-labs");
		#endif
	}
	
	#if UNITY_WEBPLAYER || UNITY_WEBGL
	private void OpenWebURL ()
	{
		Application.OpenURL("http://www.imagecampus.com/game-labs");
	}
	#endif

	public void LoadCredits ()
	{
		SceneManager.LoadScene("Credits");
	}
}
