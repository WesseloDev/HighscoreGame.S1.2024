using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourglassPowerup : Interactable
{
    [SerializeField] private float timeToAdd;

    protected override void Interact()
    {
        GameManager.AddTime(timeToAdd);
        base.Interact();
    }

}
