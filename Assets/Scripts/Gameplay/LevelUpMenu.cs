using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpMenu : MonoBehaviour
{
    public List<GameObject> abilities;
    public List<GameObject> abilitiesDisplayed;
    public List<GameObject> currentAbilities;
    public GameObject[] displaySlots;
    public GameObject levelUpPanel;
    GameObject a, b, c;


    public void pickAbility() {
        Time.timeScale = 0f;
        System.Random random = new System.Random();

        for (int i = 0; i < 3; i++)
        {
            int randomIndex = random.Next(0, abilities.Count);
            abilitiesDisplayed.Add(abilities[randomIndex]);
            abilities.RemoveAt(randomIndex);
        }
        a = Instantiate(abilitiesDisplayed[0]);
        a.transform.SetParent(displaySlots[0].transform, false);
        b = Instantiate(abilitiesDisplayed[1]);
        b.transform.SetParent(displaySlots[1].transform, false);
        c = Instantiate(abilitiesDisplayed[2]);
        c.transform.SetParent(displaySlots[2].transform, false);

        levelUpPanel.SetActive(true);
    }

    public void pickedAbility(int picked){
        levelUpPanel.SetActive(false);
        Destroy(a);
        Destroy(b);
        Destroy(c);
        currentAbilities.Add(abilitiesDisplayed[picked]);
        abilitiesDisplayed.RemoveAt(picked);
        for(int i = 0; i < 2; i++)
        {
            abilities.Add(abilitiesDisplayed[0]);
            abilitiesDisplayed.RemoveAt(0);
        }
        Time.timeScale = 1f;
    }
}
