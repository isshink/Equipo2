using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour{

    public float delay = 1.0f;

    public void Play(){
        Invoke("EjecutarPlay", delay);
    }
    public void Options(){
        Invoke("EjecutarOptions", delay);
    }
    public void Credits(){
        Invoke("EjecutarCredits", delay);
        
    }
    public void Exit(){
        Application.Quit();
    }

    void EjecutarPlay() {
        SceneManager.LoadScene("LevelSelect", LoadSceneMode.Single);
    }
    void EjecutarOptions() {
        //SceneManager.LoadScene(""); //optionsMenu o animacion
    }
    void EjecutarCredits() {
        //SceneManager.LoadScene(""); //credits o animacion
    }
}