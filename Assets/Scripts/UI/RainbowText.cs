using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RainbowText : MonoBehaviour
{
    private Text text;
    private float speed = 0.1f;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        Color.RGBToHSV(text.color, out float H, out float S, out float V);
        text.color = Color.HSVToRGB(H + (speed * Time.deltaTime), S, V);
    }
}
