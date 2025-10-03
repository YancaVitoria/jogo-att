using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public void OnPlayButtonPressed()
    {
        // Acessa a inst�ncia �nica do SceneLoader e chama a fun��o
        SceneLoader.instance.LoadGameScene();
    }

    public void OnQuitButtonPressed()
    {
        SceneLoader.instance.QuitGame();
    }
}