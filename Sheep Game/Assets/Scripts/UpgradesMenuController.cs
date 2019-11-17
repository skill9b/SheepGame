using System.Collections;
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

    // Set enum for Current Upgrade
    public enum CurrentUpgrade
    {
        K9_DAMAGE,
        K9_COOLDOWN,
        SHEARIKEN_DAMAGE,
        SHEARIKEN_ACCURACY,
        OLDMACDONALD_AOE,
        OLDMACDONALD_COOLDOWN,
        BASE_MAXHEALTH,
        BASE_REGEN,
        WOLF_BLOWINGPOWER,
        WOLF_COOLDOWN,
        HUMPTY_FIRERATE,
        HUMPTY_SUICIDE
    }
    CurrentUpgrade currentUpgrade;

    ////////////////////////////////////////// FUNCTIONS /////////////////

    private void Start()
    {
        // Display initial values for player wool, K9 Damage description and K9 damage cost
        playerCurrentWool = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().woolCount;
        playerWoolDisplay.text = playerCurrentWool.ToString();

        SetK9DamageDescription(); // sets description and current woolcost to be K9 as default
        descriptionBox.sprite = currentDescription;
        currentWoolCostDisplay.text = currentWoolCost.ToString();
        currentUpgrade = CurrentUpgrade.K9_DAMAGE;
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

    public void PurchaseUpgrade()
    {
        switch (currentUpgrade)
        {
            case CurrentUpgrade.K9_DAMAGE:
                PurchaseK9Damage();
                break;
            case CurrentUpgrade.K9_COOLDOWN:
                PurchaseK9Cooldown();
                break;
            case CurrentUpgrade.SHEARIKEN_ACCURACY:
                PurchaseShearikenAccuracy();
                break;
            case CurrentUpgrade.SHEARIKEN_DAMAGE:
                PurchaseShearikenDamage();
                break;
            case CurrentUpgrade.OLDMACDONALD_AOE:
                PurchaseOldMacdonaldAoE();
                break;
            case CurrentUpgrade.OLDMACDONALD_COOLDOWN:
                PurchaseOldMacdonaldCooldown();
                break;
            case CurrentUpgrade.WOLF_BLOWINGPOWER:
                PurchaseWolfBlowingPower();
                break;
            case CurrentUpgrade.WOLF_COOLDOWN:
                PurchaseWolfCooldown();
                break;
            case CurrentUpgrade.HUMPTY_FIRERATE:
                PurchaseHumptyDumptyFireRate();
                break;
            case CurrentUpgrade.HUMPTY_SUICIDE:
                PurchaseHumptyDumptySuicide();
                break;
            case CurrentUpgrade.BASE_MAXHEALTH:
                PurchaseBaseHealth();
                break;
            case CurrentUpgrade.BASE_REGEN:
                PurchaseBaseRegen();
                break;
        }
    }


    /////////////////////// Sets and displays all current progress bars (ON UPDATE)
    void DisplayAllCurrentProgressBars()  
    {
        // Humpty Dumpty Fire Rate
        if (GameObject.FindGameObjectWithTag("HumptyDumpty").GetComponent<NPCHumptyDumptyController>().eggCountdown == 2.0f)
        {
            HumptyFireRateBar.sprite = twoIncrementEmpty;
        }
        else if (GameObject.FindGameObjectWithTag("HumptyDumpty").GetComponent<NPCHumptyDumptyController>().eggCountdown == 1.5f)
        {
            HumptyFireRateBar.sprite = twoIncrementHalf;
        }
        else if (GameObject.FindGameObjectWithTag("HumptyDumpty").GetComponent<NPCHumptyDumptyController>().eggCountdown == 1.0f)
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
        if (GameObject.FindGameObjectWithTag("LongGun").GetComponent<LongController>().PassEnemies == 1)
        {
            ShearikenAccuracyBar.sprite = twoIncrementEmpty;
        }
        else if (GameObject.FindGameObjectWithTag("LongGun").GetComponent<LongController>().PassEnemies == 2)
        {
            ShearikenAccuracyBar.sprite = twoIncrementHalf;
        }
        else if (GameObject.FindGameObjectWithTag("LongGun").GetComponent<LongController>().PassEnemies == 3)
        {
            ShearikenAccuracyBar.sprite = twoIncrementFull;
        }

        // Old Macdonald [SHOTGUN]
        // Old MacDonald Cooldown
        if (GameObject.FindGameObjectWithTag("Shotgun").GetComponent<ShortController>().CooldowntimeFull == 3.0f)
        {
            OldMacdonaldCooldownBar.sprite = twoIncrementEmpty;
        }
        else if (GameObject.FindGameObjectWithTag("Shotgun").GetComponent<ShortController>().CooldowntimeFull == 2.5f)
        {
            OldMacdonaldCooldownBar.sprite = twoIncrementHalf;
        }
        else if (GameObject.FindGameObjectWithTag("Shotgun").GetComponent<ShortController>().CooldowntimeFull == 2.0f)
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
        return GameObject.FindGameObjectWithTag("ArcGun").GetComponent<ArcController>().CooldowntimeFull;
    }

    float GetShearikenDamage()
    {
        return GameObject.FindGameObjectWithTag("LongGun").GetComponent<LongController>().Damage;
    }

    int GetShearikenAccuracy()
    {
        return GameObject.FindGameObjectWithTag("LongGun").GetComponent<LongController>().PassEnemies;
    }

    float GetOldMacdonaldAngle()
    {
        return GameObject.FindGameObjectWithTag("ShotGun").GetComponent<ShortController>().YScale;
    }

    float GetOldMacdonaldCooldown()
    {
        return GameObject.FindGameObjectWithTag("ShotGun").GetComponent<ShortController>().CooldowntimeFull;
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

    public void SetK9DamageDescription()
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

        currentDescription = K9DamageDescription;

        currentUpgrade = CurrentUpgrade.K9_DAMAGE;
    }

    public void SetK9CooldownDescription()
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

        currentDescription = K9CooldownDescription;

        currentUpgrade = CurrentUpgrade.K9_COOLDOWN;
    }

    public void SetShearikenDamageDescription()
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

        currentDescription = ShearikenDamageDescription;

        currentUpgrade = CurrentUpgrade.SHEARIKEN_DAMAGE;
    }

    public void SetShearikenAcurracyDescription()
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

        currentDescription = ShearikenAccuracyDescription;

        currentUpgrade = CurrentUpgrade.SHEARIKEN_ACCURACY;
    }

    public void SetOldMacdonaldAoeDescription()
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

        currentDescription = OldMacdonaldAoeDescription;

        currentUpgrade = CurrentUpgrade.OLDMACDONALD_AOE;
    }

    public void SetOldMacdonaldCooldownDescription()
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

        currentDescription = OldMacdonaldCooldownDescription;

        currentUpgrade = CurrentUpgrade.OLDMACDONALD_COOLDOWN;
    }

    public void SetBaseHealthDescription()
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

        currentDescription = BaseHealthDescription;

        currentUpgrade = CurrentUpgrade.BASE_MAXHEALTH;
    }

    public void SetBaseRegenDescription()
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

        currentDescription = BaseRepairDescription;

        currentUpgrade = CurrentUpgrade.BASE_REGEN;
    }

    public void SetWolfBlowingPowerDescription()
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

        currentDescription = WolfBlowingPowerDescription;

        currentUpgrade = CurrentUpgrade.WOLF_BLOWINGPOWER;
    }
    public void SetWolfCooldownDescription()
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

        currentDescription = WolfCooldownDescription;

        currentUpgrade = CurrentUpgrade.WOLF_COOLDOWN;
    }

    public void SetHumptyFireRateDescription()
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

        currentDescription = HumptyFireRateDescription;

        currentUpgrade = CurrentUpgrade.HUMPTY_FIRERATE;
    }

    public void SetHumptySuicideDescription()
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

        currentDescription = HumptySuicideDescription;

        currentUpgrade = CurrentUpgrade.HUMPTY_SUICIDE;
    }


    /////////////////////// Set new stat functions 
  
    void PurchaseHumptyDumptyFireRate()   // Purchase 
    {
        if ((currentWoolCost <= playerCurrentWool) && (currentWoolCost != -1))
        {
            NPCHumptyDumptyController humptyDumpty = GameObject.FindGameObjectWithTag("HumptyDumpty").GetComponent<NPCHumptyDumptyController>();
            switch (humptyDumpty.eggCountdown)
            {
                case 2.0f:
                    humptyDumpty.eggCountdown = 1.5f;
                    break;
                case 1.5f:
                    humptyDumpty.eggCountdown = 1.0f;
                    break;
                case 1.0f:
                    break;
            }
            playerCurrentWool -= currentWoolCost;
        }
    }

    void PurchaseHumptyDumptySuicide()
    {
        if ((currentWoolCost <= playerCurrentWool) && (currentWoolCost != -1))
        {
            NPCHumptyDumptyController humptyDumpty = GameObject.FindGameObjectWithTag("HumptyDumpty").GetComponent<NPCHumptyDumptyController>();
            humptyDumpty.enableSuicide = !humptyDumpty.enableSuicide; 
            playerCurrentWool -= currentWoolCost;
        }
    }

    void PurchaseWolfBlowingPower()
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

    void PurchaseWolfCooldown()
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
                case 5.5f:
                    break;
            }

            playerCurrentWool -= currentWoolCost;
        }
    }

    void PurchaseBaseRegen()
    {
        if ((currentWoolCost <= playerCurrentWool) && (currentWoolCost != -1))
        {
            BaseController baseObject = GameObject.FindGameObjectWithTag("Base").GetComponent<BaseController>();

            baseObject.healthRegenActive = !baseObject.healthRegenActive;

            playerCurrentWool -= currentWoolCost;
        }
    }

    void PurchaseBaseHealth()
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

    void PurchaseK9Damage()
    {
        //if ((currentWoolCost <= playerCurrentWool) && (currentWoolCost != -1))
        //{
        //    BaseController baseObject = GameObject.FindGameObjectWithTag("Base").GetComponent<BaseController>();

        //    switch (baseObject.maxHealth)
        //    {
        //        case 10:
        //            baseObject.maxHealth = 10;
        //            break;
        //        case 15:
        //            baseObject.maxHealth = 20;
        //            break;
        //        case 20:
        //            baseObject.maxHealth = 25;
        //            break;
        //        case 25:
        //            break;
        //    }

        //    playerCurrentWool -= currentWoolCost;
        //}
    }

    void PurchaseK9Cooldown()
    {
        //if ((currentWoolCost <= playerCurrentWool) && (currentWoolCost != -1))
        //{
        //    BaseController baseObject = GameObject.FindGameObjectWithTag("Base").GetComponent<BaseController>();

        //    switch (baseObject.cooldown)
        //    {
        //        case 10:
        //            baseObject.maxHealth = 10;
        //            break;
        //        case 15:
        //            baseObject.maxHealth = 20;
        //            break;
        //        case 20:
        //            baseObject.maxHealth = 25;
        //            break;
        //        case 25:
        //            break;
        //    }

        //    playerCurrentWool -= currentWoolCost;
        //}
    }

    void PurchaseShearikenDamage()
    {
        if ((currentWoolCost <= playerCurrentWool) && (currentWoolCost != -1))
        {
            LongController sheariken = GameObject.FindGameObjectWithTag("LongGun").GetComponent<LongController>();

            switch (sheariken.Damage)
            {
                case 1.0f:
                    sheariken.Damage = 1.5f;
                    break;
                case 1.5f:
                    sheariken.Damage = 2.0f;
                    break;
                case 2.0f:
                    break;
            }

            playerCurrentWool -= currentWoolCost;
        }
    }

    void PurchaseShearikenAccuracy()
    {
        if ((currentWoolCost <= playerCurrentWool) && (currentWoolCost != -1))
        {
            LongController sheariken = GameObject.FindGameObjectWithTag("LongGun").GetComponent<LongController>();

            switch (sheariken.PassEnemies)
            {
                case 1:
                    sheariken.PassEnemies = 2;
                    break;
                case 2:
                    sheariken.PassEnemies = 3;
                    break;
                case 3:
                    break;
            }

            playerCurrentWool -= currentWoolCost;
        }
    }

    void PurchaseOldMacdonaldAoE()
    {
        if ((currentWoolCost <= playerCurrentWool) && (currentWoolCost != -1))
        {
            ShortController oldMacdonald = GameObject.FindGameObjectWithTag("Shotgun").GetComponent<ShortController>();

            switch (oldMacdonald.YScale)
            {
                case 2.5f:
                    oldMacdonald.YScale = 3.5f;
                    break;
                case 3.5f:
                    oldMacdonald.YScale = 4.5f;
                    break;
                case 4.5f:
                    break;
            }

            playerCurrentWool -= currentWoolCost;
        }
    }

    void PurchaseOldMacdonaldCooldown()
    {
        if ((currentWoolCost <= playerCurrentWool) && (currentWoolCost != -1))
        {
            ShortController oldMacdonald = GameObject.FindGameObjectWithTag("Shotgun").GetComponent<ShortController>();

            switch (oldMacdonald.CooldowntimeFull)
            {
                case 3.0f:
                    oldMacdonald.CooldowntimeFull = 2.5f;
                    break;
                case 2.5f:
                    oldMacdonald.CooldowntimeFull = 2.0f;
                    break;
                case 2.0f:
                    break;
            }

            playerCurrentWool -= currentWoolCost;
        }
    }
}
