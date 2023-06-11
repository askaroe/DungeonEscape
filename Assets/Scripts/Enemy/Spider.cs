using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    private Vector3 _currentPosition;
    private Animator _anim;
    private SpriteRenderer _spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        _anim = transform.GetChild(0).GetComponent<Animator>();
        _spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    public override void Update()
    {
        
        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }

        Movement();
    }

    void Movement()
    {
        if (_currentPosition == pointA.position)
        {
            _spriteRenderer.flipX = true;
        }
        else if (_currentPosition == pointB.position)
        {
            _spriteRenderer.flipX = false;
        }


        if (transform.position == pointA.position)
        {
            _currentPosition = pointB.position;
            _anim.SetTrigger("Idle");
        }
        else if (transform.position == pointB.position)
        {
            _currentPosition = pointA.position;
            _anim.SetTrigger("Idle");
        }

        transform.position = Vector3.MoveTowards(transform.position, _currentPosition, speed * Time.deltaTime);
    }
}
