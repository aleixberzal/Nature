using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public string gameSceneName = "GameScene";
    public string creditsSceneName = "CreditsScene";
    public GameObject menuCanvas; // Referencia al Canvas del menú

    private void Start()
    {
        // Asegurarse de que el menú está oculto al inicio
        if (menuCanvas != null)
        {
            menuCanvas.SetActive(false);
        }
    }

    private void Update()
    {
        // Mostrar/ocultar menú al presionar ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }

    private void ToggleMenu()
    {
        bool isMenuActive = !menuCanvas.activeSelf;
        menuCanvas.SetActive(isMenuActive);

        // Pausar/despausar el juego (opcional)
        Time.timeScale = isMenuActive ? 0f : 1f;
    }

    public void StartGame()
    {
        Time.timeScale = 1f; // Asegurar que el tiempo se reanude
        SceneManager.LoadScene(gameSceneName);
    }

    public void ShowCredits()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(creditsSceneName);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}