using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CameraLookDirection { FORWARD, RIGHT, LEFT, BACKWARD }

public class Camera : MonoBehaviour {


    public Transform ObjectToTrack;
    public Vector3 Delta;

    float cameraAngle = 0f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        cameraAngle += Input.GetAxis("Mouse X"); //zawiera info o przesunięciu myszy w osi X

        var quaternion = Quaternion.Euler(0, cameraAngle, 0);

         var position = ObjectToTrack.position +
            ObjectToTrack.rotation * quaternion * Delta ;

        transform.position = position;

        transform.LookAt(ObjectToTrack); //kamera zawsze zwrócona na obiekt śledzony

        transform.rotation *= Quaternion.Euler(-12f, 0, 0); //ustawiamy kamere ciut powyżej statku

	}

    public CameraLookDirection GetCameraLookDirection() // funkcja zwraca kierunek w którym zwrocona jest kamera
    {

        var angle = Mathf.DeltaAngle(0, cameraAngle);//funkcja oblicza różnicę między zadanymi kątami
            {
            if (-45 < angle && angle < 45)
                return CameraLookDirection.FORWARD;
            if (45 < angle && angle < 135)
                return CameraLookDirection.RIGHT;
            if (-135 < angle && angle < -45)
                return CameraLookDirection.LEFT;
                return CameraLookDirection.BACKWARD;
        }

    }

}
