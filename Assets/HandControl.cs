using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandControl : MonoBehaviour
{
    private Vector2 joystick;
    private Vector3 startPos;

    public float sensivity;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        joystick.x = Input.GetAxis("Horizontal");
        joystick.y = Input.GetAxis("Vertical");

        joystick *= sensivity;

        Vector3 updatedPosition = new Vector3(joystick.x, joystick.y, 0f);

        transform.position = updatedPosition + startPos;
    }
}
