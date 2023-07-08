using UnityEngine;

public class LockTrigger : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private GameObject[] _blocks;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            Lock(true);
            _enemySpawner.gameObject.SetActive(true);
            GetComponent<Collider2D>().enabled = false;
            Debug.Log("---Puerta bloqueada---");
        }
    }

    private void Lock(bool value)
    {
        for (int i = 0; i < _blocks.Length; i++)
        {
            _blocks[i].SetActive(value);
        }
    }
    private void Update()
    {
        if (_enemySpawner.GetComplete())
        {
            Lock(false);
            _enemySpawner.gameObject.SetActive(false);
            Debug.Log("---Puerta Desbloqueada---");
        }
    }
}
