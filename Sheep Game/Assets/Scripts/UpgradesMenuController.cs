﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesMenuController : MonoBehaviour
{

    ////////////////////////////////////////// Public GAME OBJECTS /////////////////

    // Player variables
    int playerCurrentWool;
    int currentWoolCost;
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

        // currentWoolCost = GetK9CurrentDamage();
        currentWoolCostDisplay.text = currentWoolCost.ToString();

        currentDescription = K9DamageDescription;
        descriptionBox.sprite = currentDescription;
    }

    void Update()
    {
        // Display current description & woolcost
        descriptionBox.sprite = currentDescription;
        if (currentWoolCost == -1)
        {
            currentWoolCostDisplay.text = "";
        }

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

    /////////////////////// Sets and displays all current progress bars (ON UPDATE)
    void DisplayAllCurrentProgressBars()  
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
        //if (GameObject.FindGameObjectWithTag("ArcGun").GetComponent<ArcBulletController>().Damage == 10)
        //{
        //    K9DamageBar.sprite = twoIncrementEmpty;
        //}
        //else if (GameObject.FindGameObjectWithTag("ArcGun").GetComponent<ArcBulletController>().Damage == 15)
        //{
        //    K9DamageBar.sprite = twoIncrementHalf;
        //}
        //else if (GameObject.FindGameObjectWithTag("ArcGun").GetComponent<ArcBulletController>().Damage == 20)
        //{
        //    K9DamageBar.sprite = twoIncrementFull;
        //}

        // K9 Cooldown Increase 
        //if (GameObject.FindGameObjectWithTag("ArcGun").GetComponent<ArcBulletController>().CooldowntimeNotFull == 10)
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
        // Sheariken Damage
        if (GameObject.FindGameObjectWithTag("LongGun").GetComponent<LongController>().Damage == 1.0f)
        {
            ShearikenDamageBar.sprite = twoIncrementEmpty;
        }
        else if (GameObject.FindGameObjectWithTag("LongGun").GetComponent<LongController>().Damage == 1.5f)
        {
            ShearikenDamageBar.sprite = twoIncrementHalf;
        }
        else if (GameObject.FindGameObjectWithTag("LongGun").GetComponent<LongController>().Damage == 2.0f)
        {
            ShearikenDamageBar.sprite = twoIncrementFull;
        }

        // Sheariken Accuracy
        if (GameObject.FindGameObjectWithTag("LongBullet").GetComponent<LongController>().PassEnemies == 1)
        {
            ShearikenAccuracyBar.sprite = twoIncrementEmpty;
        }
        else if (GameObject.FindGameObjectWithTag("LongBullet").GetComponent<LongController>().PassEnemies == 2)
        {
            ShearikenAccuracyBar.sprite = twoIncrementHalf;
        }
        else if (GameObject.FindGameObjectWithTag("LongBullet").GetComponent<LongController>().PassEnemies == 3)
        {
            ShearikenAccuracyBar.sprite = twoIncrementFull;
        }

        // Old Macdonald [SHOTGUN]
        // Old MacDonald Cooldown
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

        // Old MacDonald Angle
        if (GameObject.FindGameObjectWithTag("Shotgun").GetComponent<ShortController>().YScale == 2.5f)
        {
            OldMacdonaldAoeBar.sprite = twoIncrementEmpty;
        }
        else if (GameObject.FindGameObjectWithTag("Shotgun").GetComponent<ShortController>().YScale == 3.5f)
        {
            OldMacdonaldAoeBar.sprite = twoIncrementHalf;
        }
        else if (GameObject.FindGameObjectWithTag("Shotgun").GetComponent<ShortController>().YScale == 4.5f)
        {
            OldMacdonaldAoeBar.sprite = twoIncrementFull;
        }

    }

    /////////////////////// Get upgrade values 
    
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

    int GetShearikenAccuracy()
    {
        return GameObject.FindGameObjectWithTag("LongGun").GetComponent<LongController>().Damage;
    }

    float GetOldMacdonaldAngle()
    {
        return GameObject.FindGameObjectWithTag("ShotGun").GetComponent<ShortController>().YScale;
    }

    float GetOldMacdonaldCooldown()
    {
        return GameObject.FindGameObjectWithTag("ShotGun").GetComponent<ShortController>().CooldowntimeNotFull;
    }

    bool GetBaseRegen()
    {
        return GameObject.FindGameObjectWithTag("Base").GetComponent<BaseController>().healthRegenActive;
    }

    float GetBaseMaxHealth()
    {
        return GameObject.FindGameObjectWithTag("Base").GetComponent<BaseController>().maxHealth;
    }

    float GetWolfBlowingPower()
    {
        return GameObject.FindGameObjectWithTag("Wolf").GetComponent<BigBadWolfController>().blowingCountdown;
    }

    float GetWolfCooldown()
    {
        return GameObject.FindGameObjectWithTag("Wolf").GetComponent<BigBadWolfController>().blowingCooldown;
    }

    float GetHumptyFireRate()
    {
        return GameObject.FindGameObjectWithTag("HumptyDumpty").GetComponent<NPCHumptyDumptyController>().eggCountdown;
    }

    bool GetHumptySuicide()
    {
        return GameObject.FindGameObjectWithTag("HumptyDumpty").GetComponent<NPCHumptyDumptyController>().enableSuicide;
    }

    /////////////////////// Select/Set Description & textsprite functions (ON CLICK)

    void SetK9DamageDescription()
    {
        //float damage = GetK9CurrentDamage();

        //switch(damage)
        //{
        //    case 1.0f:
        //        currentWoolCost = 100;
        //        break;
        //    case 2.0f:
        //        currentWoolCost = 200;
        //        break;
        //    case 3.0f:
        //        currentWoolCost = -1;
        //        break;
        //}

        descriptionBox.sprite = K9DamageDescription;
    }

    void SetK9CooldownDescription()
    {
        //float cooldown = GetK9CurrentCooldown();

        //switch (cooldown)
        //{
        //    case 1.0f:
        //        currentWoolCost = 100;
        //        break;
        //    case 2.0f:
        //        currentWoolCost = 200;
        //        break;
        //    case 3.0f:
        //        currentWoolCost = -1;
        //        break;
        //}

        descriptionBox.sprite = K9CooldownDescription;
    }

    void SetShearikenDamageDescription()
    {
        float damage = GetShearikenDamage();

        switch (damage)
        {
            case 1.0f:
                currentWoolCost = 100;
                break;
            case 1.5f:
                currentWoolCost = 200;
                break;
            case 2.0f:
                currentWoolCost = -1;
                break;
        }

        descriptionBox.sprite = ShearikenDamageDescription;
    }

    void SetShearikenAcurracyDescription()
    {
        int accuracy = GetShearikenAccuracy();

        switch (accuracy)
        {
            case 1:
                currentWoolCost = 150;
                break;
            case 2:
                currentWoolCost = 200;
                break;
            case 3:
                currentWoolCost = -1;
                break;
        }

        descriptionBox.sprite = ShearikenAccuracyDescription;
    }

    void SetOldMacdonaldAoeDescription()
    {
        float angle = GetOldMacdonaldAngle();

        switch (angle)
        {
            case 2.5f:
                currentWoolCost = 150;
                break;
            case 3.5f:
                currentWoolCost = 200;
                break;
            case 4.5f:
                currentWoolCost = -1;
                break;
        }

        descriptionBox.sprite = OldMacdonaldAoeDescription;
    }

    void SetOldMacdonaldCooldownDescription()
    {
        float cooldown = GetOldMacdonaldCooldown();

        switch (cooldown)
        {
            case 3.0f:
                currentWoolCost = 150;
                break;
            case 2.5f:
                currentWoolCost = 200;
                break;
            case 2.0f:
                currentWoolCost = -1;
                break;
        }

        descriptionBox.sprite = OldMacdonaldCooldownDescription;
    }

    void SetBaseHealthDescription()
    {
        //float cooldown = GetBaseHealth();

        //switch (cooldown)
        //{
        //    case 3.0f:
        //        currentWoolCost = 150;
        //        break;
        //    case 2.5f:
        //        currentWoolCost = 200;
        //        break;
        //    case 2.0f:
        //        currentWoolCost = -1;
        //        break;
        //}

        descriptionBox.sprite = BaseHealthDescription;
    }

    void SetBaseRegenDescription()
    {
        bool isRegenActive = GetBaseRegen();

        if (!isRegenActive)
        {
            currentWoolCost = 300;
        }
        else
        {
            currentWoolCost = -1;
        }
    }

    void SetWolfBlowingPowerDescription()
    {
        float blowingPower = GetWolfBlowingPower();

        switch(blowingPower)
        {
            case 0.3f:
                currentWoolCost = 100;
                break;
            case 0.4f:
                currentWoolCost = 200;
                break;
            case 0.6f:
                currentWoolCost = -1;
                break;
        }

        descriptionBox.sprite = WolfBlowingPowerDescription;
    }
    void SetWolfCooldownDescription()
    {
        float cooldown = GetWolfCooldown();

        switch (cooldown)
        {
            case 11.0f:
                currentWoolCost = 100;
                break;
            case 2.5f:
                currentWoolCost = 200;
                break;
            case 5.5f:
                currentWoolCost = -1;
                break;
        }

        descriptionBox.sprite = WolfCooldownDescription;
    }

    void SetHumptyFireRateDescription()
    {
        float fireRate = GetHumptyFireRate();

        switch (fireRate)
        {
            case 2.0f:
                currentWoolCost = 100;
                break;
            case 1.5f:
                currentWoolCost = 200;
                break;
            case 1.0f:
                currentWoolCost = -1;
                break;
        }

        descriptionBox.sprite = HumptyFireRateDescription;
    }

    void SetHumptySuicideDescription()
    {
        bool isSuicide = GetHumptySuicide();

        if (!isSuicide)
        {
            currentWoolCost = 300;
        }
        else
        {
            currentWoolCost = -1;
        }

        descriptionBox.sprite = HumptySuicideDescription;
    }


    /////////////////////// Set new stat functions 
  

    public void PurchaseHumptyDumptyFireRate()   // Purchase 
    {
        if ((currentWoolCost <= playerCurrentWool) && (currentWoolCost != -1))
        {
            NPCHumptyDumptyController humptyDumpty = GameObject.FindGameObjectWithTag("HumptyDumpty").GetComponent<NPCHumptyDumptyController>();
            humptyDumpty.eggCountdown -= 0.5f;
            playerCurrentWool -= currentWoolCost;
        }
    }

    public void SetHumptyDumptySuicide()
    {
        if ((currentWoolCost <= playerCurrentWool) && (currentWoolCost != -1))
        {
            NPCHumptyDumptyController humptyDumpty = GameObject.FindGameObjectWithTag("HumptyDumpty").GetComponent<NPCHumptyDumptyController>();
            humptyDumpty.enableSuicide = !humptyDumpty.enableSuicide; 
            playerCurrentWool -= currentWoolCost;
        }
    }

    public void SetWolfBlowingPower()
    {
        if ((currentWoolCost <= playerCurrentWool) && (currentWoolCost != -1))
        {
            BigBadWolfController wolf = GameObject.FindGameObjectWithTag("Wolf").GetComponent<BigBadWolfController>();
            
            switch (wolf.blowingCountdown)
            {
                case 0.3f:
                    wolf.blowingCountdown = 0.4f;
                    break;
                case 0.4f:
                    wolf.blowingCountdown = 0.6f;
                    break;
                case 0.6f:
                    break;
            }

            playerCurrentWool -= currentWoolCost;
        }
    }

    public void PurchaseWolfCooldown()
    {
        if ((currentWoolCost <= playerCurrentWool) && (currentWoolCost != -1))
        {
            BigBadWolfController wolf = GameObject.FindGameObjectWithTag("Wolf").GetComponent<BigBadWolfController>();

            switch (wolf.blowingCountdown)
            {
                case 11.0f:
                    wolf.blowingCountdown = 7.5f;
                    break;
                case 7.5f:
                    wolf.blowingCountdown = 5.5f;
                    break;
                case 0.6f:
                    break;
            }

            playerCurrentWool -= currentWoolCost;
        }
    }

    public void PurchaseBaseRegen()
    {
        if ((currentWoolCost <= playerCurrentWool) && (currentWoolCost != -1))
        {
            BaseController baseObject = GameObject.FindGameObjectWithTag("Base").GetComponent<BaseController>();

            baseObject.healthRegenActive = !baseObject.healthRegenActive;

            playerCurrentWool -= currentWoolCost;
        }
    }

    public void PurchaseHealthIncrease()
    {
        if ((currentWoolCost <= playerCurrentWool) && (currentWoolCost != -1))
        {
            BaseController baseObject = GameObject.FindGameObjectWithTag("Base").GetComponent<BaseController>();

            switch (baseObject.maxHealth)
            {
                case 10:
                    baseObject.maxHealth = 10;
                    break;
                case 15:
                    baseObject.maxHealth = 20;
                    break;
                case 20:
                    baseObject.maxHealth = 25;
                    break;
                case 25:
                    break;
            }

            playerCurrentWool -= currentWoolCost;
        }
    }

    ////////////// Weapon Costs
    //int[] K9DamageCosts = new int[] { 100, 200 };
    //int[] K9CooldownCosts = new int[] { 100, 200 };
    //int[] ShearikenDamageCosts = new int[] { 100, 200 };
    //int[] ShearikenAccuracyCosts = new int[] { 150, 200 };
    //int[] OldMacdonaldAoeCosts = new int[] { 100, 200 };
    //int[] OldMacdonaldCooldownCosts = new int[] { 100, 200 };


    public void PurchaseHumptyDumptySuicide()
    {
        GameObject.FindGameObjectWithTag("HumptyDumpty").GetComponent<NPCHumptyDumptyController>();
    }
}
