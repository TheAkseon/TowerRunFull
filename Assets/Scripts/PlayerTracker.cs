using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private PlayerTower _playerTower;

    [SerializeField] private Vector3 _offsetPosition;
    [SerializeField] private Vector3 _offsetRotation;

    private void LateUpdate()
    {
        transform.position = _playerTower.transform.position + _offsetPosition;

        Vector3 lookAtPoint = _playerTower.transform.position + _offsetRotation;
        transform.LookAt(lookAtPoint);
    }
}
