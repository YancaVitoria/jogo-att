using UnityEngine;
using UnityEngine.SceneManagement;

public class comandosBasicos : MonoBehaviour
{

    public static comandosBasicos instance;

    private void Awake()
    {
        // Se ainda não existe uma instância
        if (instance == null)
        {
            // esta se torna a instância.
            instance = this;
            // E não seja destruído ao carregar uma nova cena.
            DontDestroyOnLoad(gameObject);
        }
        // Se uma instância já existe e não é esta...
        else
        {
            // destrua este objeto para evitar duplicatas.
            Destroy(gameObject);
        }
    }
    public void CarregarCena(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);
    }
}
