using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class HealthManage : MonoBehaviour
{
    public Slider Slider;
    public ParticleSystem healEffect;

    public float MaxHealth;

    public void setMaxHealth(float maxHealth)
    {
        Slider.maxValue = maxHealth;
        Slider.value = maxHealth;
    }

    public void setHealth(float health)
    {
        Slider.value = health;
        healEffect.Play();
    }
}
