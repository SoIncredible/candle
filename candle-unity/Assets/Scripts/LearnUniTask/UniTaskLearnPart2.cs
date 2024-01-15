using System;
using Cysharp.Threading.Tasks;
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

        private void Awake()
        {
            delayFrameBtn.onClick.AddListener(OnClickDelayFrameBtn);
            delaySecondBtn.onClick.AddListener(OnClickDelaySecondBtn);
            clearBtn.onClick.AddListener(OnClickClearBtn);
            logText.text = string.Empty;
        }

        private async void OnClickDelayFrameBtn()
        {
            DebugExt.Log($"开始测试DelayFrame,当前帧{Time.frameCount}", logText);
            await UniTask.DelayFrame(5);
            DebugExt.Log($"DelayFrame测试结束，当前帧{Time.frameCount}", logText);
        }

        private async void OnClickDelaySecondBtn()
        {
            DebugExt.Log($"开始测试DelaySecond,当前时间{Time.time}", logText);
            await UniTask.Delay(TimeSpan.FromSeconds(1));
            DebugExt.Log($"DelaySecond测试结束，当前时间{Time.time}", logText);
        }

        private void OnClickClearBtn()
        {
            logText.text = string.Empty;
        }
    }
}