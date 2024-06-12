using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float rotSpeed;
    
    void Update()
    {
        transform.Rotate(0, 0, rotSpeed * Time.deltaTime);
    }
}
