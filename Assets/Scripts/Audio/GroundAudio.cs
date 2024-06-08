using EnemyLogic;
using UnityEngine;

namespace Audio
{
    public class GroundAudio : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _victoryClip;
        [SerializeField] private AudioClip _defeatClip;
        [SerializeField] private AudioClip _fightClip;

        [SerializeField] private EnemyHandler _enemyHandler;
        [SerializeField] private HealthContainer _healthContainer;
        
        private void Start()
        {
            FightClip();
        }

        private void OnEnable()
        {
            _enemyHandler.AllEnemiesKilled += OnVictoryClip;
            _healthContainer.Died += OnDefeatClip;
        }

        private void OnDisable()
        {
            _enemyHandler.AllEnemiesKilled -= OnVictoryClip;
            _healthContainer.Died -= OnDefeatClip;
        }

        private void OnVictoryClip()
        {
            PlayAudioClip(_victoryClip, false);
        }

        private void OnDefeatClip()
        {
            PlayAudioClip(_defeatClip, false);
        }

        private void FightClip()
        {
            PlayAudioClip(_fightClip, true);


        }

        private void PlayAudioClip(AudioClip clip, bool flag)
        {
            _audioSource.clip = clip;
            _audioSource.loop = flag;
            _audioSource.Play();
        }
    }
}
