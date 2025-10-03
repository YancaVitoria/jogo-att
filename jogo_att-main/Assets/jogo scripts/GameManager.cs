using UnityEngine;

// O nome do arquivo deve ser "GameManager.cs" para corresponder ao nome da classe.
public class GameManager : MonoBehaviour
{
    // A inst�ncia est�tica (Singleton) que pode ser acessada de qualquer outro script.
    public static GameManager instance;

    public ThemeSO selectedTheme;

    public int finalScore;
    public int correctAnswers;
    public int totalQuestions;

    // A fun��o Awake � chamada antes de qualquer fun��o Start, assim que o objeto � criado.
    private void Awake()
    {
        // --- L�GICA DO SINGLETON ---

        // Se a "instance" ainda n�o foi definida...
        if (instance == null)
        {
            // ...ent�o esta se torna a inst�ncia principal.
            instance = this;

            // E este objeto n�o ser� destru�do ao carregar novas cenas.
            DontDestroyOnLoad(gameObject);
        }
        // Se uma inst�ncia j� existe e n�o � esta...
        else
        {
            // ...ent�o este objeto � uma duplicata, e deve se autodestruir.
            Destroy(gameObject);
        }
    }
}