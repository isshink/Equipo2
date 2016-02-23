using UnityEngine;

public class VerificarLogros : MonoBehaviour {
	private ManagerTiempo tiempoNivel;
	private ManagerArtefactos consumoNivel;
	private Mision[] misionesNivel;
	private Nivel nivelJugado;
	public static bool logroMisiones = false;
	public static bool logroConsumo = false;
	public static bool logroJugarNivel = false;
	private int totalMisionesLogradas = 0;

	void Awake(){
		tiempoNivel = GameObject.FindObjectOfType<ManagerTiempo>();
		consumoNivel = GameObject.FindObjectOfType<ManagerArtefactos>();
		misionesNivel = GameObject.FindObjectOfType<ManagerMisiones>().GetComponentsInChildren<Mision>();
		nivelJugado = GameObject.FindObjectOfType<Nivel>();
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
		if(consumoNivel.consumoTotal <= nivelJugado.consumoPromNivel){
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
		
		if(totalMisionesLogradas == nivelJugado.totalMisionesNivel){
			logroMisiones = true;
		}else{
			logroMisiones = false;
		}
	}
}
