using UnityEngine; 
using System.Collections; 
using System.Collections.Generic; 
using UnityEngine.SceneManagement; 

public class MenuSystem : MonoBehaviour
{
    
    public void Jugar()
    {
        // Carga la siguiente escena en el Build Settings
        // SceneManager.GetActiveScene().buildIndex obtiene el índice de la escena actual
        // +1 significa que se cargará la siguiente escena en la lista
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    
    public void Salir()
    {
        // Cierra la aplicación. Esto funciona al ejecutar el juego compilado,
        // en el editor de Unity no detendrá el juego
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}