using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Important!

public class InventoryUI : MonoBehaviour
{
    public PlayerResources playerResources;
    public TMP_Text woodText;   // TMP_Text, not Text
    public TMP_Text stoneText;

    void Update()
    {
        woodText.text = "Wood: " + playerResources.wood;
        stoneText.text = "Stone: " + playerResources.stone;
    }
}

