using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawnTest : MonoBehaviour
{
    public Crashpod crashpod; // Assign in Inspector

    void Update()
    {
        // Press 'K' to simulate death and respawn
        if (Input.GetKeyDown(KeyCode.K))
        {
            Respawn();
        }
    }

    void Respawn()
    {
        if (crashpod != null)
        {
            transform.position = crashpod.GetSpawnPoint();
            Debug.Log("Player respawned at Crashpod!");
        }
    }
}

