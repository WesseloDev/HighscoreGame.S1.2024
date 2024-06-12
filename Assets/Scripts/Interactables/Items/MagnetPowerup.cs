using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetPowerup : Interactable
{
    [SerializeField] private float magnetTime;

    protected override void Interact()
    {
        Magnet magnet = Object.FindObjectOfType<Magnet>();

        if (magnet == null) return;

        magnet.AddMagnetTime(magnetTime);
        base.Interact();
    }

}
