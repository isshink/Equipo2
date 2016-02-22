using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ManagerArtefactos : MonoBehaviour {
	// Declaracion de varialbes
	public GameObject[] listaArtefactos; // Listado con todos los artefactos de la escena
	private Slider sliderConsumo;
	private int consumoTotal = 0;
	private float timer = 0;
	public float tpoActualizacion = 1; // Cada cuanto tiempo actualiza barra consumo
	private float timerEncRnd = 0;
	public float tpoEncRndMin = 5; // Cada cuanto tiempo enciende un artefacto (limite min del rango)
	public float tpoEncRndMax = 15; // Cada cuanto tiempo enciende un artefacto (limite max del rango)
	private float tpoLimiteParaRnd = 10;
	private ManagerTiempo managerTiempo;

	// Use this for initialization
	void Awake () {
		listaArtefactos = GameObject.FindGameObjectsWithTag("Artefacto");
		sliderConsumo = GameObject.Find("SliderConsumo").GetComponent<Slider>();
		managerTiempo = GameObject.Find("ManagerTiempo").GetComponent<ManagerTiempo>();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(timer >= tpoActualizacion){
			ConsumoTotalArtefactos();
			timer = 0;
		}

		timerEncRnd += Time.deltaTime;
		if(timerEncRnd >= Random.Range(tpoEncRndMin, tpoEncRndMax) &&
		   managerTiempo.tpoSesion >= tpoLimiteParaRnd){
			EncendidoRandomArtefactos();
			timerEncRnd = 0;
		}
	}

	// Verifica el consumo de cada artefacto y lo totaliza.
	// Muestra el consumo total en el sliderConsumo
	void ConsumoTotalArtefactos(){
		foreach (GameObject item in listaArtefactos) {
			Artefacto obj = item.GetComponent<Artefacto>();
			if(obj != null){
				if(obj.encendido && !obj.consumoFacturado){
					consumoTotal += obj.consumoArtefacto;
					sliderConsumo.value += obj.consumoArtefacto;
					obj.consumoFacturado = true;
					Debug.Log(consumoTotal);
				}else if(!obj.encendido && obj.consumoFacturado){
					consumoTotal -= obj.consumoArtefacto;
					sliderConsumo.value -= obj.consumoArtefacto;
					obj.consumoFacturado = false;
					Debug.Log("Descuento consumo, ahora es: " + consumoTotal);
				}
			}
		}
	}

	// Enciende de forma aleatoria los artefactos que estan apagados
	void EncendidoRandomArtefactos(){
		foreach (GameObject item in listaArtefactos) {
			Artefacto obj = item.GetComponent<Artefacto>();
			if(obj != null){
				if(!obj.encendido){
					obj.EncenderArtefacto();
					break;
				}
			}
		}
	}
}
