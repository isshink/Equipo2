using UnityEngine;
using UnityEngine.UI;

public class MostrarLogros : MonoBehaviour {
	public Text[] textosLogros;

	// Use this for initialization
	void Start () {
		VerificaLogroNivel();
		VerificaLogroConsumo();
		VerificarLogroMisiones();
	}
	
	void VerificaLogroNivel(){
		textosLogros[0].text = "LOGRO NIVEL: " + VerificarLogros.logroJugarNivel.ToString();
	}
	
	void VerificaLogroConsumo(){
		textosLogros[1].text = "LOGRO CONSUMO: " + VerificarLogros.logroConsumo.ToString();
	}
	
	void VerificarLogroMisiones(){
		textosLogros[2].text = "LOGRO MISIONES: " + VerificarLogros.logroMisiones.ToString();
	}
}
