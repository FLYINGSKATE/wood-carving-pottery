using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursorChanger : MonoBehaviour
{
    public float xOffset,yOffset;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 vector = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
        //Debug.Log(Camera.main.ScreenToWorldPoint(vector));
        vector = Camera.main.ScreenToWorldPoint(vector);
        transform.position = new Vector3(vector.x+xOffset,vector.y+yOffset,transform.position.z);
    }
}