using System.Collections;
using System.Collections.Generic;
using CodeMonkey.HealthSystemCM;
using Unity.VisualScripting;
using UnityEngine;

public class SlashDamage : MonoBehaviour
{

    public AudioClip enemyHurtSFX;

     private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Enemy")
        {
            other.transform.GetComponent<EnemyHealth>().GetHealthSystem().Damage(15f);
            SoundManager.instance.playSoundEffect(enemyHurtSFX);
        }
    }
    


    

}
