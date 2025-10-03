using UnityEngine;
using UnityEngine.SceneManagement;

public class comandosBasicos : MonoBehaviour
{

    public static comandosBasicos instance;

    private void Awake()
    {
        // Se ainda n�o existe uma inst�ncia
        if (instance == null)
        {
            // esta se torna a inst�ncia.
            instance = this;
            // E n�o seja destru�do ao carregar uma nova cena.
            DontDestroyOnLoad(gameObject);
        }
        // Se uma inst�ncia j� existe e n�o � esta...
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
