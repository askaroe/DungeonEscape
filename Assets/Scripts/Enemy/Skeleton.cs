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

    public override void Movement()
    {
        base.Movement();

        Vector3 direction = player.transform.localPosition - transform.localPosition;

        if (direction.x < 0 && anim.GetBool("InCombat"))
        {
            spriteRenderer.flipX = true;
        }
        else if (direction.x > 0 && anim.GetBool("InCombat"))
        {
            spriteRenderer.flipX = false;
        }

    }
    public void Damage()
    {
        Debug.Log("Damage!");
        Health--;
        anim.SetTrigger("Hit");
        isHit = true;
        anim.SetBool("InCombat", true);

        if(Health < 1)
        {
            Destroy(this.gameObject);
        }
    }
}
