using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public void OnPlayButtonPressed()
    {
        // Acessa a instância única do SceneLoader e chama a função
        SceneLoader.instance.LoadGameScene();
    }

    public void OnQuitButtonPressed()
    {
        SceneLoader.instance.QuitGame();
    }
}