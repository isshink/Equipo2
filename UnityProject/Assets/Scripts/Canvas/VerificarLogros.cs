using UnityEngine;
using UnityEngine.UI;

public class VerificarLogros : MonoBehaviour {
	private ManagerTiempo tiempoNivel;
	private ManagerArtefactos consumoNivel;
	private Mision[] misionesNivel;
    private ManagerMisiones managerMisiones;
	public bool logroMisiones = false;
	public bool logroConsumo = false;
	public bool logroJugarNivel = false;
	private int totalMisionesLogradas = 0;

	void Awake(){
		tiempoNivel = GameObject.FindObjectOfType<ManagerTiempo>();
		consumoNivel = GameObject.FindObjectOfType<ManagerArtefactos>();
		misionesNivel = GameObject.FindObjectOfType<ManagerMisiones>().GetComponentsInChildren<Mision>();
        managerMisiones = GameObject.FindObjectOfType<ManagerMisiones>();
	}

	public void VerificaLogros(){
		VerificaLogroNivel();
		VerificaLogroConsumo();
		VerificarLogroMisiones();
	}
	
	void VerificaLogroNivel(){
		if(tiempoNivel.tpoSesion <= 1){
			logroJugarNivel = true;
		}else{
			logroJugarNivel = false;
		}
	}

	void VerificaLogroConsumo(){
		if(consumoNivel.consumoTotal <= consumoNivel.promConsumoNivel){
			logroConsumo = true;
		}else{
			logroConsumo = false;
		}
	}
	
	void VerificarLogroMisiones(){
		foreach (Mision item in misionesNivel) {
			if(item.misionActiva){
				if(item.misionCumplida){
					totalMisionesLogradas++;
				}
			}
		}
		
		if(totalMisionesLogradas == managerMisiones.totalMisionesActivas){
			logroMisiones = true;
		}else{
			logroMisiones = false;
		}
	}
}
