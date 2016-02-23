using UnityEngine;


public class ManagerNiveles : MonoBehaviour {
	// Declaracion de variables
	// Singleton
	public static ManagerNiveles instance = null;
	public string nombreNivelActivo;

	public Nivel[] niveles; 
	
	void Awake(){
		if(instance == null){
			instance = this;
		}else{
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
		niveles = GameObject.FindObjectsOfType<Nivel>();
	}

	void Start(){
		ActivarNivel();
	}

	void ActivarNivel(){
		nombreNivelActivo = Application.loadedLevelName;
		switch (nombreNivelActivo) {
		case "KameHouse":
			niveles[0].nivelActivo = true;
			break;
		default:
			break;
		}
	}
}
