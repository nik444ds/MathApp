using UnityEngine;
using UnityEngine.UI;

public class ButtonClose : MonoBehaviour
{
    public GameObject panel;
    public AudioSource buttonSound; // Referência ao AudioSource
    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(TogglePanel);
    }

    public void TogglePanel()
    {
        panel.SetActive(!panel.activeSelf);
        buttonSound.Play(); // Reproduz o som do botão
    }
}