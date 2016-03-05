using UnityEngine;

public class Camara : MonoBehaviour {

    public int cantHabVertical;
    public int cantHabHorizontal;
    public Vector3[] coordenadasDeCamara;
    public Vector3 coordCamara;
    public Vector3[] coordenadasDeCamaraHorizontal;
    public Vector3[] coordenadasDeCamaraVertical;
    private bool translacionVertical = false;
    private bool translacionHorizontal = false;
    private float tiempo = 0;
    private int habitacionVertical = 0;
    private int habitacionHorizontal = 0;
    // Swipe
    private Vector3 startPos = Vector3.zero;
	private Vector3 endPos = Vector3.zero;

    public float[] posY;
    public float[] posX;
    public float posZ;
    private int contPosY = 0;
    private int contPosX = 0;

    void Update()
    {
        if (Application.isWebPlayer)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                habitacionVertical++;
                if (habitacionVertical > cantHabVertical - 1)
                    habitacionVertical = 0;
                translacionVertical = true;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                habitacionVertical--;
                if (habitacionVertical < 0)
                    habitacionVertical = cantHabVertical - 1;
                translacionVertical = true;
            }
            if (translacionVertical)
            {
                tiempo += Time.deltaTime;
                transform.position = Vector3.Lerp(transform.position, coordenadasDeCamara[habitacionVertical], tiempo);
                if (transform.position == coordenadasDeCamara[habitacionVertical])
                {
                    tiempo = 0;
                    translacionVertical = false;
                }
            }
        }

        // Script Sergio para swipe
        if (Input.GetMouseButtonDown(0)){
            startPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0)){
            endPos = Input.mousePosition;

            Vector3 moveVector = endPos - startPos;

            if (moveVector.magnitude < 50)
                return;

            float angle = Mathf.Atan2(moveVector.y, moveVector.x);
            float angleDegrees = Mathf.Rad2Deg * angle;

            if (cantHabHorizontal > 0){
                DesplazamientoHorizontal(angleDegrees);
            }
            
            if (cantHabVertical > 0){
                DesplazamientoVertical(angleDegrees);
            }
        }
        Translacion();
    }

    void DesplazamientoHorizontal(float angleDegrees)
    {
        if (angleDegrees > -45 && angleDegrees < 45)
        {
            // derecha
            if (habitacionHorizontal < cantHabHorizontal - 1)
            {
                //habitacionHorizontal++;
                contPosX++;
                translacionHorizontal = true;
            }
        }
        else if ((angleDegrees > 135 && angleDegrees < 180) || (angleDegrees < -135 && angleDegrees > -180))
        {
            // izquierda
            if (habitacionHorizontal >= cantHabHorizontal - 1)
            {
                //habitacionHorizontal--;
                contPosX--;
                translacionHorizontal = true;
            }
        }
    }
    void DesplazamientoVertical(float angleDegrees)
    {
        if (angleDegrees > 45 && angleDegrees < 135)
        {
            // arriba
            if (habitacionVertical < cantHabVertical - 1)
            {
                //habitacionVertical++;
                contPosY++;
                translacionVertical = true;
            }
        }
        else if (angleDegrees < -45 && angleDegrees > -135)
        {
            // abajo
            if (habitacionVertical >= cantHabVertical - 1)
            {
                //habitacionVertical--;
                contPosY--;
                translacionVertical = true;
            }
        }
    }
    void Translacion()
    {
        if (translacionVertical)
        {
            tiempo += Time.deltaTime;
            coordCamara.Set(posX[contPosX], posY[contPosY], posZ);
            transform.position = Vector3.Lerp(transform.position, coordCamara, tiempo);
            //transform.position = Vector3.Lerp(transform.position, coordenadasDeCamaraVertical[habitacionVertical], tiempo);
            /*
            if (transform.position == coordenadasDeCamaraVertical[habitacionVertical])
            {
                tiempo = 0;
                translacionVertical = false;
            }
            */
            if (transform.position == coordCamara)
            {
                tiempo = 0;
                translacionVertical = false;
            }
        }
        else if (translacionHorizontal)
        {
            tiempo += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, coordenadasDeCamaraHorizontal[habitacionHorizontal], tiempo);
            if (transform.position == coordenadasDeCamaraHorizontal[habitacionHorizontal])
            {
                tiempo = 0;
                translacionHorizontal = false;
            }
        }
    }
}
