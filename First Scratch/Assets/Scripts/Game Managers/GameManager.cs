using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public float playerHalfHeight;

    private static GameManager _instance;

    public Checkpoint lastCheckpoint;
    public Transform startLocation;

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
        if (startLocation!=null)
        {
            SpawnPlayerAtTransform(startLocation.position, startLocation.rotation);
        }
        else
        {
            SpawnPlayerAtTransform(Vector3.zero, Quaternion.identity);
        }

    }

    void SpawnPlayerAtTransform(Vector3 position, Quaternion rotation)
    {
        if (playerPrefab == null)
        {
            return;
        }

        GameObject player = GameObject.Instantiate(playerPrefab, position + new Vector3(0.0f, playerHalfHeight, 0.0f), rotation);
    }

    public void RespawnAtLastCheckpoint()
    {
        if(lastCheckpoint==null)
        {
            return;
        }
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player != null){
            Destroy(player);
        }
        SpawnPlayerAtTransform(lastCheckpoint.transform.position, lastCheckpoint.transform.rotation);
    }
}
