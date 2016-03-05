using UnityEngine;
using UnityEngine.UI;

public class CreditsScroll : MonoBehaviour
{
	private ScrollRect scrollRect;

	private const float scrollSpeed = 250.0f;

	void Start ()
	{
		scrollRect = GetComponent<ScrollRect>();
	}

	void Update ()
	{
		scrollRect.velocity += Vector2.up * Time.deltaTime * scrollSpeed;

		if (scrollRect.normalizedPosition.y >= 1.0)
		{
			scrollRect.normalizedPosition = Vector2.one;
		}
		else if (scrollRect.normalizedPosition.y <= 0.0)
		{
			scrollRect.normalizedPosition = Vector2.one;
		}
	}
}
