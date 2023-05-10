using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawner : MonoBehaviour
{
    [SerializeField] private Minion _minionTemplate;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Goldmine[] _goldmines;

    private int _maxMinions = 3;
    private Coroutine _spawnWithDelay;
    private WaitForSeconds _spawnTimer = new WaitForSeconds(2f);

    private void OnEnable()
    {
        foreach (var goldmine in _goldmines)
            goldmine.Activated += OnGoldmineActivated;
    }

    private void OnDisable()
    {
        foreach (var goldmine in _goldmines)
            goldmine.Activated -= OnGoldmineActivated;
    }

    private void Spawn(Goldmine goldmine)
    {
        Minion minion = Instantiate(_minionTemplate, _spawnPoint);
        minion.GoToGoldMine(goldmine);
    }

    private void OnGoldmineActivated(Goldmine goldmine)
    {
        _spawnWithDelay = StartCoroutine(SpawnWithDelay(goldmine));
    }

    private IEnumerator SpawnWithDelay(Goldmine goldmine)
    {
        for(int i = 0; i < _maxMinions; i++)
        {
            Spawn(goldmine);
            yield return _spawnTimer;
        }
    }
}
