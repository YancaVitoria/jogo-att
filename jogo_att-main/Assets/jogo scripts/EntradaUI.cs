using UnityEngine;

public class EntradaUI : MonoBehaviour
{
    public void OnPlayButtonPressed(int index)
    {
        // Acessa a instp�ncia �nica do SceneLoader e chama a fun��o
        SceneLoader.instance.LoadGameScene(index);
        print("Play button pressed - Loading game scene");
    
    }

    public void SelectThemeAndPlay()
    {
        // Guarda o tema escolhido no nosso GameManager persistente
        //GameManager.instance.selectedTheme = nivel;

        // Carrega a cena principal do jogo (que vamos usar a "tema1" como modelo)
        // No futuro, voc� pode ter v�rias cenas de gameplay, mas por enquanto isso funciona.
        SceneLoader.instance.LoadNextThemeScene(); // Supondo que "tema1" � a cena de gameplay
    }

    public void OnVoltarButtonPressed()
    {
        SceneLoader.instance.LoadMainMenuScene();
    }
}