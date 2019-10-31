using UnityEngine;

public class BaseController : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public float healthRegenAmount;
    public bool healthRegenActive;
    public float timeTillRegen;
    float nextRegenTime;

    enum State
    {
        Moving,
        Attacking,
        Idle
    };


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 50;
        // currentHealth = maxHealth;
        healthRegenActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.FindGameObjectWithTag("HealthBar").GetComponent<SimpleHealthBar>().UpdateBar(currentHealth, maxHealth);

        if (healthRegenActive)
        {
            if (Time.time > nextRegenTime)
            {
                currentHealth += healthRegenAmount;
                nextRegenTime = Time.time + timeTillRegen;
            }
        }


       // if (Time.time > nextAttackTime)
       // {
       //     baseController.currentHealth -= attackDamage;
       //     Debug.Log(baseController.currentHealth);
       //     nextAttackTime = Time.time + attackSpeed;
       // 

        // Debug.Log("currentHealth:" + currentHealth);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<ParentSheepController>().currentState = (ParentSheepController.State)State.Attacking;
            
        }

        
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy") 
        {
            other.GetComponent<ParentSheepController>().currentState = (ParentSheepController.State)State.Attacking;
        }
    }
}
