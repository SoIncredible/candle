using System;
using UnityEngine;
using UnityEngine.LowLevel;

namespace LearnUniTask
{
    public class UniTaskInUnityFunc : MonoBehaviour
    {
        private void Start()
        {
        }

        private void InjectFunction()
        {
            PlayerLoopSystem playerLoopSystem = PlayerLoop.GetCurrentPlayerLoop();
        }

        private void OnClickDelaySecond()
        {
        }

        private void OnClickDelayFrame()
        {
        }
    }
}