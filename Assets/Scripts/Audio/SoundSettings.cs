using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Audio
{
    public class SoundSettings : MonoBehaviour
    {
        private const string MusicVolume = "MusicVolume";
        private const string EffectsVolume = "EffectsVolume";
        private const float DisabledVolume = -80f;
        private const float Zero = 0;

        [SerializeField] private Slider _musicSlider;
        [SerializeField] private Slider _effectsSlider;
        [SerializeField] private AudioMixer _audioMixer;

        private float _defaultVolume = 0.70f;
        private float _minimumVolume = -20f;

        private void OnEnable()
        {
            _musicSlider.onValueChanged.AddListener(OnSetMusicSlider);
            _effectsSlider.onValueChanged.AddListener(OnSetEffectsSlider);
        }

        private void OnDisable()
        {
            _musicSlider.onValueChanged.RemoveListener(OnSetMusicSlider);
            _effectsSlider.onValueChanged.RemoveListener(OnSetEffectsSlider);
        }

        private void Start()
        {
            if (PlayerPrefs.HasKey(MusicVolume) && PlayerPrefs.HasKey(EffectsVolume))
            {
                _musicSlider.value = PlayerPrefs.GetFloat(MusicVolume);
                _effectsSlider.value = PlayerPrefs.GetFloat(EffectsVolume);

                SetVolume(_musicSlider.value, MusicVolume);
                SetVolume(_effectsSlider.value, EffectsVolume);
            }
            else
            {
                _musicSlider.value = _defaultVolume;
                _effectsSlider.value = _defaultVolume;

                SetVolume(_musicSlider.value, MusicVolume);
                SetVolume(_effectsSlider.value, EffectsVolume);

                PlayerPrefs.SetFloat(MusicVolume, _defaultVolume);
                PlayerPrefs.SetFloat(EffectsVolume, _defaultVolume);
                PlayerPrefs.Save();
            }
        }

        private void SetVolume(float volume, string nameVolume)
        {
            float mixerVolume;
            PlayerPrefs.SetFloat(nameVolume, volume);
            PlayerPrefs.Save();

            if (volume == Zero)
            {
                mixerVolume = DisabledVolume;
            }
            else
            {
                mixerVolume = Mathf.Lerp(_minimumVolume, Zero, volume);
            }

            _audioMixer.SetFloat(nameVolume, mixerVolume);
        }

        private void OnSetMusicSlider(float volume)
        {
            _musicSlider.value = volume;
            SetVolume(volume, MusicVolume);
        }

        private void OnSetEffectsSlider(float volume)
        {
            _effectsSlider.value = volume;
            SetVolume(volume, EffectsVolume);
        }
    }
}