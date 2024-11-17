using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    private int _score;
    private int _allScore;

    public event UnityAction<int> OnScoreChanged;

    public int ScorePoints => _score;

    public int AllScore => _allScore;

    private void Start()
    {
        _score = 0;
        OnScoreChanged?.Invoke(_score);
    }

    public void AddScore(int amount)
    {
        _score += amount;
        _allScore += amount;
        OnScoreChanged?.Invoke(_score);
    }

    public void Init(int score)
    {
        _allScore = score;
    }
}
