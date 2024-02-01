using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HidePanelScript : MonoBehaviour
{
    public GameObject centerPanel;
    public UnityEvent onButtonClick;
    public AudioSource buttonSound;


    private void Start()
    {
        onButtonClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 panelPos = Camera.main.WorldToScreenPoint(centerPanel.transform.position);
        Vector3 panelSize = new Vector3(centerPanel.GetComponent<RectTransform>().sizeDelta.x, centerPanel.GetComponent<RectTransform>().sizeDelta.y, 0);

        Rect panelRect = new Rect(panelPos.x, panelPos.y, panelSize.x, panelSize.y);

        if (!panelRect.Contains(mousePos))
        {
            centerPanel.SetActive(false);
            buttonSound.Play();
        }
    }
}
