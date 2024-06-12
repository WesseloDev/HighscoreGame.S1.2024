using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject parent;

    [SerializeField] private GameObject[] coins = new GameObject[2];
    [SerializeField] private GameObject[] powerups = new GameObject[2];

    private Vector3 origin = Vector3.zero;

    [SerializeField] private int initialCoins = 20;
    [SerializeField] private int initialPowerups = 5;
    [SerializeField] private float range = 60f;

    [SerializeField] private float timeBetweenCoins = 3f;
    private float coinTimer;

    [SerializeField] private float timeBetweenPowerups = 10f;
    private float powerupTimer;

    void Start()
    {
        coinTimer = timeBetweenCoins;
        powerupTimer = timeBetweenPowerups;

        SpawnInitialItems();
    }

    void Update()
    {
        if (GameManager.gameOver) return;

        coinTimer -= Time.deltaTime;
        powerupTimer -= Time.deltaTime;

        if (coinTimer <= 0f)
        {
            coinTimer = timeBetweenCoins;
            SpawnCoin();
        }

        if (powerupTimer <= 0f)
        {
            powerupTimer = timeBetweenPowerups;
            SpawnPowerup();
        }
    }

    void SpawnInitialItems()
    {
        for (int i = 0; i <= initialPowerups; i++)
        {
            SpawnPowerup();
        }

        for (int i = 0; i <= initialCoins; i++)
        {
            SpawnCoin();
        }
    }

    void SpawnCoin()
    {
        int index = Random.Range(1, 4) == 1 ? 1 : 0;

        GameObject coin = Instantiate<GameObject>(coins[index], parent.transform);
        coin.transform.position = PickPosition();
        coin.transform.SetParent(parent.transform);
    }

    void SpawnPowerup()
    {
        int index = Random.Range(1, 3) == 1 ? 1 : 0;

        GameObject powerup = Instantiate<GameObject>(powerups[index], parent.transform);
        powerup.transform.position = PickPosition();
        powerup.transform.SetParent(parent.transform);
    }

    Vector3 PickPosition()
    {
        Vector3 spherePos = Random.insideUnitSphere * range;
        spherePos.y = 100f;

        if (Physics.Raycast(spherePos, Vector3.down, out RaycastHit hit, 200f))
        {
            return hit.point + new Vector3(0f, 1f, 0f);
        }

        return PickPosition();
    }
}
