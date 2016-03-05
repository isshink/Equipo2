using UnityEngine;
using UnityEngine.UI;

public class AudioButton : MonoBehaviour
{
	private Toggle audioToggleButton;
	
	void Awake ()
	{
		audioToggleButton = GetComponent<Toggle>();
	}

	void Start ()
	{
		audioToggleButton.isOn = AudioListener.volume > 0.9f ? true : false;//AudioManager.Instance.IsAudioOn();
	}

	public void ToggleAudio (bool enable)
	{
		AudioManager.Instance.ToggleAudio(enable);
	}
}
