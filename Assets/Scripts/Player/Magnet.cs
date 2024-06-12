using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    private Collider magnetCollider;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float magnetSpeed;

    [SerializeField] private GameObject timerDisplay;

    public float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        magnetCollider = GetComponent<Collider>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (GameManager.gameOver || timer <= 0f) return;

        if (other.gameObject.GetComponent<Coin>())
        {
            other.transform.position = Vector3.Lerp(other.transform.position, playerTransform.position, magnetSpeed * Time.deltaTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameOver) return;

        if (timer <= 0f)
        {
            timerDisplay.SetActive(false);
        }
        else if (timer > 0f)
        {
            timer -= Time.deltaTime;
        }
    }

    public void AddMagnetTime(float timeToAdd)
    {
        if (GameManager.gameOver) return;

        timerDisplay.SetActive(true);
        timer += timeToAdd;
    }
}
