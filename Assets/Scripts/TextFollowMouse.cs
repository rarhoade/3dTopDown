using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFollowMouse : MonoBehaviour
{
    public Vector3 offset;
    private void Update()
    {
       transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0) + offset; 
    }

    public void updateText(string inText)
    {
        GetComponent<Text>().text = inText;
    }
}
