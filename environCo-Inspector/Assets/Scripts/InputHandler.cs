using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private Camera mainCamera;
    private GameObject selectedObject;

    private Vector2 offSet;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            var rayHit = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));

            if (rayHit.collider && rayHit.collider.CompareTag("Draggable"))
            {
                Debug.Log(rayHit.collider.gameObject.name);
                selectedObject = rayHit.collider.gameObject;
                offSet = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)selectedObject.transform.position;
            }
        }
        else if (context.canceled)
        {
            selectedObject = null;
            Debug.Log("Stopped click");
        }
    }

    public void Drag()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        selectedObject.transform.position = mousePosition - offSet;
        Debug.Log("Dragging");
    }

    public void Update()
    {
        if (selectedObject != null)
        {
            Drag();
        }
    }
}