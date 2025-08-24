using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashPodTrigger : MonoBehaviour
{
    public GameObject upgradePanel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            upgradePanel.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            upgradePanel.SetActive(false);
    }
}
