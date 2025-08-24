using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    public Slider healthSlider;

    public void Setup(int max, int current)
    {
        healthSlider.maxValue = max;
        healthSlider.value = current;
        healthSlider.interactable = false; // Prevent mouse dragging
    }

    public void UpdateHealth(int current)
    {
        healthSlider.value = current;
    }
}
