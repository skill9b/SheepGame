using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesMenuController : MonoBehaviour
{

    ////////////////////////////////////////// Public GAME OBJECTS /////////////////
    
    // UI elements to update
    public Text playerWool;
    public Text currentWoolCost;
    public Image descriptionBox;

    // Panels
    public GameObject WeaponsPanel;
    public GameObject SupportPanel;

    // Progress Bar Sprites
    public Sprite oneIncrementEmpty;
    public Sprite oneIncrementFull;
    public Sprite twoIncrementEmpty;
    public Sprite twoIncrementHalf;
    public Sprite twoIncrementFull;
    public Sprite threeIncrementEmpty;
    public Sprite threeIncrementOne;
    public Sprite threeIncrementTwo;
    public Sprite threeIncrementFull;

    // Progress Bar UI Elements - Weapons
    public Image K9DamageBar;
    public Image K9CooldownBar;
    public Image ShearikenDamageBar;
    public Image ShearikenAcurracyBar;
    public Image OldMacdonaldAoeBar;
    public Image OldMacdonaldCooldownBar;

    // Progress Bar UI Elements - Support
    public Image BaseHealthBar;
    public Image BaseRepairBar;
    public Image WolfBlowingPowerBar;
    public Image WolfCooldownBar;
    public Image HumptyFireRateBar;
    public Image HumptySuicideBar;    

    // Weapon Descriptions
    public Sprite K9DamageDescription;
    public Sprite K9CooldownDescription;
    public Sprite ShearikenDamageDescription;
    public Sprite ShearikenAcurracyDescription;
    public Sprite OldMacdonaldAoeDescription;
    public Sprite OldMacdonaldCooldownDescription;

    // Support Descriptions
    public Sprite BaseHealthDescription;
    public Sprite BaseRepairDescription;
    public Sprite WolfBlowingPowerDescription;
    public Sprite WolfCooldownDescription;
    public Sprite HumptyFireRateDescription;
    public Sprite HumptySuicideDescription;    

    // Weapon Costs
    // int[] K9DamageCosts = new int[] { 100, 200 };
    // int[] K9CooldownCosts = new int[] { 100, 200 };
    int[] ShearikenDamageCosts = new int[] { 100, 200 };
    int[] ShearikenAccuracyCosts = new int[] { 150, 200 };
    int[] OldMacdonaldAoeCosts = new int[] { 100, 200 };
    int[] OldMacdonaldCooldownCosts = new int[] { 100, 200 };

    // Support Costs
    int[] HumptyFireRateCosts = new int[] { 100, 200 };
    int HumptySuicideCost = 300;
    int[] WolfBlowingPowerCost = new int[] { 100, 200 };
    int[] WolfCooldownCost = new int[] { 100, 200 };
    int BaseRegenCost = 200;
    int BaseHealthIncreaseCost = 200;

   
    ////////////////////////////////////////// FUNCTIONS /////////////////

    void Update()
    {
        // Show current wool points
        playerWool.text = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().woolCount.ToString();

        // Set Weapons K9 Damage as default option when upgrades menu first appears
        // currentWoolCost.text = K9DamageCosts[0];
        descriptionBox.sprite = K9DamageDescription;

        DisplayAllCurrentProgressBars();
    }

    public void ShowWeaponsPanel()
    {
        WeaponsPanel.SetActive(true);
        SupportPanel.SetActive(false);
    }

    public void ShowSupportPanel()
    {
        WeaponsPanel.SetActive(false);
        SupportPanel.SetActive(true);
    }

    void DisplayAllCurrentProgressBars()   // Sets all current progress bars
    {
        // Humpty Dumpty Fire Rate
        if (GameObject.FindGameObjectWithTag("HumptyDumpty").GetComponent<NPCHumptyDumptyController>().eggCountdown == 1.0f)
        {
            HumptyFireRateBar.sprite = twoIncrementEmpty;
        }
        else if (GameObject.FindGameObjectWithTag("HumptyDumpty").GetComponent<NPCHumptyDumptyController>().eggCountdown == 1.5f)
        {
            HumptyFireRateBar.sprite = twoIncrementHalf;
        }
        else if (GameObject.FindGameObjectWithTag("HumptyDumpty").GetComponent<NPCHumptyDumptyController>().eggCountdown == 2.0f)
        {
            HumptyFireRateBar.sprite = twoIncrementFull;
        }

        // Humpty Dumpty Suicide
        if (GameObject.FindGameObjectWithTag("HumptyDumpty").GetComponent<NPCHumptyDumptyController>().enableSuicide == false)
        {
            HumptySuicideBar.sprite = oneIncrementEmpty;
        }
        else
        {
            HumptySuicideBar.sprite = oneIncrementFull;
        }

        // Wolf Blowing Power

        if (GameObject.FindGameObjectWithTag("Wolf").GetComponent<BigBadWolfController>().blowingCountdown == 0.3f)
        {
            WolfBlowingPowerBar.sprite = twoIncrementEmpty;
        }
        else if (GameObject.FindGameObjectWithTag("Wolf").GetComponent<BigBadWolfController>().blowingCountdown == 0.4f)
        {
            WolfBlowingPowerBar.sprite = twoIncrementHalf;
        }
        else if (GameObject.FindGameObjectWithTag("Wolf").GetComponent<BigBadWolfController>().blowingCountdown == 0.6f)
        {
            WolfBlowingPowerBar.sprite = twoIncrementFull;
        }

        // Wolf Cooldown
        if (GameObject.FindGameObjectWithTag("Wolf").GetComponent<BigBadWolfController>().blowingCooldown == 11)
        {
            WolfCooldownBar.sprite = twoIncrementEmpty;
        }
        else if (GameObject.FindGameObjectWithTag("Wolf").GetComponent<BigBadWolfController>().blowingCooldown == 7.5)
        {
            WolfCooldownBar.sprite = twoIncrementHalf;
        }
        else if (GameObject.FindGameObjectWithTag("Wolf").GetComponent<BigBadWolfController>().blowingCooldown == 5.5)
        {
            WolfCooldownBar.sprite = twoIncrementFull;
        }

        // Base Regen
        if (GameObject.FindGameObjectWithTag("Base").GetComponent<BaseController>().healthRegenActive == true)
        {
            BaseRepairBar.sprite = oneIncrementEmpty;
        }
        else
        {
            BaseRepairBar.sprite = oneIncrementFull;
        }

        // Base Health Increase
        if (GameObject.FindGameObjectWithTag("Base").GetComponent<BaseController>().maxHealth == 10)
        {
            BaseHealthBar.sprite = threeIncrementEmpty;
        }
        else if (GameObject.FindGameObjectWithTag("Base").GetComponent<BaseController>().maxHealth == 15)
        {
            BaseRepairBar.sprite = threeIncrementOne;
        }
        else if (GameObject.FindGameObjectWithTag("Base").GetComponent<BaseController>().maxHealth == 20)
        {
            BaseRepairBar.sprite = threeIncrementTwo;
        }
        else if (GameObject.FindGameObjectWithTag("Base").GetComponent<BaseController>().maxHealth == 25)
        {

    }

    /////////////////////// Set Description sprite functions 

    void SetK9DamageDescription()
    {
        descriptionBox.sprite = K9DamageDescription;
    }

    void SetK9CooldownDescription()
    {
        descriptionBox.sprite = K9CooldownDescription;
    }

    void SetShearikenDamageDescription()
    {
        descriptionBox.sprite = ShearikenDamageDescription;
    }

    void SetShearikenAcurracyDescription()
    {
        descriptionBox.sprite = ShearikenAcurracyDescription;
    }

    void SetOldMacdonaldAoeDescription()
    {
        descriptionBox.sprite = OldMacdonaldAoeDescription;
    }

    void SetOldMacdonaldCooldownDescription()
    {
        descriptionBox.sprite = OldMacdonaldCooldownDescription;
    }

    void SetBaseHealthDescription()
    {
        descriptionBox.sprite = BaseHealthDescription;
    }
    void SetWolfBlowingPowerDescription()
    {
        descriptionBox.sprite = WolfBlowingPowerDescription;
    }
    void SetWolfCooldownDescription()
    {
        descriptionBox.sprite = WolfCooldownDescription;
    }

    void SetHumptyFireRateDescription()
    {
        descriptionBox.sprite = HumptyFireRateDescription;
    }
    void SetHumptySuicideDescription()
    {
        descriptionBox.sprite = HumptySuicideDescription;
    }

    /////////////////////// Set new stat functions
    public void SetHumptyDumptyFireRate()
    {
        NPCHumptyDumptyController humptyDumpty = GameObject.FindGameObjectWithTag("HumptyDumpty").GetComponent<NPCHumptyDumptyController>();
        humptyDumpty.eggCountdown -= 0.5f;

        if (humptyDumpty.eggCountdown == 1.0)
        {

        }
    }

    public void EnableHumptyDumptySuicide()
    {
        GameObject.FindGameObjectWithTag("HumptyDumpty").GetComponent<NPCHumptyDumptyController>();
    }
}
