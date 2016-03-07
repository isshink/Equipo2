using UnityEngine;
using System.Collections;

[RequireComponent (typeof(BoxCollider))]

public class EfectoEncendido : MonoBehaviour {

    //funcionalidad del script: Animacion de artefacto funcionando y cuando se apaga
    //modo de uso se coloca en el artefacto que se vaya a prender
    //tiene un unico booleano publico el cual indica si esta prendido u apagado
    //al clickear sobre el objeto este se apaga
    //no hace falta agregarle boxcollider lo hace solo

    // te paso los 2 shaders (uno el vertex color y el otro el vertex color con Outlines) y 2 materiales los cuales serian de 
    //ejemplo en el primer nivel.-
    // el segundo material que estaria con putlines iria en el public Material materialEncendido; o en 
    //donde vos mandabas tus materiales para intercabiar.-
    // si lo vas a mandar en donde vos lo ponias acordate de sacarlo de aca
    // si no funcionan los shaders o algo avisame aca me funcionan pero la version de unity que uso es la 5.3.2f1

    private const float minValor = 1.02f;
    private const float maxValor = 1.06f;
    private const float maxValorApagar = 1.1f;
    private const float maxRot = 8f;
    private const float normalRot = 0f;

    public bool encendido = false;
    public Material materialEncendido;
    Material materialApagado;
    Renderer rend;

    bool apagar = false;
    bool tambaleo = false;
    float incremento = 0.02f;
    float incrementoRotacion = 1f;
    float velocidadDeEscalado = 4;
    float velocidadDeSacudida = 35f;
    int direccion = 1;
    int contador = 0;
    Vector3 rotacion;
    Vector3 rotacionNormalizada;
    Vector3 escala;
    Vector3 escalaApagar;
    Vector3 escalaNormalizada = new Vector3(1.0f, 1.0f, 1.0f);

    // Germán
    private Artefacto artefacto;

    void Awake()
    {
        rend = GetComponent<Renderer>();
        materialApagado = GetComponent<Renderer>().material;
        artefacto = GetComponent<Artefacto>();
    }
	void Start () {
       rotacionNormalizada = transform.localEulerAngles;
       escala = new Vector3(minValor, minValor, minValor);
       escalaApagar = new Vector3(maxValor, maxValor, maxValor);
       rotacion = rotacionNormalizada;
	}
	void Update () {

        // Germán
        if (artefacto.encendido)
            encendido = true;
        else
            encendido = false;

        if (encendido && gameObject.name != "Art.Interruptor")
        {
            if (materialEncendido!=null)
                rend.material = materialEncendido;
            if (direccion > 0)
            {
                escala += new Vector3(incremento, incremento, incremento) * Time.deltaTime * velocidadDeEscalado;
                if (transform.localScale.x >= maxValor)
                {
                    direccion *= -1;
                }
            }
            else
            {
                escala -= new Vector3(incremento, incremento, incremento) * Time.deltaTime * velocidadDeEscalado;
                if (transform.localScale.x <= minValor)
                {
                    direccion *= -1;
                }
            }
            transform.localScale = escala;
        }
        else if (apagar && gameObject.name != "Art.Interruptor")
        {
            escalaApagar += new Vector3(incremento, incremento, incremento) * Time.deltaTime * (velocidadDeEscalado * 6);
            if (transform.localScale.x >= maxValorApagar)
            {
                apagar = false;
                escalaApagar = new Vector3(maxValor, maxValor, maxValor);
                transform.localScale = escalaNormalizada;
                tambaleo = true;
                rend.material = materialApagado;
                return;
            }
            transform.localScale = escalaApagar;
        }
        else if (tambaleo && gameObject.name != "Art.Interruptor")
        {
            if (direccion > 0 && contador==0)
            {
                rotacion.y += incrementoRotacion * 2 * Time.deltaTime * velocidadDeEscalado * velocidadDeSacudida;
                if (transform.localEulerAngles.y >= maxRot)
                {
                    direccion *= -1;
                }
            }
            else if (direccion<0)
            {
                rotacion.y -= incrementoRotacion * 2 * Time.deltaTime * velocidadDeEscalado * velocidadDeSacudida;
                if (transform.localEulerAngles.y <= 352  && transform.localEulerAngles.y > 340)
                {
                    contador++;
                    direccion *= -1;
                }
            }
            else if (direccion>0&&contador>0)
            {
                rotacion.y += incrementoRotacion * 2 * Time.deltaTime * velocidadDeEscalado * velocidadDeSacudida;
                if (transform.localEulerAngles.y >= normalRot)
                {
                    direccion = 1;
                    contador = 0;
                    tambaleo = false;
                    rotacion = rotacionNormalizada;
                }
            }
            transform.localEulerAngles = rotacion;
        }

	}

    // Pase lo que hace con el mouseDown a una función para llamarla desde el script 'Artefacto'
    public void Reset() {
        encendido = false;
        escala = new Vector3(minValor, minValor, minValor);
        direccion = 1;
        apagar = true;
    }
}
