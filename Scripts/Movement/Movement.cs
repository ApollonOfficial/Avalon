using System.Collections;
using UnityEngine;

public struct MoveInput
{
    public float HorizontalInput;
    public bool IsJump;
    public void SetValue(float horizontal, bool isJump)
    {
        HorizontalInput = horizontal;
        IsJump = isJump;
    }
}

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(IEntity))]
public class Movement : MonoBehaviour
{
    [SerializeField][Range(0,0.4f)] private float _waitToLateJumpFloat;
    [SerializeField] private LayerMask groundLayer;
    
    private bool isGrounded;

    private Transform _groundCheck;
    private Rigidbody2D _rigidbody;
    private WaitForSeconds _waitToLateJump;
    private IEntity _entity;

    private float HorizontalInput => _entity.Horizontal;
    private float Speed => _entity.Stats.Speed;
    private float JumpForce => _entity.Stats.JumpForce;
    private float SlopeForce => _entity.Stats.SlopeForce;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _waitToLateJump = new WaitForSeconds(_waitToLateJumpFloat);
        _groundCheck = GetComponentInChildren<FootTrigger>().transform;
        _entity = GetComponent<IEntity>();
    }

    public void MoveUpdate()
    {
        if(GameTime.IsPause)
            return;
        
        isGrounded = Physics2D.OverlapPoint(_groundCheck.position, groundLayer);

        Move();
        _entity.Animator.SetFloat("Speed",Mathf.Abs(HorizontalInput));
        ApplySlopeForce();
        SetDirection(); 
    }

    private void SetDirection() 
    {
        if(HorizontalInput != 0)
            transform.localScale = new Vector2(1*(HorizontalInput/Mathf.Abs(HorizontalInput)),1);
    }

    private void Move()
    {
        Vector2 movement = new Vector2(HorizontalInput, 0);
        _rigidbody.velocity = new Vector2(movement.x * Speed, _rigidbody.velocity.y);
    }

    public void AnimJump()
    {
        if (isGrounded)
        {
            _entity.Animator.SetTrigger("Jump");
        }
    }

    private void Jump()
    {
        if (isGrounded)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, JumpForce);
        }
        else
        {
            StartCoroutine(LateJump());
        }
    }

    private IEnumerator LateJump()
    {
        yield return _waitToLateJump;
        if(isGrounded)
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, JumpForce);
    }

    private void ApplySlopeForce()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, groundLayer);
        if (hit.collider && !isGrounded)
        {
            float slopeAngle = Vector2.Angle(hit.normal, Vector2.up);
            if (slopeAngle > 0 && slopeAngle < 65)
            {
                float slopeForceDirection = hit.normal.x > 0 ? 1 : -1;
                _rigidbody.AddForce(Vector2.right * SlopeForce * slopeForceDirection);
            }
        }
    }
}