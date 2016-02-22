using UnityEngine;
using UnityEngine.UI;

public class ManagerTiempo : MonoBehaviour {
	// Declaracion de variables
	private Slider sliderTiempo;
	private float timer = 0;
	public float tpoSesion = 60; // Segundos
	public float tpoActualizacion = 1; // Cuantos segundos se descuentan por vez

	// Use this for initialization
	void Awake () {
		sliderTiempo = GameObject.Find("SliderTiempo").GetComponent<Slider>();
		sliderTiempo.maxValue = tpoSesion;
	}
	
	// Update is called once per frame
	void Update () {
		ActualizaTiempoSesion();
	}

	void ActualizaTiempoSesion(){
		timer += Time.deltaTime;
		if(timer >= tpoActualizacion && tpoSesion >= sliderTiempo.minValue){
			tpoSesion -= tpoActualizacion;
			sliderTiempo.value -= tpoActualizacion;
			Debug.Log(tpoSesion);
			timer = 0;
		} else if(tpoSesion <= sliderTiempo.minValue){
			FinalSesion();
		}
	}

	void FinalSesion(){
		Debug.Log ("Final de la sesion");
	}
}
