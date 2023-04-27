using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    public Rigidbody player;
    public Camera cam;
    public float speed;
    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;

    public float h = 0f;
    public float v = 0f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKey("a")){
            player.velocity = -cam.transform.right * speed;
        }
        if (Input.GetKey("d")){
            player.velocity = cam.transform.right * speed;
        }
        if (Input.GetKey("w")){
            player.velocity = cam.transform.forward * speed;
        }
        if (Input.GetKey("s")){
            player.velocity = -cam.transform.forward * speed;
        }
        player.velocity = new Vector3(player.velocity.x, 0, player.velocity.z);

        h += horizontalSpeed* Input.GetAxis("Mouse X");
        v -= verticalSpeed* Input.GetAxis("Mouse Y");

                

        cam.transform.eulerAngles = new Vector3(Mathf.Clamp(cam.transform.rotation.x+v, -50, 50), cam.transform.rotation.y+h, 0f);


    }
}
