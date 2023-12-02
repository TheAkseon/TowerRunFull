using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private PlayerTower _playerTower;

    [SerializeField] private Vector3 _offsetPosition;
    [SerializeField] private Vector3 _offsetRotation;

    [SerializeField] private float _distanceDelta;

    private Vector3 _targetOffsetPosition;

    private void Start()
    {
        _targetOffsetPosition = _offsetPosition;
    }

    private void LateUpdate()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        _offsetPosition = Vector3.MoveTowards(_offsetPosition, _targetOffsetPosition, _distanceDelta * Time.deltaTime);
        transform.position = _playerTower.transform.position + _offsetPosition;

        Vector3 lookAtPoint = _playerTower.transform.position + _offsetRotation;
        transform.LookAt(lookAtPoint);
    }

    private void OnEnable()
    {
        _playerTower.HumanAdded += OnHumanAdded;
        _playerTower.HumanDeleted += OnHumanDeleted;
    }

    private void OnDisable()
    {
        _playerTower.HumanAdded -= OnHumanAdded;
        _playerTower.HumanDeleted -= OnHumanDeleted;
    }

    private void OnHumanAdded(int countAddedHumans)
    {
        _targetOffsetPosition = _offsetPosition + (Vector3.up + Vector3.left) * countAddedHumans;
    }

    private void OnHumanDeleted(int countDeleteHumans)
    {
        _targetOffsetPosition = _offsetPosition - (Vector3.up + Vector3.left) * countDeleteHumans;
    }
}
