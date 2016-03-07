using UnityEngine;
using UnityEngine.UI;

public class Artefacto : MonoBehaviour {
	// Declaracion de variables
	public string nombreArtefacto;
	public int consumoArtefacto;
	public int consumoActual;
	public int sinConsumo = 0;
	public string descripcionTip;
	public bool consumoFacturado = false;
	public bool tieneTip = false;
	public bool encendido = true;
	public bool interactivo = true;
	public bool activoMision = false;
	public bool activoNivel = true;
	public Material artefactoApagado;
	private Material artefactoEncendido;
	public Sprite spriteArtefacto; // Sprites (tarjetas) que refieren al artefacto
    private EfectoEncendido efectoEncendido;
    public AudioClip audioEncendido;
    public AudioClip audioApagado;
    private AudioSource audioSource;
    private Behaviour haloArtefacto;
	
	// Use this for initialization
	void Awake () {
		artefactoEncendido = GetComponent<Renderer>().material;
        AsignaImagenArtefacto();
        efectoEncendido = GetComponent<EfectoEncendido>();
        if (GetComponent<AudioSource>() != null)
            audioSource = GetComponent<AudioSource>();
        else {
            gameObject.AddComponent<AudioSource>();
            audioSource = GetComponent<AudioSource>();
        }
        if (transform.childCount > 0)
            haloArtefacto = transform.GetChild(0).GetComponentInChildren<Behaviour>();
	}

    void Start() {
        if (haloArtefacto != null)
            haloArtefacto.GetType().GetProperty("enabled").SetValue(haloArtefacto, true, null);
        audioSource.volume = 0.25f;
        EjecutarAudioEncendido();
    }

	// Update is called once per frame
	void Update () {
		ConsumirKW();
	}

	// Apaga o enciende el artefacto
	void OnMouseDown(){
		if(encendido)
			ApagarArtefacto();
		else
			EncenderArtefacto();
	}
     

	void ApagarArtefacto(){
		if(interactivo && encendido){
			encendido = false;
			gameObject.GetComponent<Renderer>().material = artefactoApagado;
            efectoEncendido.Reset();
            if (haloArtefacto != null)
                haloArtefacto.GetType().GetProperty("enabled").SetValue(haloArtefacto, false, null);
            EjecutarAudioApagado();
		}
	}

	public void EncenderArtefacto(){
		if(interactivo && !encendido){
			encendido = true;
			gameObject.GetComponent<Renderer>().material = artefactoEncendido;
            if (haloArtefacto != null)
                haloArtefacto.GetType().GetProperty("enabled").SetValue(haloArtefacto, true, null);
            EjecutarAudioEncendido();
		}
	}

	// Consumo de KW en funcion de si esta o no encendido
	public void ConsumirKW(){
		if(encendido){
			consumoActual = consumoArtefacto;
		}else{
			consumoActual = sinConsumo;
		}
	}

    void EjecutarAudioEncendido() {
        if (audioEncendido != null) {
            audioSource.clip = audioEncendido;
            audioSource.Play();
            audioSource.loop = false;
        }
    }

    void EjecutarAudioApagado() {
        if (audioApagado != null)
        {
            audioSource.clip = audioApagado;
            audioSource.loop = false;
            audioSource.Play();
        }
        else if(audioEncendido){
            audioSource.loop = false;
            audioSource.clip = null;
        }       
    }

    void AsignaImagenArtefacto() {
        string nombreImagen = "";
        if (gameObject.name == "Art.Interruptor" || gameObject.name == "Art.LamparaPie" || gameObject.name == "Art.Velador")
            nombreImagen = "PopUpLuz";
        else if (gameObject.name == "Art.Heladera" || gameObject.name == "Art.Horno" || gameObject.name == "Art.Microondas" || 
            gameObject.name == "Art.Tostadora" || gameObject.name == "Art.Batidora")
            nombreImagen = "PopUpComida";
        else if (gameObject.name == "Art.TV")
            nombreImagen = "PopUpTV";
        else if (gameObject.name == "Art.Parlantes")
            nombreImagen = "PopUpMusica2";
        else if (gameObject.name == "Art.Computadora")
            nombreImagen = "PopUpMouse";
        else if (gameObject.name == "Art.Telefono")
            nombreImagen = "PopUpTelefono";
        else
            nombreImagen = "Exclamacion";

        spriteArtefacto = Resources.Load<Sprite>("sprites/" + nombreImagen);
    }
}
