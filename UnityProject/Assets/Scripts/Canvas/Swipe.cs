using UnityEngine;

public class Swipe : MonoBehaviour
{
	Vector3 startPos = Vector3.zero;
	Vector3 endPos = Vector3.zero;

	void Start () {
	
	}

	void Update () {

		if (Input.GetMouseButtonDown(0))
		{
			startPos = Input.mousePosition;
		}

		if (Input.GetMouseButtonUp(0))
		{
			endPos = Input.mousePosition;

			Vector3 moveVector = endPos - startPos;

			float angle = Mathf.Atan2(moveVector.y, moveVector.x);
			float angleDegrees = Mathf.Rad2Deg * angle;

			if (angleDegrees > -45 && angleDegrees < 45)
			{
				// derecha
			}
			else if (angleDegrees > 45 && angleDegrees < 135)
			{
				// arriba
			}
			else if ( (angleDegrees > 135 && angleDegrees < 180) || (angleDegrees < -135 && angleDegrees > -180) )
			{
				// izquierda
			}
			else if ( angleDegrees < -45 && angleDegrees > -135)
			{
				// abajo
			}
			else
			{
				// en diagonales
			}
		}

	}
}
