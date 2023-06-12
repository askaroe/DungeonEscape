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
    public void Damage()
    {
        Health--;
        if(Health < 1)
        {
            Destroy(this.gameObject);
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
