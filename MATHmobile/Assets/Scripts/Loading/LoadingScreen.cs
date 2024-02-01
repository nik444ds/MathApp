using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public Image[] images;
    public Text[] texts;

    private int currentIndex;

    private void Start()
    {
        StartCoroutine(Load());
    }

    private IEnumerator Load()
    {
        while (true)
        {
            currentIndex = Random.Range(0, images.Length);

            SetImage(images[currentIndex]);
            SetText(texts[currentIndex]);

            yield return new WaitForSeconds(5);
        }
    }

    private void SetImage(Image image)
    {
        // Reativa todos os objetos Image
        foreach (Image img in images)
        {
            img.gameObject.SetActive(true);
        }

        image.gameObject.SetActive(true);

        if (image == null)
        {
            Debug.LogError("Image object is null!");
            return;
        }

        // Desativa todos os objetos Image, exceto o objeto Image selecionado
        foreach (Image img in images)
        {
            if (img != image)
            {
                img.gameObject.SetActive(false);
            }
        }
    }

    private void SetText(Text text)
    {
        // Reativa todos os objetos Text
        foreach (Text t in texts)
        {
            t.gameObject.SetActive(true);
        }

        text.gameObject.SetActive(true);

        if (text == null)
        {
            Debug.LogError("Text object is null!");
            return;
        }

        // Desativa todos os objetos Text, exceto o objeto Text selecionado
        foreach (Text t in texts)
        {
            if (t != text)
            {
                t.gameObject.SetActive(false);
            }
        }
    }
}