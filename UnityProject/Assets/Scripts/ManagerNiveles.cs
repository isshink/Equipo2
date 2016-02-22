using UnityEngine;

public class ManagerNiveles : MonoBehaviour {
	// Declaracion de variables
	public Nivel[] niveles; 
	public int nivelSeleccionado = 1;

	void Awake(){
		niveles = GameObject.FindObjectsOfType<Nivel>();
	}
	
	// En funcion al nivel seleccionado en el mapa, debera activar el nivel
	// Por ahora utilizo el numero 1
	void Start(){
		for (int i = 1; i < niveles.Length; i++) {
			if(i == nivelSeleccionado){
				niveles[i].nivelActivo = true;
			}
		}
	}
}
