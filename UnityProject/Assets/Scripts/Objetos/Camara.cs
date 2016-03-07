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

    void Update(){
        // Inputs para Desktop y Web
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)){
            MoverDerecha();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)){
            MoverIzquierda();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)){
            MoverAbajo();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)){
            MoverArriba();
        }

        // Inputs para mobile
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
                HorizontalSlide(angleDegrees);
            }
            
            if (cantHabVertical > 0){
                VerticalSlide(angleDegrees);
            }
        }
        // Traslación de la cámara
        Traslacion();
    }

    void HorizontalSlide(float angleDegrees)
    {
        if (angleDegrees > -45 && angleDegrees < 45)
        {
            // izquierda
            MoverIzquierda();
        }
        else if ((angleDegrees > 135 && angleDegrees < 180) || (angleDegrees < -135 && angleDegrees > -180))
        {
            // derecha
            MoverDerecha();
        }
    }
    void VerticalSlide(float angleDegrees)
    {
        if (angleDegrees > 45 && angleDegrees < 135)
        {
            // abajo
            MoverAbajo();
        }
        else if (angleDegrees < -45 && angleDegrees > -135)
        {
            // arriba
            MoverArriba();
        }
    }
    void MoverDerecha()
    {
        if (contPosX < cantHabHorizontal - 1)
        {
            contPosX++;
            traslacionHorizontal = true;
        }
    }
    void MoverIzquierda()
    {
        if (contPosX > 0)
        {
            contPosX--;
            traslacionHorizontal = true;
        }
    }
    void MoverArriba()
    {
        if (contPosY < cantHabVertical - 1)
        {
            contPosY++;
            traslacionVertical = true;
        }
    }
    void MoverAbajo()
    {
        if (contPosY > 0)
        {
            contPosY--;
            traslacionVertical = true;
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
