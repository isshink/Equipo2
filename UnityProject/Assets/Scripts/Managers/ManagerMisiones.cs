using UnityEngine;

public class ManagerMisiones : MonoBehaviour {
	// Declaracion de varialbes
	public Mision[] misiones;
	public int totalMisionesActivas = 1;
	private int indiceMisionActiva = 0;

	// Use this for initialization
	void Awake () {
		misiones = GameObject.FindObjectsOfType<Mision>();
	}

	void Start(){
		// Desactivo todas las misiones disponibles
		foreach (Mision item in misiones) {
			item.gameObject.SetActive(false);
		}

		// En funcion a la cantidad de misiones activas, 
		// selecciona dicho numero y las habilita
		if(totalMisionesActivas > 0){
			for (int i = 0; i < totalMisionesActivas; i++) {
				indiceMisionActiva = Random.Range(0, misiones.Length - 1);
				misiones[indiceMisionActiva].gameObject.SetActive(true);
				misiones[indiceMisionActiva].misionActiva = true;
				misiones[indiceMisionActiva].ActivarArtefactosMision();
			}
		}
	}
}
