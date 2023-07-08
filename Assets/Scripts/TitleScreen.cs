using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    /* Opciones del Title Screen*/
    /* Nueva partida y reiniciar */
    public void PlayGame()
    {
        Debug.Log("Playing game ...");
        Debug.Log("Iniciando el nivel uno.");
        SceneManager.LoadScene("LvlOne");
    }
    
    /* Nueva partida en el nivel de test */
    public void PlayTestLvl()
    {
        Debug.Log("Playing game ...");
        Debug.Log("Iniciando el LvlTest.");
        SceneManager.LoadScene("LvlTest");
    }
    
    /* Pantalla de configuración */
    public void ConfigurationGame()
    {
        Debug.Log("Iniciando el Menu de configuración ...");
        //SceneManager.LoadScene(LevelConfiguration); // TODO: "Crear la Escena de configuración."
    }
    
    /* Pantalla de creditos */
    public void CreditsGame()
    {
        Debug.Log("Iniciando la pantalla de creditos...");
        SceneManager.LoadScene("LvlCredits"); // TODO: "Crear la Escena de creditos."
    }
    
    /* Salir del juego */
    public void ExitGame()
    {
        Debug.Log("Exit ...");
        Application.Quit();
    }
    
    /* Regrear al menu principal */
    public void BackToMainMenu()
    {
        Debug.Log("Iniciando el menu principal.");
        SceneManager.LoadScene("TitleScreen");
    }
    
    /* Ir al tutorial del juego */
    public void HowToPlayMenu()
    {
        Debug.Log("Iniciando la pantalla de tutorial...");
        SceneManager.LoadScene("HowToPlayScreen");
    }
}