using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Interactable, IScoreable
{
    [SerializeField] private MeshRenderer coinRenderer;

    [SerializeField] private int value;

    public int Value
    {
        get
        {
            return value;
        }
    }

    protected override void Interact()
    {
        GameManager.AddScore(value);
        base.Interact();
    }
}
