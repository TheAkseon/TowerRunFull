using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Animator))]
public class Human : MonoBehaviour
{
    [SerializeField] private Transform _fixationPoint;

    private Rigidbody _rigidbody;
    private Animator _animator;
    public Transform FixationPoint => _fixationPoint;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void Texting()
    {
        _animator.SetBool("isTexting", true);
    }

    private void Kicking()
    {
        _animator.SetBool("isKicking", true);
    }

    private void Waving()
    {
        _animator.SetBool("isWaving", true);
    }

    public void Bounce()
    {
        float explosionForce = Random.Range(500, 5000);
        float explosionRadius = Random.Range(500, 5000);
        Vector3 explosionPosition = new Vector3(transform.position.x - Random.Range(0, 5), transform.position.y - Random.Range(0, 5), transform.position.z - Random.Range(0, 5));

        _animator.applyRootMotion = false;
        _rigidbody.isKinematic = false;
        _rigidbody.useGravity = true;
        transform.parent = null;

        _rigidbody.AddExplosionForce(explosionForce, explosionPosition, explosionRadius);

        Destroy(gameObject, 2f);
    }

    public void Run()
    {
        _animator.SetBool("isRunning", true);
    }

    public void StopRun()
    {
        _animator.SetBool("isRunning", false);
    }

    public void SetRandomAnimation()
    {
        int numberAnimation = Random.Range(1, 4);

        switch (numberAnimation)
        {
            case 1:
                Texting();
                break;
            case 2:
                Kicking();
                break;
            case 3:
                Waving();
                break;
        }
    }

}
