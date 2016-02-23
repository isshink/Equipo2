using UnityEngine;

public class ManagerMisiones : MonoBehaviour {
	// Declaracion de varialbes
	public Nivel[] niveles;
	public Mision[] misiones;
	private int totalMsionesActivas;
	private int indiceMisionActiva = 0;

	// Use this for initialization
	void Awake () {
		misiones = GameObject.FindObjectsOfType<Mision>();
		niveles = GameObject.FindObjectsOfType<Nivel>();
	}

	void Start(){
		// Desactivo todas las misiones disponibles
		foreach (Mision item in misiones) {
			item.gameObject.SetActive(false);
		}

		foreach (Nivel item in niveles) {
			if(item.nivelActivo){
				totalMsionesActivas = item.totalMisionesNivel;
				break;
			}
		}
		// En funcion a la cantidad de misiones activas, 
		// selecciona dicho numero y las habilita
		if(totalMsionesActivas > 0){
			for (int i = 0; i < totalMsionesActivas; i++) {
				indiceMisionActiva = Random.Range(0, misiones.Length - 1);
				misiones[indiceMisionActiva].gameObject.SetActive(true);
				misiones[indiceMisionActiva].misionActiva = true;
				misiones[indiceMisionActiva].ActivarArtefactosMision();
			}
		}
	}
}
