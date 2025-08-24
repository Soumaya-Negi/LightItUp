using UnityEngine;
using UnityEngine.UI;  // Use TMPro if using TextMeshPro
using TMPro;
public class TimerUI : MonoBehaviour
{
    public TextMeshProUGUI timerText;  // Drag your Text UI here in the inspector
    public float startTime = 60f; // 1 minute for each round
    public bool timerActive = false;  // Controlled by UpgradeManager or respawn logic

    private float currentTime;

    void Start()
    {
        ResetTimer(); // Start timer on game start (optional)
    }

    void Update()
    {
        if (!timerActive) return;

        currentTime -= Time.deltaTime;
        currentTime = Mathf.Max(0, currentTime);

        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = $"{minutes:00}:{seconds:00}";

        if (currentTime <= 0)
        {
            timerActive = false;
            // Time's up → Return to base or trigger some event here
            Debug.Log("Time up! Returning to base...");
        }
    }

    public void ResetTimer()
    {
        currentTime = startTime;
        timerActive = true;
    }
}
