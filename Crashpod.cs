using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal; // For Light2D

public class Crashpod : MonoBehaviour
{
    public Transform spawnPoint;
    public Light2D podLight;
    public float lightRadius = 5f;

    void Start()
    {
        if (podLight != null)
            podLight.pointLightOuterRadius = lightRadius;
    }

    public void UpgradeLight(float extraRadius)
    {
        lightRadius += extraRadius;
        if (podLight != null)
            podLight.pointLightOuterRadius = lightRadius;
    }

    public Vector3 GetSpawnPoint()
    {
        return spawnPoint != null ? spawnPoint.position : transform.position;
    }
}