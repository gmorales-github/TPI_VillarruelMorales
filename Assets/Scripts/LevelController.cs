using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] public int contador_jarrones = 0;
    GameObject Demo;
    GameObject LvlOne;
    GameObject LvlTwo;
    public Text textElement; 


    private void Awake()
    {
        // Obtiene el nombre del nivel y lo muestra en la UI
        textElement.text = SceneManager.GetActiveScene().name;
    }
    void Start()
    {
        // Capturo en la variable Demo el gameobject Demo.
        Demo = GameObject.Find("Demo");
        LvlOne = GameObject.Find("LvlOne");
        LvlTwo = GameObject.Find("LvlTwo");
    }
    
    // Método para capturar la scena actual o nivel.
    public void CurrentLevel()
    {
        Debug.Log("Current level");
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Mi nivel actual es: " + scene.name);
    }
    public void NextLevel()
    {
        Debug.Log("Iniciando el próximo nivel");
        SceneManager.LoadScene("LvlTwo");
    }

    private void BackLevel()
    {
        Debug.Log("Volviendo al nivel anterior");
    }
    public void PauseMenuResume()
    {
        Debug.Log("Ingresando a la pantalla de pausa");
        pauseMenu.GetComponent<PauseScreen>().Resume();
    }
    public void PauseMenuPause()
    {
        Debug.Log("Ingresando a la pantalla de pausa");
        pauseMenu.GetComponent<PauseScreen>().Pause();
    }
    public void GameOverLevel()
    {
        // Código para el nivel demo. Retorna al tilescreen.
        if (Demo)
        {
            Debug.Log("Usted finalizo el nivel de demostración.");
            SceneManager.LoadScene("TitleScreen");
        }
        else
        {
            Debug.Log("Usted pérdio la partida.");
            SceneManager.LoadScene("GameOverScreen");
        }
    }
    public void SumarJarrones()
    {
        contador_jarrones++;
    }
    public void RestarJarrones()
    {
        contador_jarrones--;
    }
    public void WinLevel()
    {
        // Si encuentra el Gameobject Demo se dirige a al title Screen.
        if (Demo)
        {
            Debug.Log("Felicitaciones!!!, usted finalizo el nivel de demostración.");
            // Vuelve al TitleScreen.
            SceneManager.LoadScene("TitleScreen");
        }
        else if (LvlOne)
        {
            Debug.Log("Felicitaciones!!!, usted paso al próximo nivel.");
            NextLevel();
        }
        else if (LvlTwo)
        {
            Debug.Log("Felicitaciones!!!, usted ha ganado la partida.");
            SceneManager.LoadScene("WinGameScreen");
        }
    }
}