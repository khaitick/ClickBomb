using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    public int difficulty;

    private Button button;
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        button.onClick.AddListener(SetDifficulty);
    }

    void SetDifficulty()
    {
        gm.GameStart(difficulty);
    }
}
