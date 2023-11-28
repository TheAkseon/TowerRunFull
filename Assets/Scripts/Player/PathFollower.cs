using PathCreation;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PathFollower : MonoBehaviour
{
    [SerializeField] private PathCreator _pathCreator;
    [SerializeField] private float _speed;

    private float _distanceTravelled = 0;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _distanceTravelled += _speed * Time.deltaTime;

        Vector3 nextPoint = _pathCreator.path.GetPointAtDistance(_distanceTravelled, EndOfPathInstruction.Loop);
        nextPoint.y = transform.position.y;
        transform.LookAt(nextPoint);
        _rigidbody.MovePosition(nextPoint);
    }
}
