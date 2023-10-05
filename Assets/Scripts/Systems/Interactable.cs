using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour
{
    public float IntRadius;

    private void Start()
    {
        SetRadius();
    }

    private void Update()
    {
        RaycastHit hit;
        
        if (Physics.SphereCast(transform.position, IntRadius, transform.forward, out hit, 0.01f))
        {
            if (hit.collider.gameObject.tag == "Player")
            {

                Interact();

            }

        }
    }

    public virtual void Interact()
    {
        Debug.Log("Inteacted");
    }

    public virtual void SetRadius()
    {
        Debug.Log("Inteacted");
    }

}
