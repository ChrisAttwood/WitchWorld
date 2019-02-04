using UnityEngine;
using System.Collections;
using System;
using UnityEngine.EventSystems;

public class CameraMan : MonoBehaviour {


    [Range(0f, 0.1f)]
    public float Speed;

    Camera cam;


    void Start()
    {
        cam = GetComponent<Camera>();

    }

    void Update () {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.position = new Vector3(0f, 0f, -10f);
        }


        CheckForScroll();
        CheckWheel();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

   

  

    void CheckWheel()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0f) 
        {
            if (cam.orthographicSize < 26f)
            {
                cam.orthographicSize += 1f;

            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0f) 
        {
            if (cam.orthographicSize>3f)
            {
                cam.orthographicSize -= 1f;
            }
        }
    }

   

    void CheckForScroll()
    {


        if (NearLeft() || Input.GetKey(KeyCode.A))
        {
            if (transform.position.x > -256)
            {
                transform.Translate(Vector3.left * Speed * cam.orthographicSize, Space.World);
            }
            
        }

        if (NearRight() || Input.GetKey(KeyCode.D))
        {
            if (transform.position.x < 256)
            {
                transform.Translate(Vector3.left * -Speed * cam.orthographicSize, Space.World);
            }
        }

        if (NearTop() || Input.GetKey(KeyCode.W))
        {
            if (transform.position.y < 256)
            {
                transform.Translate(Vector3.up * Speed * cam.orthographicSize, Space.World);
            }
        }

        if (NearBottom() || Input.GetKey(KeyCode.S))
        {
            if (transform.position.y > -256)
            { 
                transform.Translate(Vector3.up * -Speed * cam.orthographicSize, Space.World);
            }
        }


    }


    bool NearLeft()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return false;

        float pos = Input.mousePosition.x;

        if (pos < 20)
        {

            //if (transform.position.x > 10)
            {
                return true;
            }
        }
        return false;
    }

    bool NearRight()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return false;

        float pos = (Screen.width - Input.mousePosition.x);

        if (pos < 20)
        {
            //if (transform.position.x < 90)
            {
                return true;
            }
        }
        return false;

    }

    bool NearTop()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return false;

        float pos = (Screen.height - Input.mousePosition.y);

        if (pos < 20)
        {
           // if (transform.position.y < 90)
            {
                return true;
            }
        }
        return false;

    }

    bool NearBottom()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return false;

        float pos = Input.mousePosition.y;

        if (pos < 20)
        {
           // if (transform.position.y > 10)
            {
                return true;
            }
        }
        return false;

    }

}
