using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerInputs : MonoBehaviour {

	// Update is called once per frame
	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene("LevelSelect");
		}
	}
}
