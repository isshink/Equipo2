using UnityEngine;
using UnityEngine.SceneManagement;

public class VolverMenu : MonoBehaviour
{

    public void RegresarMenu()
    {
        SceneManager.LoadScene("MapaNiveles");
    }
}