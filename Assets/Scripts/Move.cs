using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private SpawnEnemy _spawnEnemy;

    private float _speed = 1f;
    private Vector3 _targetPosition;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit place;

            if (Physics.Raycast(ray, out place))
            {
                _targetPosition = new Vector3(place.point.x, place.point.y, place.point.z);
            }
        }

        if (_spawnEnemy.Soldiers != null)
        {
            foreach (GameObject soldier in _spawnEnemy.Soldiers)
            {
               soldier.transform.position = Vector3.Lerp(soldier.transform.position, _targetPosition, _speed * Time.deltaTime);
            }
        }
    }
}
