using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public void ReturnToLastCheckpoint()
    {
        Checkpoint lastCheckpoint = GameManager.Instance.lastCheckpoint;
        if (lastCheckpoint == null)
        {
            return;
        }

        float halfHeight = GameManager.Instance.playerHalfHeight;

        transform.position = lastCheckpoint.transform.position + new Vector3(0.0f, halfHeight, 0.0f);
        transform.rotation = lastCheckpoint.transform.rotation;
    }

    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            ReturnToLastCheckpoint();
        }
    }
}
