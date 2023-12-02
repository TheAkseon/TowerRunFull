using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int _countHumanShotDown;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out PlayerTower playerTower))
        {
            playerTower.DeleteHumans(_countHumanShotDown);
            Destroy(gameObject);
        }
    }
}
