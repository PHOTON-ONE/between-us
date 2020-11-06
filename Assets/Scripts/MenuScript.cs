using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    //This is Main Camera in the Scene
    Camera MainCamera;
    //This is the menu Camera and is assigned in inspector
    public Camera MenuCamera;
    Transform Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
        //This gets the Main Camera from the Scene
        MainCamera = Camera.main;
        //This enables Main Camera
        MainCamera.enabled = false;
        //Use this to disable secondary Camera
        MenuCamera.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement playerMov = Player.GetComponent<PlayerMovement>();
        

        //Press the L Button to switch cameras
        if (Input.GetKeyDown(KeyCode.L))
        {
            //Check that the Main Camera is enabled in the Scene, then switch to the other Camera on a key press
            if (MainCamera.enabled)
            {
                //Enable the second Camera
                MenuCamera.enabled = true;

                //The Main first Camera is disabled
                MainCamera.enabled = false;
                playerMov.canMove = false;
            }
            //Otherwise, if the Main Camera is not enabled, switch back to the Main Camera on a key press
            else if (!MainCamera.enabled)
            {
                //Disable the second camera
                MenuCamera.enabled = false;

                //Enable the Main Camera
                MainCamera.enabled = true;
                playerMov.canMove = true;
            }
        }
    }
}
