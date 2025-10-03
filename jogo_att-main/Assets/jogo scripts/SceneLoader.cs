using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Usaremos o mesmo padr�o Singleton para que seja f�cil de acessar
    public static SceneLoader instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Adicione esta fun��o para carregar o menu assim que o jogo come�ar
    private void Start()
    {
        // Verifica se estamos na cena Initializer para n�o carregar o menu duas vezes
        if (SceneManager.GetActiveScene().name == "Initializer")
        {
            LoadMainMenuScene();
        }
    }

    // --- Fun��es P�blicas para os Bot�es Chamarem ---

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("titulo");
    }

    public void LoadGameScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void LoadNextThemeScene()
    {
        SceneManager.LoadScene("tema1");
    }
    public void LoadFinalScoreScene()
    {
        SceneManager.LoadScene("notaFinal");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT GAME CALLED!"); // Mensagem para teste no editor
        Application.Quit();
    }
}