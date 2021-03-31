using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursorTrial : MonoBehaviour
{

    public Texture2D cursorArrow;
    

    void Start()
    {
        // Cursor.visible = false;
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseEnter()
    {
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.Auto);
    }

}