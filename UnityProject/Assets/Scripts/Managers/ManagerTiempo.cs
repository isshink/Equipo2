using UnityEngine;
using UnityEngine.UI;

public class ManagerTiempo : MonoBehaviour {
	// Declaracion de variables
	private Slider sliderTiempo;
	private float timer = 0;
	public float tpoSesion = 60; // Segundos
	public float tpoActualizacion = 1; // Cuantos segundos se descuentan por vez
	private VerificarLogros verificaLogros;

	// Use this for initialization
	void Awake () {
		sliderTiempo = GameObject.Find("SliderTiempo").GetComponent<Slider>();
		sliderTiempo.maxValue = tpoSesion;
		verificaLogros = GameObject.FindObjectOfType<VerificarLogros>();
	}
	
	// Update is called once per frame
	void Update () {
		ActualizaTiempoSesion();

		if(tpoSesion <= 0){
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
		verificaLogros.VerificaLogros();
		Application.LoadLevel("Logros");
	}
}
