using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Destruidor : MonoBehaviour
{

    public AudioSource audioSource;
    public TextMeshProUGUI texto;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject colisor = collision.collider.gameObject;
        GameObject.Destroy(colisor);
        audioSource.Play();
        texto.text = "GAME OVER!";
    }
}
