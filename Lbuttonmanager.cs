using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public enum state
{
    Nope,
    Up,
    Middle,
    Down,
    AttackOne,
    //i think its better to have a lot of these rather than another enum
    //i think what im gonna do is just have a different manager script for every character
    //or i can make another set of enums not sure
    //scalability does seem like a bit of an issue though
    AttackOneT,
    AttackOneM,
    AttackOneB
}

public class Lbuttonmanager : MonoBehaviour
{
    public Rbuttonmanager rbuttonmanager;
    public Lmovement lmovement;
    public Vector2 startPos;
    public int pixelDistToDetect = 20;
    public bool fingerDown;
    public Renderer _renderer;
    public state state = state.Nope;
    public Lattack lattack;
    public bool exception;
    public Touch t;

    void Update()
    {
        Debug.Log(state);

        int i = 0;
        while (i < Input.touchCount)
        {
            t = Input.GetTouch(i);

            if (t.phase == TouchPhase.Ended)
            {
                if (exception == true)
                {
                    fingerDown = false;
                    Debug.Log("here we go again");
                }
                
                if (exception == false)
                {
                    fingerDown = false;
                    state = state.Nope;
                }                
            }


            if (t.position.x < Screen.width / 2)
            {
                switch (t.phase)
                {
                    case TouchPhase.Began:
                        break;
                    case TouchPhase.end:
                        break;
                }
                
                
                if (t.phase == TouchPhase.Began)
                {
                    startPos = t.position;
                }
            }
            
            
            
            
            
            
            
            if (t.phase == TouchPhase.Began && fingerDown == false && Input.touchCount > 0
                && t.position.x < Screen.width / 2)
            {
                startPos = t.position;
                fingerDown = true;
            }
            else if (fingerDown == true && Input.touchCount > 0 && t.position.x < Screen.width / 2)
            {

                if (t.position.y >= startPos.y + pixelDistToDetect)
                {
                    if(lmovement.dodging == false)
                    {
                        fingerDown = false;
                        Debug.Log("UP");
                        lmovement.StartCoroutine(lmovement.dodgeUp());
                    }                    
                }

                else if (t.position.x >= startPos.x + pixelDistToDetect)
                {
                    if(lmovement.dodging == false)
                    {
                        fingerDown = false;
                        Debug.Log("RIGHT");
                        lmovement.StartCoroutine(lmovement.dodgeRight());
                    }                            
                }

                else if (t.position.y <= startPos.y - pixelDistToDetect)
                {
                    if (lmovement.dodging == false)
                    {
                        fingerDown = false;
                        Debug.Log("DOWN");
                        lmovement.StartCoroutine(lmovement.dodgeDown());
                    }                   
                }

                else if (t.position.x <= startPos.x - pixelDistToDetect)
                {
                    if (lmovement.dodging == false)
                    {
                        fingerDown = false;
                        Debug.Log("LEFT");
                        lmovement.StartCoroutine(lmovement.dodgeLeft());
                    }                    
                }



                if (t.position.y < Screen.height / 3)
                {
                    if (exception == false)
                    {
                        if (state == state.Nope && lmovement.dodging == false)
                        {
                            state = state.Down;
                        }
                    }

                    if (exception == true)
                    {
                        if (state == state.AttackOne)
                        {
                            if (lattack.attacking == false)
                            {
                                lattack.StartCoroutine(lattack.AttackB());
                                Debug.Log("bot attack");
                            }
                        }
                    }
                }

                else if (t.position.y > Screen.height / 1.5)
                {
                    if (state == state.AttackOne)
                    {
                        if (lattack.attacking == false)
                        {                            
                            lattack.StartCoroutine(lattack.AttackT());
                        }
                    }
                    else if (state == state.Nope && lmovement.dodging == false)
                    {
                        state = state.Up;
                    }
                }

                else if (t.position.y > Screen.height / 3 && t.position.y < Screen.height / 1.5)
                {
                    

                    if (state == state.AttackOne)
                    {
                        if (lattack.attacking == false)
                        {
                            lattack.StartCoroutine(lattack.AttackM());
                        }
                    }
                    else if (state == state.Nope && lmovement.dodging == false)
                    {
                        state = state.Middle;
                    }
                }
            }
            ++i;
        }



















        /*if (fingerDown == false && exception == false)
        {
            state = state.Nope;
        }*/

        if (state == state.Nope)
        {
            _renderer.material.color = new Color(0, 0, 0);
            lmovement.speed = 1.2f;
        }
        else if (state == state.Up)
        {
            _renderer.material.color = new Color(123, 255, 0);
            lmovement.speed = 0.5f;
        }
        else if (state == state.Middle)
        {
            _renderer.material.color = new Color(0, 127, 255);
            lmovement.speed = 0.5f;
        }
        else if (state == state.Down)
        {
            _renderer.material.color = new Color(255, 0, 170);
            lmovement.speed = 0.5f;
        }

        /*if (fingerDown == false && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began
            && Input.touches[0].position.x > Screen.width / 2)
        {
            startPos = Input.touches[0].position;
            fingerDown = true;
        }

        if (fingerDown && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
        {
            fingerDown = false;
        }*/





        //Debug.Log("QQQ " + Input.touches[0].position + " QQQQ");

        /*if (Input.touches[goodFunny].position.y >= startPos.y + pixelDistToDetect)
        {
            fingerDown = false;
            Debug.Log("UP");
            rmovement.StartCoroutine(rmovement.dodgeUp());
        }

        else if (Input.touches[goodFunny].position.x >= startPos.x + pixelDistToDetect)
        {
            fingerDown = false;
            Debug.Log("RIGHT");
            rmovement.StartCoroutine(rmovement.dodgeRight());
        }

        else if (Input.touches[goodFunny].position.y <= startPos.y - pixelDistToDetect)
        {
            fingerDown = false;
            Debug.Log("DOWN");
            rmovement.StartCoroutine(rmovement.dodgeDown());
        }

        else if (Input.touches[goodFunny].position.x <= startPos.x - pixelDistToDetect)
        {
            fingerDown = false;
            Debug.Log("LEFT");
            rmovement.StartCoroutine(rmovement.dodgeLeft());
        }

        else
        {
            if (Input.touches[goodFunny].position.y < Screen.height / 3 && exception == false)
            {
                //Debug.Log("bot... bruh");
                state = state.Down;
            }

            else if (Input.touches[goodFunny].position.y > Screen.height / 1.5 && exception == false)
            {
                //Debug.Log("top... bruh");
                state = state.Up;
            }

            else if (Input.touches[goodFunny].position.y > Screen.height / 3 && Input.touches[0].position.y < Screen.height / 1.5)
            {
                if (state == state.AttackOne)
                {
                    if (rattack.attacking == false)
                    {
                        rattack.StartCoroutine(rattack.Attack());
                    }
                }

                else if (exception == false)
                {
                    //Debug.Log("mid... bruh");

                    if (state == state.Nope)
                    {
                        state = state.Middle;
                    }
                }
            }
        }
    }*/
    }
}
