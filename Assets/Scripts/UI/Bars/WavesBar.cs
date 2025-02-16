using LogicGame;
using UnityEngine;

namespace UI.Bars
{
    public class WavesBar : Bar
    {
        [SerializeField] private WaveSpawner _waveSpawner;

        private void OnEnable()
        {
            Slider.value = 0;
            _waveSpawner.WaveChanger += OnValueChanger;
        }

        private void OnDisable()
        {
            _waveSpawner.WaveChanger -= OnValueChanger;
        }
    }
}