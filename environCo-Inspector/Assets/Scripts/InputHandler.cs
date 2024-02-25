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
                selectedObject = rayHit.collider.gameObject;
                offSet = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)selectedObject.transform.position;
            }
            else if (rayHit.collider && rayHit.collider.CompareTag("Turnable"))
            {
                selectedObject = rayHit.collider.gameObject;
            }
            else if (rayHit.collider && rayHit.collider.CompareTag("FixedDrag"))
            {
                selectedObject = rayHit.collider.gameObject;
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

    public void FixedDrag()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        selectedObject.transform.position = new Vector2(selectedObject.transform.position.x, mousePosition.y - offSet.y);
        Debug.Log("fixed drag");
    }

    public void Turn()
    {
        if (selectedObject.GetComponent<FaucetScript>().canMove)
        {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - selectedObject.transform.position.x, mousePosition.y - selectedObject.transform.position.y);
        selectedObject.transform.up = new Vector2((direction.x), direction.y);
        }
        else{
            selectedObject = null;
        }
    }

    public void Update()
    {
        if (selectedObject != null && selectedObject.CompareTag("Draggable"))
        {
            Drag();
        } else if (selectedObject != null && selectedObject.CompareTag("Turnable")) 
        {
            Turn();
        } else if (selectedObject != null && selectedObject.CompareTag("FixedDrag"))
        {
            FixedDrag();
        } 
    }
}