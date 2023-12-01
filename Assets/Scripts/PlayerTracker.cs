using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private PlayerTower _playerTower;

    [SerializeField] private Vector3 _offset;

    private void LateUpdate()
    {
        transform.position = _playerTower.transform.position + _offset;
        transform.LookAt(_playerTower.transform);
    }
}
