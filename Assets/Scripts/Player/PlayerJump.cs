using PathCreation.Examples;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float _jumpForce;

    private Rigidbody _rigidbody;
    private bool _isGrounded;
    private float _baseJumpForce;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _baseJumpForce = _jumpForce;
    }

    private void Update()
    {
        Jump();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Road road))
        {
            _isGrounded = true;
        }
    }

    private void Jump()
    {
        if (Input.GetMouseButtonDown(0) && _isGrounded == true)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isGrounded = false;
        }
    }

    private void BoostJump(float jumpMultiplyer)
    {
        _jumpForce *= jumpMultiplyer;
    }

    private void ResetJumpBoost()
    {

        _jumpForce = _baseJumpForce;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out JumpBooster jumpBooster))
        {
            BoostJump(jumpBooster.JumpBoostMultiplayer);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out JumpBooster jumpBooster))
        {
            ResetJumpBoost();
        }
    }
}
