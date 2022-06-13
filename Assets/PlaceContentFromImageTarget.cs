using System;
using UnityEngine;
using Vuforia;

public class PlaceContentFromImageTarget : MonoBehaviour 
{
    public ObserverBehaviour ImageTarget;

    public void SetToGroundPlane()
    {
        DroneControl drone = FindObjectOfType<DroneControl>();
        drone.SetFollow(true);
            print("Setting parent");
        drone.transform.SetParent(GameObject.Find("ParentCube").transform);
        drone.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().enabled = true;

        /*
        for (var i = 0; i < ImageTarget.transform.childCount; i++)
        {
            var content = ImageTarget.transform.GetChild(i);
            print("setting parent of " + content.name);
            content.SetParent(GameObject.Find("ParentCube").transform);
            //content.transform.parent = null;
            print("getting skinned meshrederer");
            
            content.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().enabled = true;
        }*/
        print("Destroying "  + ImageTarget.gameObject.name);

        Destroy(ImageTarget.gameObject);
        print("target destroyed ");

    }

    
}
