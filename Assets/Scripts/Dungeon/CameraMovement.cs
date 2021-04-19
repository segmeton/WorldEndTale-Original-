using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    private GameObject mainCamera;
    private GameObject charPlayer;
    // Use this for initialization
    void Start()
    {
        mainCamera = (GameObject)GameObject.FindWithTag("MainCamera");
        charPlayer = (GameObject)GameObject.FindWithTag("Player");
        //charPlayer = (GameObject)GameObject.FindWithTag("Char");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKey("left") || Input.GetKey("right") || Input.GetKey("up") || Input.GetKey("down"))
        {
            mainCamera.transform.position = new Vector3(charPlayer.transform.position.x, charPlayer.transform.position.y, -10);
        }

    }
}