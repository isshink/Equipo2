using UnityEngine;

public class Nivel : MonoBehaviour {
	// Declaracion de varialbes
	public string nombreNivel;
	public int consumoMaxNivel = 1500;
	public int consumoPromNivel = 750;
	public int totalMisionesNivel = 3;
	private int totalMisionesLogradas = 0;
	public bool nivelActivo = false;
	public bool logroMisiones = false;
	public bool logroConsumo = false;
	public bool logroJugarNivel = false;
	private ManagerTiempo tiempoNivel;
	private ManagerArtefactos consumoNivel;
	private Mision[] misionesNivel;

	void Awake(){
		tiempoNivel = GameObject.FindObjectOfType<ManagerTiempo>();
		consumoNivel = GameObject.FindObjectOfType<ManagerArtefactos>();
		misionesNivel = GameObject.FindObjectOfType<ManagerMisiones>().GetComponentsInChildren<Mision>();
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape) || tiempoNivel.tpoSesion <= 0){
			Debug.Log("Termina la partida");
		}
	}

	void VerificaLogros(){
		VerificaLogroNivel();
		VerificaLogroConsumo();
		VerificarLogroMisiones();
	}

	void VerificaLogroNivel(){
		if(tiempoNivel.tpoSesion <= 0){
			logroJugarNivel = true;
			Debug.Log("Logro Nivel Alcanzado");
		}else{
			logroJugarNivel = false;
		}
	}

	void VerificaLogroConsumo(){
		if(consumoNivel.consumoTotal <= consumoPromNivel){
			logroConsumo = true;
			Debug.Log("Logro Consumo Alcanzado");
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

		if(totalMisionesLogradas == totalMisionesNivel){
			logroMisiones = true;
			Debug.Log("Logro Misiones Alcanzado");
		}else{
			logroMisiones = false;
		}
	}
}
