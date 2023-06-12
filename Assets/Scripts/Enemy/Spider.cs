using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public GameObject acidEffectPrefab;
    
    public int Health { get; set; }

    //used for initialize
    public override void Init()
    {
        base.Init();

        Health = base.health;
    }

    public override void Update()
    {
        //nothing 
    }
    public void Damage()
    {
        Health--;
        if(Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
        }
    }

    public override void Movement()
    {
        // nothing
    }

    public void Attack()
    {
        Instantiate(acidEffectPrefab, transform.position, Quaternion.identity);
    }
}
