using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour {
    public Button botonLvl2;
    public Button botonLvl3;
    public Button botonLvl4;
    public Image[] estrellasLvl1;
    public Image[] estrellasLvl2;
    public Image[] estrellasLvl3;
    public Image[] estrellasLvl4;

    void Awake () {
        if (PlayerPrefs.GetInt("starslvl01") >= 2)
            botonLvl2.interactable = true;
        if (PlayerPrefs.GetInt("starslvl02") >= 2)
            botonLvl3.interactable = true;
        if (PlayerPrefs.GetInt("starslvl03") >= 2)
            botonLvl4.interactable = true;
    }
    void Start()
    {
        for (int i=0;i<PlayerPrefs.GetInt("starslvl01");i++)
        {
            estrellasLvl1[i].color = Color.yellow;
        }
        for (int i = 0; i < PlayerPrefs.GetInt("starslvl02"); i++)
        {
            estrellasLvl2[i].color = Color.yellow;
        }
        for (int i = 0; i < PlayerPrefs.GetInt("starslvl03"); i++)
        {
            estrellasLvl3[i].color = Color.yellow;
        }
        for (int i = 0; i < PlayerPrefs.GetInt("starslvl04"); i++)
        {
            estrellasLvl4[i].color = Color.yellow;
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
    public void CuartaCasa()
    {
        SceneManager.LoadScene("lvl04", LoadSceneMode.Single);
    }

}
