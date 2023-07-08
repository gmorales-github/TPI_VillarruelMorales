using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] private GameObject menuPause;
    GameObject Demo;
    GameObject LvlOne;
    GameObject LvlTwo;
    
    void Start()
    {
        // Capturo en la variable Demo el gameobject Demo.
        Demo = GameObject.Find("Demo");
        LvlOne = GameObject.Find("LvlOne");
        LvlTwo = GameObject.Find("LvlTwo");
    }

    public void Pause()
    {
        Debug.Log("Se presiono el botón pausa");
        Time.timeScale = 0f;
        menuPause.SetActive(true);
    }

    public void Resume()
    {
        Debug.Log("Se presiono el botón resume");
        Time.timeScale = 1f;
        menuPause.SetActive(false);
    }
    
    public void Restart()
    {
        Debug.Log("Se presiono el botón reiniciar");
        Time.timeScale = 1f;
        menuPause.SetActive(false);
        
        if (Demo)
        {
            Debug.Log("Playing game ...");
            Debug.Log("Iniciando la Demo.");
            SceneManager.LoadScene("LvlTest");
        }
        else if (LvlOne)
        {
            Debug.Log("Playing game ...");
            Debug.Log("Iniciando el nivel uno.");
            SceneManager.LoadScene("LvlOne");
        }
        else if (LvlTwo)
        {
            Debug.Log("Playing game ...");
            Debug.Log("Iniciando el nivel dos.");
            SceneManager.LoadScene("LvlTwo");
        }
    }

    public void MainMenu()
    {
        Debug.Log("Se presiono el botón regresar al menu principal");
        Time.timeScale = 1f;
        SceneManager.LoadScene("TitleScreen");
    }

    public void ExitGame()
    {
        Debug.Log("Se presiono el botón salir del juego");
        Application.Quit();
    }
    
    public void HowToPlayMenu()
    {
        Debug.Log("Iniciando el Menu How to play...");
        SceneManager.LoadScene("InstructionsScreen");
    }
}