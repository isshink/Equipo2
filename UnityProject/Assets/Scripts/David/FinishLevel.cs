using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour {

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
    public void LevelSelectMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("LevelSelect", LoadSceneMode.Single);
    }
    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
