using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public Image[] images;
    public Text[] texts;

    private int currentImageIndex;
    private int currentTextIndex;

    private void Start()
    {
        StartCoroutine(Load());
    }

    private IEnumerator Load()
    {
        while (true)
        {
            currentImageIndex = Random.Range(0, images.Length);
            currentTextIndex = Random.Range(0, texts.Length);

            SetImage(images[currentImageIndex]);
            SetText(texts[currentTextIndex]);

            yield return new WaitForSeconds(2);
        }
    }

    private void SetImage(Image image)
    {
        image.gameObject.SetActive(true);
        GetComponent<Image>().sprite = image.sprite;

        if (image == null)
        {
            Debug.LogError("Image object is null!");
            return;
        }

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
        text.gameObject.SetActive(true);
        GetComponentInChildren<Text>().text = text.text;

        foreach (Text t in texts)
        {
            if (t != text)
            {
                t.gameObject.SetActive(false);
            }
        }
    }
}