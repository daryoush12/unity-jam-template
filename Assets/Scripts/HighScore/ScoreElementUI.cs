using HighscoreModule;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreElementUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _positionLabel;
    [SerializeField] private TextMeshProUGUI _usernameLabel;
    [SerializeField] private TextMeshProUGUI _scoreLabel;

    [SerializeField] private Color first;
    [SerializeField] private Color second;
    [SerializeField] private Color third;
    [SerializeField] private Color defaultColor;

    [SerializeField] private Image _panel;

    public void SetScoreDetails(int position, Score score)
    {
        _positionLabel.text = $"{position}. ";
        _usernameLabel.text = score.username;
        _scoreLabel.text = $"{score.score} PTS";
    }

    private void SetVisual(int position)
    {
        switch (position)
        {
            case 1: break;
            case 2: break;
            case 3: break;
            default: break;
        }
    }
}
