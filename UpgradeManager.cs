using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class UpgradeManager : MonoBehaviour
{
    [Header("References")]
    public PlayerResources playerResources;      // Assign your player
    public Light2D playerTorch;                   // Assign Player Torch
    public Crashpod crashpod;                     // Assign Crashpod
    public TMP_Text torchCostText;
    public TMP_Text podCostText;
    public TMP_Text speedCostText;
    public TMP_Text timerText;                    // Assign a TMP Text for timer display
    public BiomeManager biomeManager;             // Assign BiomeManager in Inspector
    public PlayerMovement playerMovement;         // Assign in Inspector

    [Header("Upgrade Settings")]
    public int baseWoodCost = 5;
    public int baseStoneCost = 2;
    public float torchRadiusIncrease = 1.5f;
    public float podLightIncrease = 2f;
    public int speedCostWood = 3;
    public int speedCostStone = 2;
    public float speedIncrease = 1.5f;

    private int torchLevel = 1;
    private int podLevel = 1;
    private float elapsedTime = 0f; // Track in-game time
    public int GetPodLevel() => podLevel;

    void Start()
    {
        UpdateUI();
    }

    void Update()
    {
        // Update timer every frame
        elapsedTime += Time.deltaTime;
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);
            timerText.text = $"Time: {minutes:00}:{seconds:00}";
        }
    }

    // -------- Torch Upgrade --------
    public void UpgradeTorch()
    {
        int woodCost = baseWoodCost * torchLevel;
        int stoneCost = baseStoneCost * torchLevel;

        if (playerResources.wood >= woodCost && playerResources.stone >= stoneCost)
        {
            playerResources.wood -= woodCost;
            playerResources.stone -= stoneCost;
            torchLevel++;

            if (playerTorch != null)
                playerTorch.pointLightOuterRadius += torchRadiusIncrease;

            UpdateUI();
            Debug.Log($"Torch upgraded to level {torchLevel}");
        }
        else
        {
            Debug.Log("Not enough resources to upgrade torch");
        }
    }

    // -------- Crashpod Upgrade + Biome Change --------
    public void UpgradePodLight()
    {
        int woodCost = baseWoodCost * podLevel;
        int stoneCost = baseStoneCost * podLevel;

        if (playerResources.wood >= woodCost && playerResources.stone >= stoneCost)
        {
            playerResources.wood -= woodCost;
            playerResources.stone -= stoneCost;
            podLevel++;

            if (crashpod != null)
                crashpod.UpgradeLight(podLightIncrease);

            // Swap biome when podLevel hits certain thresholds
            if (biomeManager != null)
                biomeManager.UpdateBiomeByLevel(podLevel);

            UpdateUI();
            Debug.Log($"Crashpod upgraded to level {podLevel}");
        }
        else
        {
            Debug.Log("Not enough resources to upgrade Crashpod");
        }
    }

    // -------- Speed Upgrade --------
    public void UpgradeSpeed()
    {
        if (playerResources.wood >= speedCostWood && playerResources.stone >= speedCostStone)
        {
            playerResources.wood -= speedCostWood;
            playerResources.stone -= speedCostStone;
            playerMovement.IncreaseSpeed(speedIncrease);
            UpdateUI();
        }
        else
        {
            Debug.Log("Not enough resources for speed upgrade!");
        }
    }

    // -------- UI Update --------
    void UpdateUI()
    {
        if (torchCostText != null)
            torchCostText.text = $"Cost: {baseWoodCost * torchLevel} Wood, {baseStoneCost * torchLevel} Stone";

        if (podCostText != null)
            podCostText.text = $"Cost: {baseWoodCost * podLevel} Wood, {baseStoneCost * podLevel} Stone";

        if (speedCostText != null)
            speedCostText.text = $"Cost: {speedCostWood} Wood, {speedCostStone} Stone";
    }
}
