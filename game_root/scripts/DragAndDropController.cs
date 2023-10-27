using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropController : MonoBehaviour
{
    public bool isDraggable = true;
    private bool isDragged = false;
    public Vector3 PositionMouse;
    public Vector3 PositionObject;
    void Update()
    {
        
        PositionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        PositionObject = transform.position;

        if(isDragged) {
            transform.position = new Vector3(Mathf.Round(PositionMouse.x/145)*145,Mathf.Round(PositionMouse.y/147)*147,0);
            if(Input.GetMouseButtonUp(0)) {
                isDragged=false;
            }
        }
    }
    private void OnMouseDown() {
        Debug.Log("Mouse Down");
        if(isDraggable) {
            isDragged=true;
        }
    }
}
