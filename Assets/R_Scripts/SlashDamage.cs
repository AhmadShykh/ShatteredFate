using System.Collections;
using System.Collections.Generic;
using CodeMonkey.HealthSystemCM;
using Unity.VisualScripting;
using UnityEngine;

public class SlashDamage : MonoBehaviour
{

     private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Enemy")
        {
            other.transform.GetComponent<HealthSystemComponent>().GetHealthSystem().Damage(10f);
        }
    }
    


    

}
