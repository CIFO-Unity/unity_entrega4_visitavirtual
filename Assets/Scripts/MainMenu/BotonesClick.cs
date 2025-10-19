using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Maneja los eventos onClick de los botones del Canvas principal
/// </summary>
public class BotonesClick : MonoBehaviour
{
    private string escenaCambioCamaras = "CementerioCambioCamaras";

    private string escenaPrimeraPersona = "CementerioPrimeraPersona";

    public void CargarEscenaCambioCamaras()
    {
        SceneManager.LoadScene(escenaCambioCamaras);
    }

    public void CargarEscenaPrimeraPersona()
    {
        SceneManager.LoadScene(escenaPrimeraPersona);
    }

    public void SalirDelJuego()
    {
        
        #if UNITY_EDITOR
            // En el editor, detiene el modo Play
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            // En build, cierra la aplicación
            Application.Quit();
        #endif
    }

    public void VolverAlMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
