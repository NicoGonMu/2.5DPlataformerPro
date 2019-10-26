using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    private TextMeshProUGUI _scoreText;
    private TextMeshProUGUI _livesText;

    private void Start()
    {
        _scoreText = transform.Find("Score_Text").GetComponent<TextMeshProUGUI>();
        _livesText = transform.Find("Lives_Text").GetComponent<TextMeshProUGUI>();
    }

    public void UpdateCoinText(int i)
    {
        _scoreText.text = "Score: " + i;
    }

    public void UpdateLivesText(int i)
    {
        _livesText.text = "Lives: " + i;
    }
}
