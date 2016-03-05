using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
	public string levelToLoad;

	private GameObject loading;
	private Animator animator;

	void Start ()
	{
		loading = GameObject.Find("Loading");
		loading.SetActive(false);

		animator = GetComponent<Animator>();
	}

	void Update ()
	{
		if (Input.anyKeyDown)
		{
			BypassSplash();
		}
	}

	public void BypassSplash ()
	{
		animator.StartPlayback();
		animator.Play("SplashAnimation", -1, animator.playbackTime);

		loading.SetActive(true);
		
		SceneManager.LoadScene(levelToLoad);
	}
}
