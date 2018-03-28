using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallShooter : MonoBehaviour {

    public GameObject CannonBallPrefab;

    public Vector3 LeftSpawnPosition; //miejsce pojawienie się kuli armatniej (współrzędne
    public Vector3 LeftShootDirection;// kierunek ruchu kuli armatniej

    public Vector3 RightSpawnPosition;
    public Vector3 RightShootDirection;

    public float ShootPeriod= 1f;
    float LastShootTime = 0;


	
	// Update is called once per frame
	void Update ()
    {
        if (!Input.GetKeyDown(KeyCode.Space)) return;

        if (Time.timeSinceLevelLoad - LastShootTime < ShootPeriod) return; 
        //porównujemy czas od włączenia gry minus czas ostatniego strzału do Cooldownu działa
        LastShootTime = Time.timeSinceLevelLoad;

        var camera = FindObjectOfType<Camera>();//znajdujemy obiekt typu Camera
        var direction = camera.GetCameraLookDirection();

        if (direction == CameraLookDirection.BACKWARD ||
            direction == CameraLookDirection.FORWARD)
            return;

        var lookLeft = direction == CameraLookDirection.LEFT; // jako lookLeft dajemy domyślnie LEFT i sprawdzamy ten warunek
        var SpawnPosition = lookLeft ? LeftSpawnPosition : RightSpawnPosition;
        var ShootDirection = lookLeft ? LeftShootDirection : RightShootDirection;

        var ball = Instantiate(CannonBallPrefab);
        ball.transform.position = transform.position +transform.rotation * SpawnPosition;

        var rigidBody = ball.GetComponent<Rigidbody>();
        rigidBody.velocity = transform.rotation * ShootDirection;

	}
}
