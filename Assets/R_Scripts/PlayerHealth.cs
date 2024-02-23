using System;
using System.Collections;
using System.Collections.Generic;
using CodeMonkey.HealthSystemCM;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IGetHealthSystem
{
    private HealthSystem playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth= new HealthSystem(100);

        playerHealth.OnDead+=PlayerHealth_OnDead;
        
    }

    private void PlayerHealth_OnDead(object sender, EventArgs e)
    {
        Debug.Log("Player Died");
    }

    public void Damage(float damage)
    {
        playerHealth.Damage(damage);
    }

    public void Heal(float heal)
    {
        playerHealth.Heal(heal);
    }

    

    public HealthSystem GetHealthSystem()
    {
       return playerHealth;
    }

    
}
