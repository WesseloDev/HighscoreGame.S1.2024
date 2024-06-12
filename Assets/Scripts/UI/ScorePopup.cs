using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePopup : MonoBehaviour
{
    private Text text;
    private RectTransform textTransform;

    [SerializeField] private float lifespan;
    [SerializeField] private float fallSpeed;
    [SerializeField] private float fadeSpeed;

    void Start()
    {
        text = GetComponent<Text>();
        textTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        Vector3 curPos = textTransform.anchoredPosition;
        Color vertCol = text.color;

        textTransform.anchoredPosition = new Vector3(curPos.x, curPos.y -= fallSpeed * Time.unscaledDeltaTime, 0);
        text.color = new Color(vertCol.r, vertCol.g, vertCol.b, vertCol.a -= fadeSpeed * Time.unscaledDeltaTime);
        lifespan -= 1f * Time.unscaledDeltaTime;
        if (lifespan <= 0f)
        {
            Destroy(base.gameObject);
        }
    }
}
