using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementHandler : MonoBehaviour {


     public int boundary = 100; // distance from edge scrolling starts
     public int speed = 1000;

     private int theScreenWidth;
     private int theScreenHeight;
     void Start()
        {
            theScreenWidth = Screen.width;
            theScreenHeight = Screen.height;
        }
        void Update()
        {
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
}
