using UnityEngine;

public class ManagerInputs : MonoBehaviour {
	private VerificarLogros verificaLogros;

	void Awake(){
		verificaLogros = GameObject.FindObjectOfType<VerificarLogros>();
	}

	// Update is called once per frame
	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.LoadLevel("MapaNiveles");
		}
		
		if(Input.GetMouseButtonDown(2)){
			verificaLogros.VerificaLogros();
			Application.LoadLevel("Logros");
		}
	}
}
