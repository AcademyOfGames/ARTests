using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneControl : MonoBehaviour
{
    private bool following;

    public Transform player;

    public float speed;

    public float maxFollowDistance;
    public GameObject imageTarget;

    public float currentDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    public void SetFollow(bool follow)
    {
        Debug.Log(" Following drone");

        following = follow;
        Invoke("DisableImageTracker", 1f);
    }

    void DisableImageTracker()
    {
        //imageTarget.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {
        transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().enabled = true;
        
         currentDistance = Vector3.Distance(transform.position, player.position);
        float currentSpeed = speed * currentDistance;
        if (following)
        {
            transform.LookAt(player.position);
            if (currentDistance > maxFollowDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position,player.position, speed);
            }
            
        }
    }
}
