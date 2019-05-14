using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float ScrollSpeed = 15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 scrollType = new Vector3(0, 0, 0);
        
        if(Input.mousePosition.y >= Screen.height * 0.95f)
        {
            scrollType += Vector3.forward;
        }
        if (Input.mousePosition.y <=  Screen.width * 0.05f)
        {
            scrollType += Vector3.back;
        }
        if (Input.mousePosition.x >= Screen.width * 0.95f)
        {
            scrollType += Vector3.right;
        }
        if (Input.mousePosition.x <= Screen.width * 0.05f)
        {
            scrollType += Vector3.left;
        }
        transform.Translate(scrollType * Time.deltaTime * ScrollSpeed, Space.World);  
    }
}
