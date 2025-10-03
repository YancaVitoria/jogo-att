using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public void OnPlayButtonPressed(int index)
    {
        // Acessa a instp�ncia �nica do SceneLoader e chama a fun��o
        SceneLoader.instance.LoadGameScene(index);
        print("Play button pressed - Loading game scene");
    
    }

    public void OnQuitButtonPressed()
    {
        SceneLoader.instance.QuitGame();
    }
}