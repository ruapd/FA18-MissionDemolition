using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {
    static public GameObject POI;

    [Header("Set in Inspector")]
    public float easing = 0.05f;
    public Vector2 minxY = Vector2.zero;

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
        //limit the x and Y to min values
        destination.x = Mathf.Max(minxY.x, destination.x);
        destination.y = Mathf.Max(minxY.y, destination.y);
        //Interpolate from the current cCamera position toward destination
        destination = Vector3.Lerp(transform.position, destination, easing);
        //force destination.z to be camZ to keep the camera gar enough away
        destination.z = camZ;
        transform.position = destination;
        Camera.main.orthographicSize = destination.y + 10;
	}
}
