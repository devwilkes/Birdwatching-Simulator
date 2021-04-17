using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public float playerHalfHeight;

    private static GameManager _instance;

    public Checkpoint lastCheckpoint;

    public static GameManager Instance
    {
        get 
        {
            return _instance;
        }
    }
    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        SpawnPlayerAtTransform(Vector3.zero, Quaternion.identity);
    }

    void SpawnPlayerAtTransform(Vector3 position, Quaternion rotation)
    {
        if (playerPrefab == null)
        {
            return;
        }

        GameObject player = GameObject.Instantiate(playerPrefab, position + new Vector3(0.0f, playerHalfHeight, 0.0f), rotation);
    }
}
