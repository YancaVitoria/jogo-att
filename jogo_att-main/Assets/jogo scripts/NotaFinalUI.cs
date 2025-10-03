using UnityEngine;
using TMPro; 

public class NotaFinalUI : MonoBehaviour
{
    [Header("Refer�ncias de UI")]
    public TextMeshProUGUI scoreText; // O texto grande da pontua��o (ex: "40")
    public TextMeshProUGUI summaryText; // O texto de resumo (ex: "Voc� acertou 4 de 5...")
    public GameObject[] stars; // Um array para as 3 estrelas

    void Start()
    {
        // Pega os dados que salvamos no GameManager
        int score = GameManager.instance.finalScore;
        int correct = GameManager.instance.correctAnswers;
        int total = GameManager.instance.totalQuestions;

        // Atualiza os textos na tela
        scoreText.text = score.ToString();
        summaryText.text = $"Voc� acertou {correct} de {total} perguntas";

        // L�gica para mostrar as estrelas
        UpdateStars(correct, total);
    }

    void UpdateStars(int correctAnswers, int totalQuestions)
    {
        // Primeiro, desativa todas as estrelas
        foreach (var star in stars)
        {
            star.SetActive(false);
        }

        // Calcula a porcentagem de acertos
        float percentage = (float)correctAnswers / totalQuestions;

        // Ativa as estrelas com base na porcentagem
        if (percentage >= 0.9f) // Acertou 90% ou mais
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
        }
        else if (percentage >= 0.5f) // Acertou 50% ou mais
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
        }
        else if (correctAnswers > 0) // Acertou pelo menos uma
        {
            stars[0].SetActive(true);
        }
    }

    // --- FUN��ES DOS BOT�ES ---
    // Fun��o para o bot�o "Jogar de Novo"
    public void OnReplayButtonPressed()
    {
        // O GameManager ainda tem o �ltimo tema selecionado guardado.
        // Apenas precisamos carregar a cena de gameplay novamente!
        SceneLoader.instance.LoadNextThemeScene();
    }

    // Fun��o para o bot�o "Temas"
    public void OnThemesButtonPressed()
    {
        // Carrega a cena de sele��o de temas (a cena "entrada")
        //SceneLoader.instance.LoadGameScene();
    }

    // Fun��o para o bot�o "In�cio" (Home)
    public void OnHomeButtonPressed()
    {
        // Carrega a cena do menu principal
        SceneLoader.instance.LoadMainMenuScene();
    }
}