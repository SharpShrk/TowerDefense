using EnemyLogic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    public class GroundAudio : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _victoryClip;
        [SerializeField] private AudioClip _defeatClip;
        [SerializeField] private AudioClip[] _fightClips;
        [SerializeField] private EnemyHandler _enemyHandler;
        [SerializeField] private HealthContainer _healthContainer;

        private Queue<AudioClip> _shuffledFightClips;

        private void Start()
        {
            ShuffleFightClips();
            PlayNextFightClip();
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

        private void ShuffleFightClips()
        {
            var clips = new List<AudioClip>(_fightClips);
            for (int i = clips.Count - 1; i > 0; i--)
            {
                int randomIndex = Random.Range(0, i + 1);
                (clips[i], clips[randomIndex]) = (clips[randomIndex], clips[i]);
            }
            _shuffledFightClips = new Queue<AudioClip>(clips);
        }

        private void PlayNextFightClip()
        {
            if (_shuffledFightClips.Count == 0)
            {
                ShuffleFightClips();
            }

            AudioClip nextClip = _shuffledFightClips.Dequeue();
            _audioSource.clip = nextClip;
            _audioSource.Play();

            StartCoroutine(WaitForClipToEnd(nextClip));
        }

        private IEnumerator WaitForClipToEnd(AudioClip clip)
        {
            yield return new WaitForSeconds(clip.length);
            PlayNextFightClip();
        }

        private void OnVictoryClip()
        {
            PlayAudioClip(_victoryClip, false);
        }

        private void OnDefeatClip()
        {
            PlayAudioClip(_defeatClip, false);
        }

        private void PlayAudioClip(AudioClip clip, bool flag)
        {
            _audioSource.clip = clip;
            _audioSource.loop = flag;
            _audioSource.Play();
        }
    }
}