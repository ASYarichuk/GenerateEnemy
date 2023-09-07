using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;

    private List<GameObject> _spawns = new List<GameObject>();
    private List<GameObject> _soldiers = new List<GameObject>();

    private int _currentSpawn;

    private float _currentTime;
    private float _timeSpawn = 2f;

    public List<GameObject> Soldiers => _soldiers;

    private void Awake()
    {
        foreach (Transform child in transform)
        {
            _spawns.Add(child.gameObject);
        }
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if(_currentTime >= _timeSpawn)
        {
            _currentSpawn = Random.Range(0, _spawns.Count);

            var soldier = Instantiate(_enemy, _spawns[_currentSpawn].transform.position, Quaternion.identity);

            _soldiers.Add(soldier);

            _currentTime = 0;
        }
    }
}
