using UnityEngine;
using UnityEngine.UI; // Para acessar componentes de UI como Button
using TMPro; // Para acessar componentes TextMeshPro
using System.Collections.Generic;

public class QuizManager : MonoBehaviour
{
    // --- VARI�VEIS PARA CONECTAR NO EDITOR ---
    [Header("Refer�ncias de UI")]
    public TextMeshProUGUI questionText; // Onde a pergunta aparece.
    public Button[] answerButtons; // Nossos 4 bot�es de resposta.

    [Header("Dados do Quiz")]
    public ThemeSO currentTheme; // O tema que ser� jogado (vamos preencher via script).

    // --- VARI�VEIS DE CONTROLE INTERNO ---
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

        // Embaralha as perguntas para que n�o venham sempre na mesma ordem (opcional, mas recomendado)
        Shuffle(questions);

        // Come�a o quiz exibindo a primeira pergunta
        ShowQuestion();
    }

    void ShowQuestion()
    {
        // Se j� respondemos todas as perguntas, termina o quiz
        if (currentQuestionIndex >= questions.Count)
        {
            EndQuiz();
            return;
        }

        // Pega a pergunta atual
        Question currentQuestion = questions[currentQuestionIndex];

        // Atualiza o texto da pergunta na tela
        questionText.text = currentQuestion.questionText;

        // Atualiza o texto dos bot�es de resposta e configura o clique deles
        for (int i = 0; i < answerButtons.Length; i++)
        {
            // Limpa configura��es de cliques anteriores
            answerButtons[i].onClick.RemoveAllListeners();

            // Atualiza o texto do bot�o com a resposta daquela posi��o
            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = currentQuestion.answers[i];

            // Adiciona a l�gica de clique. Precisamos de uma vari�vel local para capturar o �ndice correto.
            int buttonIndex = i;
            answerButtons[i].onClick.AddListener(() => OnAnswerSelected(buttonIndex));
        }
    }

    void OnAnswerSelected(int selectedIndex)
    {
        Question currentQuestion = questions[currentQuestionIndex];

        // Verifica se a resposta selecionada � a correta
        if (selectedIndex == currentQuestion.correctAnswerIndex)
        {
            Debug.Log("Resposta Correta!");
            score += 10; // Aumenta a pontua��o
            correctAnswersCount++;
        }
        else
        {
            Debug.Log("Resposta Incorreta!");
        }

        // Vai para a pr�xima pergunta
        currentQuestionIndex++;
        ShowQuestion();
    }

    void EndQuiz()
    {
        Debug.Log($"Quiz finalizado! Sua pontua��o: {score}");
        // Aqui, vamos salvar a pontua��o e ir para a cena de nota final.
        // (Vamos implementar o salvamento da pontua��o na pr�xima fase)
        GameManager.instance.finalScore = score;
        GameManager.instance.correctAnswers = correctAnswersCount;
        GameManager.instance.totalQuestions = questions.Count;

        SceneLoader.instance.LoadFinalScoreScene();
    }

    // Fun��o para embaralhar a lista de perguntas
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