using System;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Camera cam;

    Transform player;

    public float leftBorder = -31;
    public float rightBorder = 31;
    public float topBorder = 18;
    public float bottomBorder = -18;

    void Start()
    {
        
        player = GameObject.Find("Player").GetComponent<Transform>();
        cam = GetComponent<Camera>();

}

    // Update is called once per frame
    void Update()
    {
        //Moved the Cam to the player
        if (cam.orthographicSize <= 17)
        {
            this.gameObject.transform.position = new Vector2(player.position.x, player.position.y);
        }
        else
        {
            this.gameObject.transform.position = new Vector2(leftBorder - 15.5f, topBorder - 9);
        }
        

        //Moved the cam out and in
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if(cam.orthographicSize > 8)
            {
                cam.orthographicSize -= 0.5f;
            }
            
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if(cam.orthographicSize < 17.5)
            {
                cam.orthographicSize += 0.5f;
            }
            
        }

        //Resize the Cam Size so the player doesn't see the skybox to all Levels

        Vector2 viewSize = new Vector2(cam.orthographicSize * cam.aspect, cam.orthographicSize);
        cam.transform.position = new Vector3(Mathf.Clamp(cam.transform.position.x,leftBorder + viewSize.x, rightBorder - viewSize.x),
        Mathf.Clamp(cam.transform.position.y, bottomBorder + viewSize.y, topBorder - viewSize.y), -11F);

    }

}
