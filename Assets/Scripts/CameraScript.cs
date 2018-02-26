using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    float MaxRange;
    public GameObject Player;
    public Transform MainCamera;
    void Start()
    {
        //Search for player
        Player = GameObject.Find("Player");
        MainCamera = GetComponent<Transform>();
        //Resize the camera accordingly to the resolution
        /*Camera.main.projectionMatrix = Matrix4x4.Ortho(
                -orthographicSize * aspect, orthographicSize * aspect,
                -orthographicSize, orthographicSize,
                GetComponent<Camera>().nearClipPlane, GetComponent<Camera>().farClipPlane);*/

    }

    void Update()
    {
        //Camera follows player only in the X axis
       if (Player != null)
        {
            GetComponent<Transform>().position = new Vector3(Player.GetComponent<Transform>().position.x, Player.GetComponent<Transform>().position.y+5.5f, -10);
        }
       if(MainCamera.position.y <= 3)
        {
            GetComponent<Transform>().position = new Vector3(Player.GetComponent<Transform>().position.x, 3, -10);
        }
        if (MainCamera.position.x <= -1.88f)
        {
            GetComponent<Transform>().position = new Vector3(-2, Player.GetComponent<Transform>().position.y + 5.5f, -10);
        }
    }
}
