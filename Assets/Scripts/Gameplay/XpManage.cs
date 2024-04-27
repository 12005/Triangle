using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;

public class XpManage : MonoBehaviour
{
    public UnityEngine.UI.Slider slider;
    public TextMeshProUGUI LevelText;
    public Player player;

    void Awake()
    {
        slider.maxValue = player.xpMax;
        LevelText.text = player.level.ToString();
        slider.value = player.xp;
    }

    void Update()
    {
        slider.value = player.xp;
    }

    public void levelup() {
        LevelText.text = player.level.ToString();
        slider.maxValue = player.xpMax;
    }
}
