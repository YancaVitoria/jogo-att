using UnityEngine;
using UnityEngine.UI; // Para acessar componentes de UI como Button
using TMPro; // Para acessar componentes TextMeshPro
using System.Collections.Generic;

public class QuizManager : MonoBehaviour
{
    // --- VARIÁVEIS PARA CONECTAR NO EDITOR ---
    [Header("Referências de UI")]
    public TextMeshProUGUI questionText; // Onde a pergunta aparece.
    public Button[] answerButtons; // Nossos 4 botões de resposta.

    [Header("Dados do Quiz")]
    public ThemeSO currentTheme; // O tema que será jogado (vamos preencher via script).

    // --- VARIÁVEIS DE CONTROLE INTERNO ---
    private List<Question> questions;
    private int currentQuestionIndex = 0;
    private int score = 0;


    private int correctAnswersCount = 0;

    void Start()
    {
        // Pega o tema selecionado na cena anterior
        currentTheme = GameManager.instance.selectedTheme;

        // Pega a lista de perguntas do tema
        questions = new List<Question>(currentTheme.questions);

        // Embaralha as perguntas para que não venham sempre na mesma ordem (opcional, mas recomendado)
        Shuffle(questions);

        // Começa o quiz exibindo a primeira pergunta
        ShowQuestion();
    }

    void ShowQuestion()
    {
        // Se já respondemos todas as perguntas, termina o quiz
        if (currentQuestionIndex >= questions.Count)
        {
            EndQuiz();
            return;
        }

        // Pega a pergunta atual
        Question currentQuestion = questions[currentQuestionIndex];

        // Atualiza o texto da pergunta na tela
        questionText.text = currentQuestion.questionText;

        // Atualiza o texto dos botões de resposta e configura o clique deles
        for (int i = 0; i < answerButtons.Length; i++)
        {
            // Limpa configurações de cliques anteriores
            answerButtons[i].onClick.RemoveAllListeners();

            // Atualiza o texto do botão com a resposta daquela posição
            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = currentQuestion.answers[i];

            // Adiciona a lógica de clique. Precisamos de uma variável local para capturar o índice correto.
            int buttonIndex = i;
            answerButtons[i].onClick.AddListener(() => OnAnswerSelected(buttonIndex));
        }
    }

    void OnAnswerSelected(int selectedIndex)
    {
        Question currentQuestion = questions[currentQuestionIndex];

        // Verifica se a resposta selecionada é a correta
        if (selectedIndex == currentQuestion.correctAnswerIndex)
        {
            Debug.Log("Resposta Correta!");
            score += 10; // Aumenta a pontuação
            correctAnswersCount++;
        }
        else
        {
            Debug.Log("Resposta Incorreta!");
        }

        // Vai para a próxima pergunta
        currentQuestionIndex++;
        ShowQuestion();
    }

    void EndQuiz()
    {
        Debug.Log($"Quiz finalizado! Sua pontuação: {score}");
        // Aqui, vamos salvar a pontuação e ir para a cena de nota final.
        // (Vamos implementar o salvamento da pontuação na próxima fase)
        GameManager.instance.finalScore = score;
        GameManager.instance.correctAnswers = correctAnswersCount;
        GameManager.instance.totalQuestions = questions.Count;

        SceneLoader.instance.LoadFinalScoreScene();
    }

    // Função para embaralhar a lista de perguntas
    void Shuffle<T>(List<T> list)
    {
        for (int i = 0; i < list.Count - 1; i++)
        {
            int rnd = Random.Range(i, list.Count);
            T temp = list[rnd];
            list[rnd] = list[i];
            list[i] = temp;
        }
    }
}