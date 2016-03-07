using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MostrarLogros : MonoBehaviour 
{
    public int estrellas = 0;
    public string stringKey;
    public GameObject canvasEstrellas;
    public Image[] imagenesDeEstrellas;
    float timer = 0; //solo para estetica;
    int imagenEstrella = 0;
    bool seAcaboElTiempo = false;//solo para estetica;
    private VerificarLogros verificarLogros;

    void Awake() {
        verificarLogros = GetComponent<VerificarLogros>();
    }

    void Start() {
        canvasEstrellas.gameObject.SetActive(false);
        if (PlayerPrefs.GetInt(stringKey) > 0)
            estrellas = PlayerPrefs.GetInt(stringKey);
    }

    void Update() {
        if (seAcaboElTiempo) {
            timer += Time.deltaTime;
            if (timer > 0.5f){
                for (int i = imagenEstrella; i < estrellas; i++){
                    imagenesDeEstrellas[i].color = Color.yellow;
                    break;
                }
                imagenEstrella++;
                timer = 0;
            }
        }
    }

    public void ActivarPanelLogros() {
        canvasEstrellas.gameObject.SetActive(true);
    }

    public void MarcarEstrellas() { 
        if(estrellas == 0 && verificarLogros.logroJugarNivel)
            estrellas++;
        if(estrellas == 1 && verificarLogros.logroConsumo)
            estrellas++;
        if((estrellas == 1 || estrellas == 2) && verificarLogros.logroMisiones)
            estrellas++;

        if (estrellas > 3)
            estrellas = 3;

        if (estrellas > PlayerPrefs.GetInt(stringKey)){
            PlayerPrefs.SetInt(stringKey, estrellas);
        }
        seAcaboElTiempo = true;
    }
}