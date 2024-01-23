using System.Collections.Generic;
using UnityEngine;

namespace UI.UIFramework.Core.Runtime
{
    public class UIManager : MonoBehaviour
    {
        public void Init()
        {
            InitUICanvasRoot();
            InitUIInfo();
        }

        public void Release()
        {
        }

        /// <summary>
        /// 存储注册界面的字典
        /// </summary>
        private readonly Dictionary<UIType, UIInfo> _uiInfoDic = new Dictionary<UIType, UIInfo>(128);

        /// <summary>
        /// 初始化根Canvas
        /// 目前只支持Overlay模式
        /// </summary>
        private static void InitUICanvasRoot()
        {
            GameObject canvasRoot = new GameObject("UICanvasRoot");
            Canvas canvas = canvasRoot.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            DontDestroyOnLoad(canvasRoot);
        }

        /// <summary>
        /// 初始化注册的界面
        /// </summary>
        private void InitUIInfo()
        {
            AddUIInfo(new UIInfo(UIType.Home));
        }

        private void AddUIInfo(UIInfo uiInfo)
        {
            if (_uiInfoDic.ContainsKey(uiInfo.UIType))
            {
                return;
            }

            _uiInfoDic.Add(uiInfo.UIType, uiInfo);
        }

        public BasePage GetPage(UIType uiType)
        {
            return default;
        }

        public void OpenPage(UIType uiType)
        {
            var page = GetPage(uiType);
            Debug.Log($"打开{uiType.ToString()}界面");
        }

        public void ClosePage()
        {
        }

        public void CloseAndDestroyPage()
        {
        }
    }
}