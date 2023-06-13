using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
    public int Health { get; set; }
    
    //used for initialize
    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    public override void Movement()
    {
        base.Movement();
    }
    public void Damage()
    {
        if (isDead)
        {
            return;
        }

        Debug.Log("Damage moss giant");
        Health--;
        anim.SetTrigger("Hit");
        isHit = true;
        anim.SetBool("InCombat", true);

        if (Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
            GameObject diamond = (GameObject)Instantiate(diamondPrefab, transform.position, Quaternion.identity);
            diamond.GetComponent<Diamond>().gems = base.gems;
        }
    }
}
