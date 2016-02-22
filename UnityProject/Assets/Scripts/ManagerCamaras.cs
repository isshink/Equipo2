using UnityEngine;

public class ManagerCamaras : MonoBehaviour {
	// Declaracion variables
	private Camera[] camaras;
	private int currentCamaraIndex;

	// Almaceno referencias
	void Awake(){
		camaras = GameObject.FindObjectsOfType<Camera>();
	}

	// Inicializo variables
	void Start () {
		currentCamaraIndex = 0;
		
		// Apago todas las camaras, excepto la primera
		if(camaras != null){
			for (int i = 1; i < camaras.Length; i++) {
				camaras[i].gameObject.SetActive(false);
			}
		}
	}

	// Actualizao cada frame
	void Update () {
		// Si presiona el boton pasa a la proxima camara
		// Desactivo la camara actual y activo la camara siguiente
		// Cuando llego al final del array, vuelvo al comienzo
		if(camaras.Length > 0){
			if (Input.GetMouseButtonDown(1)){
				currentCamaraIndex ++;
				if (currentCamaraIndex < camaras.Length){
					camaras[currentCamaraIndex - 1].gameObject.SetActive(false);
					camaras[currentCamaraIndex].gameObject.SetActive(true);
				}
				else{
					camaras[currentCamaraIndex-1].gameObject.SetActive(false);
					currentCamaraIndex = 0;
					camaras[currentCamaraIndex].gameObject.SetActive(true);
				}
			}
		}
	}
}
