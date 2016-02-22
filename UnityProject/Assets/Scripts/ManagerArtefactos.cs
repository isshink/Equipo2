using UnityEngine;
using UnityEngine.UI;

public class ManagerArtefactos : MonoBehaviour {
	// Declaracion de varialbes
	public Artefacto[] listaArtefactos; // Listado con todos los artefactos de la escena
	private Slider sliderConsumo;
	public int consumoTotal = 0;
	private float timer = 0;
	public float tpoActualizacion = 0.5f; // Cada cuanto tiempo actualiza barra consumo
	private float timerEncRnd = 0;
	public float tpoEncRndMin = 5; // Cada cuanto tiempo enciende un artefacto (limite min del rango)
	public float tpoEncRndMax = 15; // Cada cuanto tiempo enciende un artefacto (limite max del rango)
	private float tpoLimiteParaRnd = 10;
	private ManagerTiempo managerTiempo;
	private Image imageCanvas; // Referencia al objeto Image del Canvas (para mostrar las tarjetas
	public float tpoMuestraSprite = 3f; // Segundos que se muestran los avisos de encendidos random
	private float timerSprite = 0;
	private bool muestraSprite = false;

	// Use this for initialization
	void Awake () {
		listaArtefactos = GameObject.FindObjectsOfType<Artefacto>();
		sliderConsumo = GameObject.Find("SliderConsumo").GetComponent<Slider>();
		managerTiempo = GameObject.Find("ManagerTiempo").GetComponent<ManagerTiempo>();
		imageCanvas = GameObject.Find("ImageFamiliar").GetComponent<Image>();
	}

	void Start(){
		imageCanvas.gameObject.SetActive(false);
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

		// Si un artefacto tiene asociado un sprite y se enciende random, se activa
		if(muestraSprite){
			timerSprite += Time.deltaTime;
			imageCanvas.gameObject.SetActive(true);
			if(timerSprite >= tpoMuestraSprite){
				imageCanvas.gameObject.SetActive(false);
				muestraSprite = false;
				timerSprite = 0;
			}
		}
	}

	// Verifica el consumo de cada artefacto y lo totaliza.
	// Muestra el consumo total en el sliderConsumo
	void ConsumoTotalArtefactos(){
		foreach (Artefacto item in listaArtefactos) {
			if(item != null){
				if(item.encendido && !item.consumoFacturado){
					consumoTotal += item.consumoArtefacto;
					sliderConsumo.value += item.consumoArtefacto;
					item.consumoFacturado = true;
					Debug.Log(sliderConsumo.value);
				}else if(!item.encendido && item.consumoFacturado){
					consumoTotal -= item.consumoArtefacto;
					sliderConsumo.value -= item.consumoArtefacto;
					item.consumoFacturado = false;
					Debug.Log("Descuento consumo, ahora es: " + consumoTotal);
				}
			}
		}
	}

	// Enciende de forma aleatoria los artefactos que estan apagados
	void EncendidoRandomArtefactos(){
		foreach (Artefacto item in listaArtefactos) {
			if(item != null){
				if(!item.encendido){
					MostrarSpriteArtefacto(item);
					item.EncenderArtefacto();
					break;
				}
			}
		}
	}

	// Si el artefacto tiene asociado un sprite, al encenderse se activa
	void MostrarSpriteArtefacto(Artefacto item){
		if(item.spriteArtefacto != null){
			muestraSprite = true;
			imageCanvas.sprite = item.spriteArtefacto;
		}
	}
}
