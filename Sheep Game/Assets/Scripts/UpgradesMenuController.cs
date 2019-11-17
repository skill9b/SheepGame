using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesMenuController : MonoBehaviour
{

    ////////////////////////////////////////// Public GAME OBJECTS /////////////////

    // Player variables
    int playerCurrentWool;
    float currentWoolCost;
    Sprite currentDescription;

    // UI elements to update
    public Text playerWoolDisplay;
    public Text currentWoolCostDisplay;
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
    public Image ShearikenAccuracyBar;
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
    public Sprite ShearikenAccuracyDescription;
    public Sprite OldMacdonaldAoeDescription;
    public Sprite OldMacdonaldCooldownDescription;

    // Support Descriptions
    public Sprite BaseHealthDescription;
    public Sprite BaseRepairDescription;
    public Sprite WolfBlowingPowerDescription;
    public Sprite WolfCooldownDescription;
    public Sprite HumptyFireRateDescription;
    public Sprite HumptySuicideDescription;


    ////////////////////////////////////////// FUNCTIONS /////////////////

    private void Start()
    {
        // Display initial values for player wool, K9 Damage description and K9 damage cost
        playerCurrentWool = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().woolCount;
        playerWoolDisplay.text = playerCurrentWool.ToString();

        currentWoolCost = GetK9CurrentDamage();
        currentWoolCostDisplay.text = currentWoolCost.ToString();

        currentDescription = K9DamageDescription;
        descriptionBox.sprite = currentDescription;
    }

    void Update()
    {
        // Display current description & woolcost

        // Set current wool points
        playerCurrentWool = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().woolCount;
        playerWoolDisplay.text = playerCurrentWool.ToString();

        // Set Weapons K9 Damage as default option when upgrades menu first appears
        // currentWoolCostDisplay.text = K9DamageCosts[0];
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
            BaseHealthBar.sprite = threeIncrementOne;
        }
        else if (GameObject.FindGameObjectWithTag("Base").GetComponent<BaseController>().maxHealth == 20)
        {
            BaseHealthBar.sprite = threeIncrementTwo;
        }
        else if (GameObject.FindGameObjectWithTag("Base").GetComponent<BaseController>().maxHealth == 25)
        {
            BaseHealthBar.sprite = threeIncrementFull;
        }

        // K9 [ARCGUN]

        // K9 Damage Increase 
        //if (GameObject.FindGameObjectWithTag("K9Bullet").GetComponent<ArcBulletController>().damage == 10)
        //{
        //    K9DamageBar.sprite = twoIncrementEmpty;
        //}
        //else if (GameObject.FindGameObjectWithTag("K9Bullet").GetComponent<ArcBulletController>().maxHealth == 15)
        //{
        //    K9DamageBar.sprite = twoIncrementHalf;
        //}
        //else if (GameObject.FindGameObjectWithTag("K9Bullet").GetComponent<ArcBulletController>().maxHealth == 20)
        //{
        //    K9DamageBar.sprite = twoIncrementFull;
        //}

        // K9 Cooldown Increase 
        //if (GameObject.FindGameObjectWithTag("ArcGun").GetComponent<ArcBulletController>().cooldowntime ?? == 10)
        //{
        //    K9CooldownBar.sprite = twoIncrementEmpty;
        //}
        //else if (GameObject.FindGameObjectWithTag("ArcGun").GetComponent<BaseController>().maxHealth == 15)
        //{
        //    K9CooldownBar.sprite = twoIncrementHalf;
        //}
        //else if (GameObject.FindGameObjectWithTag("ArcGun").GetComponent<BaseController>().maxHealth == 20)
        //{
        //    K9CooldownBar.sprite = twoIncrementFull;
        //}

        // Sheariken [LONGGUN]

        //if (GameObject.FindGameObjectWithTag("LongBullet").GetComponent<LongBulletController>().damage == 1)
        //{
        //    ShearikenDamageBar.sprite = twoIncrementEmpty;
        //}
        //else if (GameObject.FindGameObjectWithTag("LongBullet").GetComponent<LongBulletController>().damage == 15)
        //{
        //    ShearikenDamageBar.sprite = twoIncrementHalf;
        //}
        //else if (GameObject.FindGameObjectWithTag("LongBullet").GetComponent<LongBulletController>().damage == 20)
        //{
        //    ShearikenDamageBar.sprite = twoIncrementFull;
        //}

        if (GameObject.FindGameObjectWithTag("LongBullet").GetComponent<LongBulletController>().PassEnemies == 1)
        {
            ShearikenAccuracyBar.sprite = twoIncrementEmpty;
        }
        else if (GameObject.FindGameObjectWithTag("LongBullet").GetComponent<LongBulletController>().PassEnemies == 2)
        {
            ShearikenAccuracyBar.sprite = twoIncrementHalf;
        }
        else if (GameObject.FindGameObjectWithTag("LongBullet").GetComponent<LongBulletController>().PassEnemies == 3)
        {
            ShearikenAccuracyBar.sprite = twoIncrementFull;
        }

        // Old Macdonald [SHOTGUN]
        if (GameObject.FindGameObjectWithTag("Shotgun").GetComponent<ShortController>().CooldowntimeNotFull == 3.0f)
        {
            OldMacdonaldCooldownBar.sprite = twoIncrementEmpty;
        }
        else if (GameObject.FindGameObjectWithTag("Shotgun").GetComponent<ShortController>().CooldowntimeNotFull == 2.5f)
        {
            OldMacdonaldCooldownBar.sprite = twoIncrementHalf;
        }
        else if (GameObject.FindGameObjectWithTag("Shotgun").GetComponent<ShortController>().CooldowntimeNotFull == 2.0f)
        {
            OldMacdonaldCooldownBar.sprite = twoIncrementFull;
        }

        //if (GameObject.FindGameObjectWithTag("ShortBullet").transform.localScale.y == 2.5f)
        //{
        //    OldMacdonaldAoeBar.sprite = twoIncrementEmpty;
        //}
        //else if (GameObject.FindGameObjectWithTag("ShortBullet").transform.localScale.y == 3.5f)
        //{
        //    OldMacdonaldAoeBar.sprite = twoIncrementHalf;
        //}
        //else if (GameObject.FindGameObjectWithTag("ShortBullet").transform.localScale.y == 4.5f)
        //{
        //    OldMacdonaldAoeBar.sprite = twoIncrementFull;
        //}

    }

    /////////////////////// Get Description sprite functions 
    
    float GetK9CurrentDamage()
    {
        return GameObject.FindGameObjectWithTag("ArcGun").GetComponent<ArcBulletController>().Damage;
    }

    float GetK9CurrentCooldown()
    {
        return GameObject.FindGameObjectWithTag("ArcGun").GetComponent<ArcController>().CooldowntimeNotFull;
    }

    float GetShearikenDamage()
    {
        return GameObject.FindGameObjectWithTag("LongGun").GetComponent<LongController>().Damage;
    }

    float GetShearikenAccuracy()
    {
        return GameObject.FindGameObjectWithTag("LongGun").GetComponent<LongController>().Damage;
    }


    //    // Progress Bar UI Elements - Weapons
    //public Image ShearikenDamageBar;
    //public Image ShearikenAccuracyBar;
    //public Image OldMacdonaldAoeBar;
    //public Image OldMacdonaldCooldownBar;

    //// Progress Bar UI Elements - Support
    //public Image BaseHealthBar;
    //public Image BaseRepairBar;
    //public Image WolfBlowingPowerBar;
    //public Image WolfCooldownBar;
    //public Image HumptyFireRateBar;
    //public Image HumptySuicideBar;

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
        descriptionBox.sprite = ShearikenAccuracyDescription;
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
    public void SetHumptyDumptyFireRate()   // Purchase 
    {
        NPCHumptyDumptyController humptyDumpty = GameObject.FindGameObjectWithTag("HumptyDumpty").GetComponent<NPCHumptyDumptyController>();
        int currentWoolCost = 0;

        if (humptyDumpty.eggCountdown == 2.0)
        {
            currentWoolCost = 100;
        }
        else if (humptyDumpty.eggCountdown == 1.5)
        {
            currentWoolCost = 200;
        }

        if ( currentWoolCost <= playerCurrentWool)
        {
            humptyDumpty.eggCountdown -= 0.5f;
            playerCurrentWool -= currentWoolCost;
        }
    }


    ////////////// Weapon Costs
    // int[] K9DamageCosts = new int[] { 100, 200 };
    // int[] K9CooldownCosts = new int[] { 100, 200 };
    //int[] ShearikenDamageCosts = new int[] { 100, 200 };
    //int[] ShearikenAccuracyCosts = new int[] { 150, 200 };
    //int[] OldMacdonaldAoeCosts = new int[] { 100, 200 };
    //int[] OldMacdonaldCooldownCosts = new int[] { 100, 200 };

    ////////////// Support Costs
    //int[] HumptyFireRateCosts = new int[] { 100, 200 };
    //int HumptySuicideCost = 300;
    //int[] WolfBlowingPowerCost = new int[] { 100, 200 };
    //int[] WolfCooldownCost = new int[] { 100, 200 };
    //int BaseRegenCost = 200;
    //int BaseHealthIncreaseCost = 200;

    public void EnableHumptyDumptySuicide()
    {
        GameObject.FindGameObjectWithTag("HumptyDumpty").GetComponent<NPCHumptyDumptyController>();
    }
}
