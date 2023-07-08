using UnityEngine;
using TMPro;
using TMPro.Examples;

public class Timer : MonoBehaviour
{
    public float timer = 0;
    public TextMeshProUGUI TextTimer;
    [SerializeField] private LevelController _levelController;
    void Update()
    {
        countdownTimer();
        
        // Condición de derrota por tiempo.
        if (timer < 0)
        {
            Debug.Log("Tiempo cumplido.");
            // Invoco al método de derrota
            _levelController.GetComponent<LevelController>().GameOverLevel();
        }
    }

    private void countdownTimer()
    {
        // Seteo el cronómetro hacia atras
        timer -= Time.deltaTime;
        // Muestro el tiempo en la UI
        TextTimer.text = "" + timer.ToString("f0");
    }
}
