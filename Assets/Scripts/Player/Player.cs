using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour, IDamageable
{
    public int diamonds;
    
    private Rigidbody2D _rigid;
    [SerializeField]
    private float _jumpForce = 5.0f;
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private LayerMask _groundLayer;
    [SerializeField]
    private float _rayDistance = 1.0f;
    private bool _resetJump = false;
    private bool _grounded = false;

    private PlayerAnimation _playerAnimation;

    private SpriteRenderer _spriteRenderer;
    private SpriteRenderer _swordArcSprite;
    [SerializeField]
    private bool _isDead = false;
    private BoxCollider2D _playerCollider;

    public int Health{ get; set; }

    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _playerAnimation = GetComponent<PlayerAnimation>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _swordArcSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
        _playerCollider = GetComponent<BoxCollider2D>();
        Health = 4;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if ((Input.GetMouseButtonDown(0) /* || CrossPlatformInputManager.GetButtonDown("A_Button") */) && IsGrounded())
        {
            _playerAnimation.Attack();
        }
        if(transform.position.y < -21)
        {
            PlayerDeath();
        }
    }

    void Movement()
    {
        float move = /* CrossPlatformInputManager.GetAxisRaw("Horizontal"); */ Input.GetAxisRaw("Horizontal");

        _grounded = IsGrounded();

        if (move > 0)
        {
            Flip(true);
        }
        else if(move < 0)
        {
            Flip(false);
        }

        if((Input.GetKeyDown(KeyCode.Space) || CrossPlatformInputManager.GetButtonDown("B_Button")) && IsGrounded())
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
            StartCoroutine(ResetJumpRoutine());
            _playerAnimation.Jump(true);
        }

        _rigid.velocity = new Vector2(move * _speed, _rigid.velocity.y);

        _playerAnimation.Move(move);
    }

    bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, _rayDistance, _groundLayer);
        Debug.DrawRay(transform.position, Vector2.down, Color.green);
        if(hitInfo.collider != null)
        {
            if(!_resetJump)
            {
                _playerAnimation.Jump(false);
                return true;
            }
        }
        return false;
    }

    void Flip(bool faceRight)
    {
        if (faceRight)
        {
            _spriteRenderer.flipX = false;
            _swordArcSprite.flipX = false;
            _swordArcSprite.flipY = false;

            Vector2 newPos = _swordArcSprite.transform.localPosition;
            newPos.x = 1.01f;
            _swordArcSprite.transform.localPosition = newPos;
        }
        else
        {
            _spriteRenderer.flipX = true;
            _swordArcSprite.flipX = true;
            _swordArcSprite.flipY = true;

            Vector2 newPos = _swordArcSprite.transform.localPosition;
            newPos.x = -1.01f;
            _swordArcSprite.transform.localPosition = newPos;
        }
    }


    IEnumerator ResetJumpRoutine()
    {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
    }

    public void Damage()
    {
        if (Health < 1)
        {
            return;
        }

        Debug.Log("Player damaged");
        Health--;
        UIManager.Instance.UpdateLives(Health);

        if (Health < 1)
        {
            PlayerDeath();
            return;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Spike")
        {
            PlayerDeath();
            return;
        }
    }

    public void AddGems(int amount)
    {
        diamonds += amount;
        UIManager.Instance.UpdateGemCount(diamonds);
    }

    public void PlayerDeath()
    {
        _playerAnimation.Death();
        UIManager.Instance.GameOverSequence();
    } 
}
