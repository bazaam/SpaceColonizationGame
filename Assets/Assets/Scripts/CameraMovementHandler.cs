using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class CameraMovementHandler : NetworkBehaviour
{


    public int boundary = 100; // distance from edge scrolling starts
    public int speed = 1000;

    private bool isPaused;
    private int theScreenWidth;
    private int theScreenHeight;
    private Camera cam;

    void Start()
    {
        //cam = gameObject.GetComponentInChildren<Camera>();
        //if (!isLocalPlayer)
        //{
        //    cam.enabled = false;
        //}
        theScreenWidth = Screen.width;
        theScreenHeight = Screen.height;
    }
    void Update()
    {
        //if (!isLocalPlayer)
        //{
        //    return;
        //}
        if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 1)
        {
            return;
        }

        if (isPaused)
        {
        return;
        }

        if (Input.mousePosition.x > theScreenWidth - boundary)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0); // move on +X axis
        }
        if (Input.mousePosition.x < 0 + boundary)
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0); // move on -X axis
        }
        if (Input.mousePosition.y > theScreenHeight - boundary)
        {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0); // move on +Z axis
        }
        if (Input.mousePosition.y < 0 + boundary)
        {
            transform.position -= new Vector3(0, speed * Time.deltaTime, 0); // move on -Z axis
        }
    }

    void OnGUI()
        {
            //GUI.Box(Rect((Screen.width / 2) - 140, 5, 280, 25), "Mouse Position = " + Input.mousePosition);
            //GUI.Box(Rect((Screen.width / 2) - 70, Screen.height - 30, 140, 25), "Mouse X = " + Input.mousePosition.x);
           // GUI.Box(Rect(5, (Screen.height / 2) - 12, 140, 25), "Mouse Y = " + Input.mousePosition.y);
        }
    void OnApplicationFocus(bool hasFocus)
    {
        isPaused = !hasFocus;
    }

}
