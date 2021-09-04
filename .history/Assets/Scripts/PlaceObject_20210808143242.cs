﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

public class PlaceObject : MonoBehaviour
{
    public GameObject AR_object;
    public Camera AR_Camera;
    public ARRaycastManager raycastManager;
    public List<ARRaycastHit> hits = new List<ARRaycastHit>();
    public Image joystick;
    public Image brakeIcon;
    bool notPlaced = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && notPlaced)
        {
            Ray ray = AR_Camera.ScreenPointToRay(Input.mousePosition);
            if(raycastManager.Raycast(ray, hits))
            {
                Pose pose = hits[0].pose;
                // Instantiate(AR_object, pose.position, pose.rotation);
                AR_object.SetActive(true);
                AR_object.transform.position = pose.position;
                // AR_object.transform.rotation = pose.rotation;
                brakeIcon.enabled = true;
                joystick.enabled = true;
                // notPlaced = false;
            }
        }
        
    }
}