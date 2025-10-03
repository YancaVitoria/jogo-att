using UnityEngine;

// O nome do arquivo deve ser "GameManager.cs" para corresponder ao nome da classe.
public class GameManager : MonoBehaviour
{
    // A instância estática (Singleton) que pode ser acessada de qualquer outro script.
    public static GameManager instance;

    public ThemeSO selectedTheme;

    public int finalScore;
    public int correctAnswers;
    public int totalQuestions;

    // A função Awake é chamada antes de qualquer função Start, assim que o objeto é criado.
    private void Awake()
    {
        // --- LÓGICA DO SINGLETON ---

        // Se a "instance" ainda não foi definida...
        if (instance == null)
        {
            // ...então esta se torna a instância principal.
            instance = this;

            // E este objeto não será destruído ao carregar novas cenas.
            DontDestroyOnLoad(gameObject);
        }
        // Se uma instância já existe e não é esta...
        else
        {
            // ...então este objeto é uma duplicata, e deve se autodestruir.
            Destroy(gameObject);
        }
    }
}