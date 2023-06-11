using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    private Vector3 _currentTarget;
    private Animator _anim;
    
    // Start is called before the first frame update
    void Start()
    {
        _anim = transform.GetChild(0).GetComponent<Animator>();
    } 

    // Update is called once per frame
    public override void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (transform.position == pointA.position)
        {
            _currentTarget = pointB.position;
            _anim.SetTrigger("Idle");
        }
        else if (transform.position == pointB.position)
        {
            _currentTarget = pointA.position;
            _anim.SetTrigger("Idle");
        }

        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Idle")){
            Debug.Log("Idling");
            return;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _currentTarget, speed * Time.deltaTime);
        }
    }
}
