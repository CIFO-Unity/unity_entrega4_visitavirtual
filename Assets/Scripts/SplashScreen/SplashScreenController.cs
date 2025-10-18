using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para poder cargar otras escenas

public class SplashScreenController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("LoadNextScene", 5.0f);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
