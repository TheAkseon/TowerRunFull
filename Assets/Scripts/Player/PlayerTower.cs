using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TowerBuilder))]
public class PlayerTower : MonoBehaviour
{
    private TowerBuilder _towerBuilder;
    private List<Human> _humansInTower;

    public UnityAction<int> HumanAdded;
    public UnityAction<int> HumanDeleted;

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

        HumanAdded?.Invoke(newHumans.Count);
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

    public void DeleteHumans(int countDeleteHumans)
    {
        if(countDeleteHumans >= _humansInTower.Count)
        {
            SceneRestarter sceneRestarter = FindObjectOfType<SceneRestarter>();
            sceneRestarter.Restart();
            return;
        }

        _humansInTower[0].StopRun();

        for (int i = 0; i < countDeleteHumans; i++)
        {
            _humansInTower[i].transform.parent = null;
            Destroy(_humansInTower[i].gameObject);
            _humansInTower.RemoveAt(i);
        }

        _humansInTower[0].Run();

        SetHumansPosition();

        HumanDeleted?.Invoke(countDeleteHumans);
    }
}
