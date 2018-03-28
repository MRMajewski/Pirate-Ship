using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

    public Transform ShipModel;


    public float MinSpeed = 2f;
    public float MaxSpeed = 10f;
    float CurrentSpeed;

    public float MaxAngle = 30f;
    float CurrentAngle = 0;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        //nadawanie prędkości
        var targetSpeed = Input.GetKey(KeyCode.W) ? MaxSpeed : MinSpeed; //uproszczona wersja warunku poniżej

        //var targetSpeed = MinSpeed;
        // if (Input.GetKey(KeyCode.W))
        //    targetSpeed = MaxSpeed;

        CurrentSpeed = Mathf.Lerp(CurrentSpeed, targetSpeed, Time.deltaTime);//funkcja
                                                                             //pozwala na płynne przejście z jednej wartości do drugiej w czasie kolejnych klatek

        //nadawanie kąta skręcania
        var targetAngle = 0f;

        if (Input.GetKey(KeyCode.A))
        targetAngle =-MaxAngle;

        if (Input.GetKey(KeyCode.D))
            targetAngle = MaxAngle;

        CurrentAngle = Mathf.Lerp(CurrentAngle, targetAngle, Time.deltaTime/2f);

        //Debug.Log(CurrentAngle);


        // poruszanie się
        var rigidbody = GetComponent<Rigidbody>();

        rigidbody.rotation *= Quaternion.Euler(Vector3.up * CurrentAngle*Time.deltaTime); //Kwateriony służą do przechowywania  kątów?
        rigidbody.velocity = rigidbody.rotation * Vector3.forward* CurrentSpeed;


        //obroty modelu (realizm)
        var rotationX = Mathf.Sin(Time.timeSinceLevelLoad *1.5f)*2f; //pochylenie się od fal
        var rotationZ = -CurrentAngle/2f; // pochylenie od skręcania

        ShipModel.localRotation = Quaternion.Euler(rotationX, 0, rotationZ);


    }
}
