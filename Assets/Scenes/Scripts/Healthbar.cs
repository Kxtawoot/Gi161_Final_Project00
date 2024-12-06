using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider Slider;
    public void SetMaxHealth(int maxHealth)
    {
        Slider.maxValue = maxHealth;
        Slider.value = maxHealth;

    }
    public void SetMinHealth(int minHealth)
    {
        Slider.value = minHealth;

    }

}