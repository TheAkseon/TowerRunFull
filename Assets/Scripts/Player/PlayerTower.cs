using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TowerBuilder))]
public class PlayerTower : MonoBehaviour
{
    private TowerBuilder _towerBuilder;
    private List<Human> _humansInTower;

    private void Start()
    {
        _towerBuilder = GetComponent<TowerBuilder>();
        _humansInTower = _towerBuilder.Build();
        _humansInTower[0].Run();
    }

    public void AddNewHumans(List<Human> newHumans)
    {
        _humansInTower[0].StopRun();

        for (int i = 0; i < newHumans.Count; i++)
        {
            _humansInTower.Insert(i, newHumans[i]);
            _humansInTower[i].transform.parent = transform;
        }

        _humansInTower[0].Run();

        SetHumansPosition();
    }

    private void SetHumansPosition()
    {
        Vector3 currentHumanPosition = transform.position;

        for (int i = 0; i < _humansInTower.Count; i++)
        {
            _humansInTower[i].transform.position = currentHumanPosition;
            currentHumanPosition = _humansInTower[i].FixationPoint.transform.position;
            _humansInTower[i].transform.rotation = transform.rotation;
        }
    }
}
