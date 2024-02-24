using System;
using System.Collections;
using System.Collections.Generic;
using CodeMonkey.HealthSystemCM;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IGetHealthSystem
{
    private HealthSystem playerHealth;


    public Animator playerAnim;

    public PlayerController _playerController;
    public Shooter _shoot;

    public SlashEffect _slash;

    public bool isAlreadDead=false;


    // Start is called before the first frame update
    void Start()
    {
        playerHealth= new HealthSystem(100);

        playerHealth.OnDead+=PlayerHealth_OnDead;
        
    }

    private void PlayerHealth_OnDead(object sender, EventArgs e)
    {
        Debug.Log("Player Died");

        //this.transform.GetComponent<PlayerController>().onDeadPlayer();

        if(!isAlreadDead)
        {
            isAlreadDead=true;
            StartCoroutine("DestroyPlayer");
            
        }
        
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

   IEnumerator DestroyPlayer()
   {

    _playerController.enabled=false;
    _shoot.enabled=false;
    _slash.enabled=false;
    playerAnim.ResetTrigger("Idle");
    playerAnim.SetTrigger("Dead");
    yield return new WaitForSeconds(2f);
    Destroy(gameObject);

   }

    
}
