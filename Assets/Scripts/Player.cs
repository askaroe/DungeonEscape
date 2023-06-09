using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigid;
    [SerializeField]
    private float _jumpForce = 5.0f;
    [SerializeField]
    private bool _grounded = false;
    [SerializeField]
    private LayerMask _groundLayer;
    [SerializeField]
    private float _rayDistance = 0.6f;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");

        if(Input.GetKeyDown(KeyCode.Space) && _grounded == true)
        {
            _grounded = false;
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);

        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, _rayDistance, 1 << 6);

        if (hit.collider != null)
        {
            _grounded = true;
        }
        else
        {
            _grounded = false;
        }

        _rigid.velocity = new Vector2 (move, _rigid.velocity.y);
    }
}
