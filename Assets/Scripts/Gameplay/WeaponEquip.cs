using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponEquip : MonoBehaviour
{
    public string WeaponName;
    public TextMeshProUGUI EquipText;

    void Awake()
    {
        EquipText = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
        if (PlayerPrefs.GetString("WeaponName") == WeaponName)
            EquipText.text = "Equiped";
        else
            EquipText.text = "Equip";

    }
   
    public void Equip()
    {
        PlayerPrefs.SetString("WeaponName", WeaponName);
    }


}
