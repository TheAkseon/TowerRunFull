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

    public List<Human> GiveHumans(Human givedHuman)
    {
        int countGivedHumans = _humansInTower.IndexOf(givedHuman) + 1;
        List<Human> givedHumans = _humansInTower.GetRange(0, countGivedHumans);
        _humansInTower.RemoveRange(0, countGivedHumans);

        return givedHumans;
    }
}
