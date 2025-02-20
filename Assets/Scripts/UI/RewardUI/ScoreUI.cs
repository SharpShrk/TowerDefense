using UnityEngine;
using Wallets;

namespace UI.RewardUI
{
    public class ScoreUI : RewardUI
    {
        [SerializeField] private Score _score;

        protected override void OnEnable()
        {
            _score.OnScoreChanged += SetValue;
        }

        protected override void OnDisable()
        {
            _score.OnScoreChanged -= SetValue;
        }
    }
}