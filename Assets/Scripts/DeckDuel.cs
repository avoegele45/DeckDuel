using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class DeckDuel : MonoBehaviour
{
    private Camera mainCamera;
    private Transform selectedParent; 

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
               
                Transform root = hit.collider.transform.root;
                selectedParent = root;
            }
        }

        // Move the entire prefab 
        if (selectedParent != null && Input.GetMouseButton(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector3 newPosition = hit.point;
                newPosition.y = 0;
                selectedParent.position = newPosition; 
            }
        }


        if (Input.GetMouseButtonUp(0))
        {
            selectedParent = null;
        }
    }
}

