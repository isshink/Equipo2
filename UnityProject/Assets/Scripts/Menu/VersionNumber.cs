using UnityEngine;
using UnityEngine.UI;

public class VersionNumber : MonoBehaviour
{
	private Text versionTextField;

	void Awake ()
	{
		versionTextField = GetComponent<Text>();
	}
	
	void Start ()
	{
		versionTextField.text = Application.version;
	}
}
