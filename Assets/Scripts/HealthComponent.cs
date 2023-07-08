using UnityEngine;


public class HealthComponent : MonoBehaviour
{
    [SerializeField] private int health; // salud
    [SerializeField] private GameObject gameController;
    [SerializeField] private LevelController _levelController;
    [SerializeField] private AudioSource destroySoundEffect;
    private int _currentHealth;
    public GameObject[] Hearts;

    private void Start()
    {
        if (gameObject.layer == 3)
        {
            _levelController.SumarJarrones();
        }
    }

    private void OnEnable()
    {
        _currentHealth = health;
    }

    private void Update()
    {
        if (_currentHealth <= 1 && gameObject.name == "Player")
        {
            Hearts[0].gameObject.SetActive(false);
            Debug.Log("Cora destruido.");
        }
        else if (_currentHealth <= 3 && gameObject.name == "Player")
        {
            Hearts[1].gameObject.SetActive(false);
            Debug.Log("Cora destruido.");
        }
        else if (_currentHealth <= 6 && gameObject.name == "Player")
        {
            Hearts[2].gameObject.SetActive(false);
            Debug.Log("Cora destruido.");
        }
    }

    public void TakeDamageEnemy(int amount)
    {
        _currentHealth -= amount;


        if (_currentHealth < 1)
        {
            // Código para elminiar los jarrones
            if (gameObject.layer == 3)
            {
                Debug.Log("Jarron eliminado");
                _levelController.RestarJarrones();
                Destroy(gameObject);
            }

            // Código para eliminar los enemigos
            Destroy(gameObject);
            Debug.Log("Enemigo destruido.");

            // Condición de victoria
            if (GameObject.Find("GameController").GetComponent<LevelController>().contador_jarrones == 0)
            {
                _levelController.WinLevel();
            }
        }
    }

    public void TakeDamagePJ(int amount)
    {
        _currentHealth -= amount;


        if (_currentHealth != 1 && gameObject.name == "Player")
        {
            Debug.Log("Player alcanzado por fuego enemigo.");
            destroySoundEffect.Play();
        }

        if (_currentHealth < 1)
        {
            if (gameObject.name == "Player")
            {
                Debug.Log("Player destruido.");
                Destroy(gameObject);
                gameController.GetComponent<LevelController>().GameOverLevel();
            }
        }
    }
}

// public void Heal(int amount)  curar
//  {
//     _currentHealth += amount;
//      if (_currentHealth > health)
//      {
//          _currentHealth = health;
//     }
//  }