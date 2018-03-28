using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Destroy(gameObject, 10f);

    }
	
	// Update is called once per frame
    private void OnCollisionEnter (Collision collision ) {

        var layerID = collision.collider.gameObject.layer;

        var layerName = LayerMask.LayerToName(layerID);

        Debug.Log(layerName);
      
	}
}
