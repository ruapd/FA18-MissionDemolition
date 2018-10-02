using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {
    static public GameObject POI;

    [Header("Set Dynamically")]
    public float camZ;

    void Awake()
    {
        camZ = this.transform.position.z;
    }

    // Use this for initialization
    void Start () 
    {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        if (POI == null) return;

        //get the position of the POI
        Vector3 destination = POI.transform.position;
        //force destination.z to be camZ to keep the camera gar enough away
        destination.z = camZ;
        transform.position = destination;
	}
}
