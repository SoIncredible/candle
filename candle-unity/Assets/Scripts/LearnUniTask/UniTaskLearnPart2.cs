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
            delayFrameBtn.enabled = false;
            var startText = DebugExt.Log($"开始测试DelayFrame,当前帧{Time.frameCount}", logText);
            await shakeText.Print(startText);
            await UniTask.DelayFrame(5);
            var endText = DebugExt.Log($"DelayFrame测试结束,当前帧{Time.frameCount}", logText);
            await shakeText.Print(endText);

            delayFrameBtn.enabled = true;
        }

        private async void OnClickDelaySecondBtn()
        {
            var startText = DebugExt.Log($"开始测试DelaySecond,当前时间{Time.time}", logText);
            await shakeText.Print(startText);
            await UniTask.Delay(TimeSpan.FromSeconds(1));
            var endText = DebugExt.Log($"DelaySecond测试结束,当前时间{Time.time}", logText);
            await shakeText.Print(endText);
        }

        private void OnClickClearBtn()
        {
            logText.text = string.Empty;
            shakeText.ResetIndex();
        }
    }
}