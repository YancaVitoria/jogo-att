using UnityEngine;

// [System.Serializable] permite que a gente veja e edite essa estrutura no Inspector da Unity.
[System.Serializable]
public class Question
{
    [TextArea(3, 10)] // Faz o campo de texto da pergunta ser maior no Inspector.
    public string questionText; // O texto da pergunta.

    public string[] answers; // Um array com os textos das respostas (ex: 4 opções).

    public int correctAnswerIndex; // O índice da resposta correta no array "answers" (0, 1, 2, ou 3).
}