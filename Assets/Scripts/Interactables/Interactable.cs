using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private Collider itemCollider;

    private void Start()
    {
        itemCollider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") return;
        Interact();
    }

    protected virtual void Interact()
    {
        Destroy(gameObject);
    }
}
