using UnityEngine;

public class EntradaUI : MonoBehaviour
{
    public void SelectThemeAndPlay(ThemeSO theme)
    {
        // Guarda o tema escolhido no nosso GameManager persistente
        GameManager.instance.selectedTheme = theme;

        // Carrega a cena principal do jogo (que vamos usar a "tema1" como modelo)
        // No futuro, voc� pode ter v�rias cenas de gameplay, mas por enquanto isso funciona.
        SceneLoader.instance.LoadNextThemeScene(); // Supondo que "tema1" � a cena de gameplay
    }

    public void OnVoltarButtonPressed()
    {
        SceneLoader.instance.LoadMainMenuScene();
    }
}