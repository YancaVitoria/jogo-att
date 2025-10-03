using UnityEngine;
using System.Collections.Generic;

// A linha abaixo cria uma opção no menu da Unity para criar novos temas.
[CreateAssetMenu(fileName = "Novo Tema", menuName = "Quiz/Novo Tema")]
public class ThemeSO : ScriptableObject
{
    public string themeName; // Nome do tema (ex: "História do Brasil")
    public List<Question> questions = new List<Question>(); // A lista de perguntas para este tema.
}