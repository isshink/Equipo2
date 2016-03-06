using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerInputs : MonoBehaviour {
    public Scene sourceScene;
    public Scene destinationScene;

	// Update is called once per frame
	void Update(){
        
		if(Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene("In-Game", LoadSceneMode.Additive);
		}
	}
}
