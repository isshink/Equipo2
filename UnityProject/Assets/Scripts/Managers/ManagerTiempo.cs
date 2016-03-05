using UnityEngine;
using UnityEngine.UI;

public class ManagerTiempo : MonoBehaviour {
	// Declaracion de variables
	private Slider sliderTiempo;
	private float timer = 0;
	public float tpoSesion = 60; // Segundos
	public float tpoActualizacion = 1; // Cuantos segundos se descuentan por vez
    private GameObject managerLogros;

	// Use this for initialization
	void Awake () {
		sliderTiempo = GameObject.Find("SliderTiempo").GetComponent<Slider>();
		sliderTiempo.maxValue = tpoSesion;
        managerLogros = GameObject.Find("ManagerLogros");
	}
	
	// Update is called once per frame
	void Update () {
		ActualizaTiempoSesion();

        if (tpoSesion <= 0 || Input.GetKeyDown(KeyCode.G))
        {
			FinalizarSesion();
		}
	}

	void ActualizaTiempoSesion(){
		timer += Time.deltaTime;
		if(timer >= tpoActualizacion && tpoSesion >= sliderTiempo.minValue){
			tpoSesion -= tpoActualizacion;
			sliderTiempo.value -= tpoActualizacion;
			timer = 0;
		}
	}

	void FinalizarSesion(){
        managerLogros.GetComponent<VerificarLogros>().VerificaLogros();
        managerLogros.GetComponent<MostrarLogros>().ActivarPanelLogros();
        managerLogros.GetComponent<MostrarLogros>().MarcarEstrellas();
	}
}
