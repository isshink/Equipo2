using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SeleccionNivel : MonoBehaviour
{
	public Button[] botonesNiveles;
	private string nombreBotonSeleccionado;
	private string nombreNivelSeleccionado;
	
	void Awake () {
		botonesNiveles = GameObject.FindObjectsOfType<Button>();
	}

	public void SeleccionarNivel(){
		nombreBotonSeleccionado = EventSystem.current.currentSelectedGameObject.name;
		switch (nombreBotonSeleccionado) {
		case "ButtonNivel01":
			nombreNivelSeleccionado = "KameHouse";
			break;
		default:
			nombreNivelSeleccionado = "KameHouse";
			break;
		}
		SceneManager.LoadScene(nombreNivelSeleccionado);
	}
}
