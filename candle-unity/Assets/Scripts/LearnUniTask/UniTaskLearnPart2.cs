using System;
using Cysharp.Threading.Tasks;
using Effect;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LearnUniTask
{
    public class UniTaskLearnPart2 : MonoBehaviour
    {
        [SerializeField] private Button delayFrameBtn;
        [SerializeField] private Button delaySecondBtn;

        [SerializeField] private Button clearBtn;
        [SerializeField] private TextMeshProUGUI logText;

        [SerializeField] private ShakeText shakeText;

        private void Awake()
        {
            delayFrameBtn.onClick.AddListener(OnClickDelayFrameBtn);
            delaySecondBtn.onClick.AddListener(OnClickDelaySecondBtn);
            clearBtn.onClick.AddListener(OnClickClearBtn);
            logText.text = string.Empty;
        }

        private async void OnClickDelayFrameBtn()
        {
            // TODO 完善打字机效果
            // TODO 将打字动画的协程转换为UniTask
            var text = DebugExt.Log($"开始测试DelayFrame,当前帧{Time.frameCount}", logText);
            StartCoroutine(shakeText.Print(text));
            await UniTask.DelayFrame(5);
            var text1 = DebugExt.Log($"DelayFrame测试结束,当前帧{Time.frameCount}", logText);
            // StartCoroutine(shakeText.Print(text1));
        }

        private async void OnClickDelaySecondBtn()
        {
            var text = DebugExt.Log($"开始测试DelaySecond,当前时间{Time.time}", logText);
            StartCoroutine(shakeText.Print(text));
            await UniTask.Delay(TimeSpan.FromSeconds(1));
            var text1 = DebugExt.Log($"DelaySecond测试结束,当前时间{Time.time}", logText);
            StartCoroutine(shakeText.Print(text1));
        }

        private void OnClickClearBtn()
        {
            logText.text = string.Empty;
        }
    }
}