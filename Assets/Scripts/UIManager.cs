using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    private TextMeshProUGUI _scoreText;

    private void Start()
    {
        _scoreText = transform.Find("Score_Text").GetComponent<TextMeshProUGUI>();
    }

    public void UpdateCoinText(int i)
    {
        _scoreText.text = "Score: " + i;
    }
}
