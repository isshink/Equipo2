using UnityEngine;

public class AudioManager : MonoBehaviour
{
	private static AudioManager instance;

	public static AudioManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new GameObject("Audio Manager").AddComponent<AudioManager>();
			}

			return instance;
		}
	}

	void Awake()
	{
		if (instance != null && instance != this)
		{
			Destroy(gameObject);
		}

		instance = this;

		DontDestroyOnLoad(gameObject);

		// en awake porque en start ya arrancaria oyendose
		AudioListener.volume = PlayerPrefs.GetFloat("audio", 1.0f);
	}

	public void ToggleAudio (bool enable)
	{
		float volume = enable ? 1.0f : 0.0f;

		AudioListener.volume = volume;

		PlayerPrefs.SetFloat("audio", volume);
		PlayerPrefs.Save();
	}

	public bool IsAudioOn ()
	{
		return AudioListener.volume > 0.9f ? true : false;
	}
}
