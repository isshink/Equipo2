using UnityEngine;

public class Camara : MonoBehaviour {

    public int cantHabVertical;
    public int cantHabHorizontal;
    public Vector3[] coordenadasDeCamara;
    public Vector3 coordCamara;
    private bool traslacionVertical = false;
    private bool traslacionHorizontal = false;
    private float tiempo = 0;

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

            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {

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
        Traslacion();
    }

    void DesplazamientoHorizontal(float angleDegrees)
    {
        if (angleDegrees > -45 && angleDegrees < 45)
        {
            // izquierda
            if (contPosX > 0)
            {
                contPosX--;
                traslacionHorizontal = true;
            }
        }
        else if ((angleDegrees > 135 && angleDegrees < 180) || (angleDegrees < -135 && angleDegrees > -180))
        {
            // derecha
            if (contPosX < cantHabHorizontal - 1)
            {
                contPosX++;
                traslacionHorizontal = true;
            }
        }
    }
    void DesplazamientoVertical(float angleDegrees)
    {
        if (angleDegrees > 45 && angleDegrees < 135)
        {
            // abajo
            if (contPosY > 0)
            {
                contPosY--;
                traslacionVertical = true;
            }
        }
        else if (angleDegrees < -45 && angleDegrees > -135)
        {
            // arriba
            if (contPosY < cantHabVertical - 1)
            {
                contPosY++;
                traslacionVertical = true;
            }
        }
    }
    void Traslacion()
    {
        if (traslacionVertical)
        {
            tiempo += Time.deltaTime;
            coordCamara.Set(posX[contPosX], posY[contPosY], posZ);
            transform.position = Vector3.Lerp(transform.position, coordCamara, tiempo);
            if (transform.position == coordCamara)
            {
                tiempo = 0;
                traslacionVertical = false;
            }
        }
        else if (traslacionHorizontal)
        {
            tiempo += Time.deltaTime;
            coordCamara.Set(posX[contPosX], posY[contPosY], posZ);
            transform.position = Vector3.Lerp(transform.position, coordCamara, tiempo);
            if (transform.position == coordCamara)
            {
                tiempo = 0;
                traslacionHorizontal = false;
            }
        }
    }
}
