using UnityEngine;
using UnityEngine.UI;

public class CreditsElement : MonoBehaviour
{
	private LayoutElement layoutElement;

	void Awake ()
	{
		layoutElement = GetComponent<LayoutElement>();
		
		layoutElement.preferredHeight = Screen.height;
	}
}
