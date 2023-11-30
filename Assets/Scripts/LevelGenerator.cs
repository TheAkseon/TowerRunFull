using PathCreation;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private int _minCountTower;
    [SerializeField] private int _maxCountTower;
    [SerializeField] private PathCreator _pathCreator;
    [SerializeField] private Tower _towerTemplate;

    private void Start()
    {
        Generate();
    }

    private void Generate()
    {
        int countTowers = Random.Range(_minCountTower, _maxCountTower);
        float distanceBetweenTowers = _pathCreator.path.length / countTowers;
        float distanceSpawn = 0;
        float distanceBeforeSpawn = 0;
        float multiplayerForDistanceBeforeSpawn = 0.01f;

        for (int i = 0; i < countTowers; i++)
        {
            distanceSpawn += distanceBetweenTowers;
            Vector3 spawnPoint = _pathCreator.path.GetPointAtDistance(distanceSpawn, EndOfPathInstruction.Stop);
            Tower newTower = Instantiate(_towerTemplate, spawnPoint, Quaternion.identity, transform);
            distanceBeforeSpawn = distanceSpawn - distanceSpawn * multiplayerForDistanceBeforeSpawn;
            Vector3 pointToLook = _pathCreator.path.GetPointAtDistance(distanceBeforeSpawn);
            newTower.transform.LookAt(pointToLook);
        }
    }
}
