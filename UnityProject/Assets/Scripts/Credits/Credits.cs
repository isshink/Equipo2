using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
	private GameObject studentsCreditsGameObject;

	public GameObject creditPrefab;
	public GameObject rolePrefab;
	public GameObject namePrefab;

	private VerticalLayoutGroup vlayout;

	void Awake ()
	{
		studentsCreditsGameObject = GameObject.Find("Students Credits");

		vlayout = GetComponent<VerticalLayoutGroup>();
		vlayout.padding.top = Screen.height;
		vlayout.padding.bottom = Screen.height;
	}

	void Start ()
	{
		Transform creditTransform = studentsCreditsGameObject.transform;

		TextAsset creditsTextAsset = Resources.Load("Credits") as TextAsset;
		string creditsText = creditsTextAsset.text;
		string[] creditTextLines = creditsText.Split('\n');

		bool createRole = true;
		foreach (string line in creditTextLines)
		{
			string trimmedLine = line.Trim(); // remove whitespaces before and after line
			if (trimmedLine != string.Empty) // if line has contents
			{
				if (createRole)
				{
					GameObject creditObject = (GameObject)Instantiate(creditPrefab);
					creditObject.transform.SetParent(studentsCreditsGameObject.transform);
					creditTransform = creditObject.transform;

					GameObject roleObject = (GameObject)Instantiate(rolePrefab);
					roleObject.transform.SetParent(creditTransform);
					
					Text roleText = roleObject.GetComponent<Text>();
					roleText.text = trimmedLine;

					createRole = false;
				}
				else
				{
					GameObject nameObject = (GameObject)Instantiate(namePrefab);
					nameObject.transform.SetParent(creditTransform);
					
					Text nameText = nameObject.GetComponent<Text>();
					nameText.text = trimmedLine;
				}
			}
			else // empty line => restart with next role 
			{
				createRole = true;
			}
		}
	}
}
