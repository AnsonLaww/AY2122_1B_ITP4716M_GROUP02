using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Slider Slider;
    public Gradient Gradient;
    public Image Fill;

    public void SetMaxMana(int mana)
    {
        Slider.maxValue = mana;
        Slider.value = mana;


        Fill.color = Gradient.Evaluate(1f);
    }

    public void SetMana(int mana)
    {
        Slider.value = mana;

        Fill.color = Gradient.Evaluate(Slider.normalizedValue);
    }
}
