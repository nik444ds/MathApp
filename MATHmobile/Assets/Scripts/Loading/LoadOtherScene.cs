using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOtherScene : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(5); // Aguarda 5 segundos antes de carregar a cena
        SceneManager.LoadScene("Multiplication"); // Carrega a cena desejada
    }
}