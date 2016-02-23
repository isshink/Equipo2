using UnityEngine;
using UnityEngine.UI;

public class Artefacto : MonoBehaviour {
	// Declaracion de variables
	public string nombreArtefacto;
	public int consumoArtefacto;
	public int consumoActual;
	public int sinConsumo = 0;
	public string descripcionTip;
	public bool consumoFacturado = false;
	public bool tieneTip = false;
	public bool encendido = true;
	public bool interactivo = true;
	public bool activoMision = false;
	public bool activoNivel = true;
	public Material artefactoApagado;
	private Material artefactoEncendido;
	public Sprite spriteArtefacto; // Sprites (tarjetas) que refieren al artefacto
	
	// Use this for initialization
	void Awake () {
		artefactoEncendido = GetComponent<Renderer>().material;
		spriteArtefacto = Resources.Load<Sprite>("sprites/" + gameObject.name);
	}
	
	// Update is called once per frame
	void Update () {
		ConsumirKW();
	}

	// Apaga o enciende el artefacto
	void OnMouseOver(){
		if(Input.GetMouseButtonDown(0) && encendido){
			ApagarArtefacto();
		}else if(Input.GetMouseButtonDown(0) && !encendido){
			EncenderArtefacto();
		}
	}

	void ApagarArtefacto(){
		if(interactivo && encendido){
			encendido = false;
			gameObject.GetComponent<Renderer>().material = artefactoApagado;
		}
	}

	public void EncenderArtefacto(){
		if(interactivo && !encendido){
			encendido = true;
			gameObject.GetComponent<Renderer>().material = artefactoEncendido;
		}
	}

	// Consumo de KW en funcion de si esta o no encendido
	public void ConsumirKW(){
		if(encendido){
			consumoActual = consumoArtefacto;
		}else{
			consumoActual = sinConsumo;
		}
	}
}
