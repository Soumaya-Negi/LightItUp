using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // If you want UI for timer
using TMPro;
public class RespawnTimer : MonoBehaviour
{
    public float collectionTime = 60f; // 1 min
    public Transform player;
    public Transform crashpodBase; // Where player is teleported after time ends
    public TextMeshProUGUI timerText;
         // Optional UI text

    private float timeLeft;
    private bool timerRunning = false;

    void Update()
    {
        if (timerRunning)
        {
            timeLeft -= Time.deltaTime;
            if (timerText != null)
                timerText.text = "Time: " + Mathf.Ceil(timeLeft).ToString();

            if (timeLeft <= 0)
            {
                EndCollectionPhase();
            }
        }
    }

    public void StartCollectionPhase()
    {
        timeLeft = collectionTime;
        timerRunning = true;
    }

    void EndCollectionPhase()
    {
        timerRunning = false;
        // Teleport player back to base
        player.position = crashpodBase.position;
        Debug.Log("Collection phase ended! Back to base for upgrades.");
    }
}

