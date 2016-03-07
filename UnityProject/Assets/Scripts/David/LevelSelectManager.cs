using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour {
    public Button[] botones;
    public Image[] estrellasLvl1;
    public Image[] estrellasLvl2;
    public Image[] estrellasLvl3;
    private int minCantLogrosDesbloqueo = 2;
    public int cantNiveles = 3;

    void Awake () {
        string key = "";
        for (int i = 1; i < botones.Length -1; i++)
        {
            key = "starslvl0" + i.ToString();
            DesbloqueaNivel(key, botones[i]);
        }
    }
    void Start()
    {
        string key = "";
        for (int i = 1; i < cantNiveles; i++)
        {
            key = "starslvl0" + i.ToString();
            RellenaLogro(key, Color.yellow);
        }
    }
    void DesbloqueaNivel(string key, Button boton)
    {
        if (PlayerPrefs.GetInt(key) >= minCantLogrosDesbloqueo)
            boton.interactable = true;
        else
            boton.interactable = false;
    }
    void RellenaLogro(string key, Color color) {
        for (int i = 0; i < PlayerPrefs.GetInt(key); i++){
            estrellasLvl1[i].color = color;
        }
    }
	public void PrimeraCasa()
    {
        SceneManager.LoadScene("KameHouse",LoadSceneMode.Single);
    }
    public void SegundaCasa()
    {
        SceneManager.LoadScene("GriffinHouse", LoadSceneMode.Single);
    }
    public void TerceraCasa()
    {
        SceneManager.LoadScene("SimpsonHouse", LoadSceneMode.Single);
    }
    public void ResetearLogros() {
        string key = "";
        Color color = new Color(1f, 1f, 1f);
        for (int i = 1; i < cantNiveles; i++)
        {
            key = "starslvl0" + i.ToString();
            RellenaLogro(key, color);
        }

        PlayerPrefs.DeleteAll();

        key = "";
        for (int i = 1; i < botones.Length - 1; i++)
        {
            key = "starslvl0" + i.ToString();
            DesbloqueaNivel(key, botones[i]);
        }
    }
}
