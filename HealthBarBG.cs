using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Image bgImage;   // The background image whose color will change
    public Color healthyColor = Color.green;
    public Color midColor = Color.yellow;
    public Color lowColor = Color.red;

    public void SetMaxHealth(float health)
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;
        UpdateBackgroundColor();
    }

    public void SetHealth(float health)
    {
        healthSlider.value = health;
        UpdateBackgroundColor();
    }

    void UpdateBackgroundColor()
    {
        float healthPercent = healthSlider.value / healthSlider.maxValue;

        if (healthPercent > 0.6f)
            bgImage.color = healthyColor;
        else if (healthPercent > 0.3f)
            bgImage.color = midColor;
        else
            bgImage.color = lowColor;
    }
}
