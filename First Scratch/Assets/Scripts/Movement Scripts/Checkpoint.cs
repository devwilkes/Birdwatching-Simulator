using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Material activeMaterial;
    public Material inactiveMaterial;
    public MeshRenderer mesh;
    private bool _isActive = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            return;
        }

        if (GameManager.Instance.lastCheckpoint != null){
            GameManager.Instance.lastCheckpoint = this;
        }

        GameManager.Instance.lastCheckpoint = this;
        ToggleActive(true);
    }

    public void ToggleActive(bool isActive)
    {
        _isActive = isActive;

        if(mesh == null)
        {
            return;
        }

        if (_isActive)
        {
            mesh.material = activeMaterial;
        }
        else
        {
            mesh.material = inactiveMaterial;
        }
    }
}
