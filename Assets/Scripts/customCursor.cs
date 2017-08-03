using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customCursor : MonoBehaviour {

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    private Ray ray;

    void SetCursorTexture (Texture2D cursorTexture)
    {
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
    }
    private void Start()
    {
        SetCursorTexture(cursorTexture);
    }
    private void Update()
    {
        RaycastHit hit;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.name.Contains("cursorTexture"))
            {
                SetCursorTexture(cursorTexture);
            }

        } 
    }
}
