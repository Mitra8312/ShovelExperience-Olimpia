using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void Continue()
    {
        gameManager.SetDeactiveMenu();
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        gameManager.SetDeactiveMenu();
        Time.timeScale = 1f;
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene("Main");
        gameManager.SetDeactiveMenu();
        Time.timeScale = 1f;
    }
}
