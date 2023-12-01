using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private Human[] _humansTemplates;
    [SerializeField] private int _minHumanInTower;
    [SerializeField] private int _maxHumanInTower;

    private Vector3 _currentSpawnPoint;

    private void Start()
    {
        _currentSpawnPoint = transform.position;
    }

    public List<Human> Build()
    {
        int countHumansInTower = Random.Range(_minHumanInTower, _maxHumanInTower);
        List<Human> humansInTower = new List<Human>();

        for (int i = 0; i < countHumansInTower; i++)
        {
            Human newHuman = BuildHuman();
            humansInTower.Add(newHuman);
        }

        SetHumanAnimation(humansInTower);

        return humansInTower;
    }

    private Human BuildHuman()
    {
        Human newHuman = Instantiate(_humansTemplates[Random.Range(0, _humansTemplates.Length)], _currentSpawnPoint, 
            transform.rotation, transform);
        _currentSpawnPoint = newHuman.FixationPoint.transform.position;

        return newHuman;
    }

    private void SetHumanAnimation(List<Human> humansInTower)
    {
        bool isAnimated;

        for (int i = 0; i < humansInTower.Count; i++)
        {
            isAnimated = Convert.ToBoolean(Random.Range(0, 2));

            if (isAnimated)
            {
                humansInTower[i].SetRandomAnimation();
            }
        }
    }
}
