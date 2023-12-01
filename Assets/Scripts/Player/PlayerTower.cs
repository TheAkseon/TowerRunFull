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
    }
}
