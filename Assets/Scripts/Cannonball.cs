using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour {

    public GameObject WaterSplash;
    public GameObject TerrainSplash;

    // Use this for initialization
    void Start () {

        Destroy(gameObject, 10f);

    }
	
	// Update is called once per frame
    private void OnCollisionEnter (Collision collision ) {

        var layerID = collision.collider.gameObject.layer;
        var layerName = LayerMask.LayerToName(layerID);

        GameObject particleObject = null;

        if (layerName == "Water")
            particleObject = WaterSplash;

        if (layerName == "Terrain")
            particleObject = TerrainSplash;

        var position = collision.contacts[0].point;

        Instantiate(particleObject, position, Quaternion.identity);

        Destroy(gameObject);



    }
}
