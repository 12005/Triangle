using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRatePlus: MonoBehaviour
{
    public Player player;
    public LevelUpMenu levelUpMenu;

    private void Start()
    {
        player = GameObject.FindAnyObjectByType<Player>();
        levelUpMenu = GameObject.FindAnyObjectByType<LevelUpMenu>();    
    }

    public void fireRate() {
        player.CurrentWeapon.Firerate += player.CurrentWeapon.Firerate * 5 / 100;
        Debug.Log(transform.parent.name);
        levelUpMenu.pickedAbility(int.Parse(transform.parent.name));
    }
}
