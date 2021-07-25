using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HoverPauseGame : MonoBehaviour
{
    public GameObject panelUI;
    public bool pause;
    TextMeshProUGUI textUI;
    Button buttonUI;


    private void Start()
    {
        buttonUI = GetComponent<Button>();
        textUI = GetComponent<TextMeshProUGUI>();
        buttonUI.onClick.AddListener(Pause);
        panelUI.SetActive(false);
    }

    private void Pause()
    {
        if (!pause)
        {
            pause = true;
            textUI.text = ">";
            Time.timeScale = 0;
            panelUI.SetActive(true);
        }
        else
        {
            pause = false;
            textUI.text = "||";
            Time.timeScale = 1;
            panelUI.SetActive(false);
        }
    }
}
