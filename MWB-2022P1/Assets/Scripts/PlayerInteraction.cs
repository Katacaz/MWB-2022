using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Interactable objectInSight;
    public float interactableDistance = 5.0f;

    public LayerMask interactLayers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactableDistance, interactLayers))
        {
            if (hit.collider.gameObject.TryGetComponent(out Interactable interactable))
            {

                objectInSight = interactable;
                
            } else
            {
                objectInSight = null;
            }
        } else
        {
            objectInSight = null;
        }
    }

    public void InteractWithObject()
    {
        if (objectInSight != null)
        {
            objectInSight.GetComponent<Interactable>().OnInteract();
        }
    }
}
