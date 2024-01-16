using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace LearnDOTween
{
    public class TestDoText : MonoBehaviour
    {
        [SerializeField] private Text text;

        private async void Start()
        {
            await TestDoTextFunc();
        }

        private async UniTask TestDoTextFunc()
        {
            string hello = "Hello World! Hello World! Hello World! Hello World! Hello World!";
            await UniTask.Delay(TimeSpan.FromSeconds(2f));
            text.DOText(hello, 5f);
        }
    }
}