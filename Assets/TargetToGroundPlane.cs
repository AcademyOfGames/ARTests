using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetToGroundPlane : MonoBehaviour
{
    public Transform trackingObject;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void SetDrone()
    {
        trackingObject.SetParent(transform,true);
        trackingObject.GetComponent<DroneControl>().SetFollow(true);
    }
    // Update is called once per frame
    void Update()
    {/*
        if (Input.touchCount > 0)
        {
            SetDrone();
        }*/
    }
}
