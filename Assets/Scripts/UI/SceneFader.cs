using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Ui
{
    public class SceneFader : MonoBehaviour
    {
        [SerializeField] private Image _fadeImage;
        [SerializeField] private AnimationCurve _curve;

        private void Start()
        {
            StartCoroutine(FadeIn());
        }

        public void FadeTo(int scene)
        {
            StartCoroutine(FadeOut(scene));
        }

        private IEnumerator FadeIn()
        {
            float time = 1f;

            while (time > 0f)
            {
                time -= Time.deltaTime;
                float alpha = _curve.Evaluate(time);
                _fadeImage.color = new Color(0f, 0f, 0f, alpha);
                yield return null;
            }
        }

        private IEnumerator FadeOut(int scene)
        {
            float time = 0f;

            while (time < 1f)
            {
                time += Time.deltaTime;
                float alpha = _curve.Evaluate(time);
                _fadeImage.color = new Color(0f, 0f, 0f, alpha);
                yield return null;
            }

            SceneManager.LoadScene(scene);
        }
    }
}