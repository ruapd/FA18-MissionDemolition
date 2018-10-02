﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject prefabProjectile;
    public float velocityMult = 8f;

    [Header("Set Dynamically")]
    public GameObject launchPoint;
    public Vector3 launchPos;
    public GameObject projectile;
    public bool aimingMode;

    void Awake()
    {
        Transform launchPointTrans = transform.Find("LaunchPoint");
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive(false);
        launchPos = launchPointTrans.position;
    }
    void OnMouseEnter() 
    {
        //print("Slingshot:OnMouseEnter()");
        launchPoint.SetActive(true);
	}

    void OnMouseExit()
    {
        //print("Slingshot:OnMouseExit()");
        launchPoint.SetActive(false);
    }
    void OnMouseDown()
    {
        //player clicks while hovering over the slingshot.
        aimingMode = true;
        //Instantiate a Projectile.
        projectile = Instantiate(prefabProjectile) as GameObject;
        //start ut at the launch point
        projectile.transform.position = launchPos;
        //Set it to is Kinesmatic
        projectile.GetComponent<Rigidbody>().isKinematic = true;
    }
}
