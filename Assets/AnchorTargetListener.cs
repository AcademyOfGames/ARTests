using System;
using UnityEngine;
using Vuforia;

public class AnchorTargetListener : MonoBehaviour//, DefaultObserverEventHandler 
{

    //The Goal of this class is to automatically Initiate a Ground Plane when the Image Target is detected
    // Use this class in combination with the PlaceContentFromImageTarget if you want to move the content
    // of an image target onto the Ground Plane Stage

    //This class should replace the default AnchorInputListenerBehaviour in the PlaneFinder GameObject
    //Don't forget to set the OnInputReceivedEvent of this component to call the PlaneFinderBehaviour

    //public ImageTargetBehaviour ImageTarget;
    private bool _planeFound = false;

    public ObserverBehaviour  ImageTarget;
    public AnchorInputListenerBehaviour.InputReceivedEvent OnInputReceivedEvent;
    public Vector3 imageTargetPos;
    void Start () 
    {   
        
        if (this.ImageTarget != null)
        {
            this.ImageTarget.OnTargetStatusChanged += OnTrackableStateChanged; // RegisterTrackableEventHandler(this);
        }
    }
    
    
	
    public void OnTrackableStateChanged(ObserverBehaviour o, TargetStatus t)
    {
        if (_planeFound)
        {
            return;
        }
        if (t.Status != Status.NO_POSE )
        {
            Debug.Log("OnInputReceivedEvent " + OnInputReceivedEvent);

            if (OnInputReceivedEvent != null)
            {
                imageTargetPos = ImageTarget.transform.position;
                //TODO: is Camera.main still slow?
                Vector3 hitTestLocation = Camera.main.WorldToScreenPoint(imageTargetPos);

                OnInputReceivedEvent.Invoke(hitTestLocation);
                _planeFound = true;
            }
        }
    }
}
