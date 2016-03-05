using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SonidoBoton : MonoBehaviour {

    public AudioClip sonido;
    private Button boton { get { return GetComponent<Button>(); } }
    private AudioSource audioSource { get { return GetComponent<AudioSource>(); } }

	// Use this for initialization
	void Start () {
        gameObject.AddComponent<AudioSource>();
        audioSource.clip = sonido;
        audioSource.playOnAwake = false;
	}
	
	public void EjecutarSonido() {
        audioSource.PlayOneShot(sonido);
	}
}
