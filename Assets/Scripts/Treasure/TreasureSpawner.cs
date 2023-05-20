using UnityEngine;

public class TreasureSpawner : MonoBehaviour
{
    [SerializeField] private Treasure[] _treasures;
    [SerializeField] private Transform[] _spawnPositions;
    [SerializeField] private float _treasureDelay;

    private int _randomTreasureIndex;
    private int _randomPositionIndex;
    private float _currentTimePassed = 0;
    private bool _isSpawned;

    private void OnEnable()
    {
        foreach (var treasure in _treasures)
            treasure.Acquired += OnTreasureAcquired;
    }

    private void OnDisable()
    {
        foreach (var treasure in _treasures)
            treasure.Acquired -= OnTreasureAcquired;
    }

    private void Update()
    {
        _currentTimePassed += Time.deltaTime;
        print(_currentTimePassed);

        if(_currentTimePassed >= _treasureDelay && _isSpawned == false)
        {
            _randomTreasureIndex = Random.Range(0, _treasures.Length - 1);
            _randomPositionIndex = Random.Range(0, _spawnPositions.Length - 1);
            SpawnTreasure(_treasures[_randomTreasureIndex], _spawnPositions[_randomPositionIndex]);
            _isSpawned = true;
        }
    }

    private void SpawnTreasure(Treasure treasure, Transform spawnPosition)
    {
        treasure.gameObject.SetActive(true);
        treasure.SetPosition(spawnPosition);
    }

    private void OnTreasureAcquired()
    {
        _isSpawned = false;
        _currentTimePassed = 0;
    }
}
