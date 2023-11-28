using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TowerBuilder))]
public class Tower : MonoBehaviour
{
    private TowerBuilder _towerBuilder;
    private List<Human> _humansInTower = new List<Human>();

    private void Start()
    {
        _towerBuilder = GetComponent<TowerBuilder>();
        _humansInTower = _towerBuilder.Build();
    }
}
