using UnityEngine;
using System.Collections.Generic;

public class Mision : MonoBehaviour {
	// Declaracion de variables
	public string nombreMision;
	private string descMision;
	//public int cantArtefactosMision = 3;
	public bool misionActiva = false;
	public bool misionCumplida = false;
	public List<Artefacto> artefactosMision;

	void Update(){
		VerificaLogroMision();
	}

	public void ActivarArtefactosMision(){
		if(artefactosMision != null){
			foreach (Artefacto item in artefactosMision) {
				item.activoMision = true;
			}
		}
	}
	
	public void VerificaLogroMision(){
		// Si alguno de los artefactos fue desconectado la mision no se cumple
		foreach (Artefacto item in artefactosMision) {
			if(!item.encendido){
				misionCumplida = false;
				return;
			}
		}
		// Si despues de recorrer todos los artefactos de la mision, ninguno fue desconectado
		// entonces la mision se cumple
		misionCumplida = true;
	}
}
