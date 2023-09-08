using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private Rigidbody _enemy;

    private List<GameObject> _spawns = new List<GameObject>();
    private List<Rigidbody> _soldiers = new List<Rigidbody>();

    private int _currentSpawn;

    private float _timeSpawn = 2f;

    public List<Rigidbody> CreatedSoldiers => _soldiers;

    private void Awake()
    {
        foreach (Transform child in transform)
        {
            _spawns.Add(child.gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(CreateSoldier());
    }

    private IEnumerator CreateSoldier()
    {
        WaitForSeconds waitTimeSpawn = new(_timeSpawn);

        while (true)
        {
            _currentSpawn = Random.Range(0, _spawns.Count);

            var soldier = Instantiate(_enemy, _spawns[_currentSpawn].transform.position, Quaternion.identity);

            _soldiers.Add(soldier);

            yield return waitTimeSpawn;
        }
    }
}
