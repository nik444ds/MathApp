using UnityEngine;
using UnityEngine.UI;

public class ButtonClose : MonoBehaviour
{


    public GameObject panel;
    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(TogglePanel);
    }

    public void TogglePanel()
    {
        panel.SetActive(!panel.activeSelf);
    }
}
