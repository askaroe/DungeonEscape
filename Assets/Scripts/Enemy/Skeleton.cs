using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { get; set; }

    //used for initialize
    public override void Init()
    {
        base.Init();

        Health = base.health;
    }
    public void Damage()
    {
        Debug.Log("Damage!");
        Health--;

        if(Health < 1)
        {
            Destroy(this.gameObject);
        }
    }
}
