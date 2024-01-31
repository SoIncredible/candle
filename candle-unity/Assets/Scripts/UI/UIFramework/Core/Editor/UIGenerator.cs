using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Directory = UnityEngine.Windows.Directory;

namespace UI.UIFramework.Core.Editor
{
    public static class UIGenerator
    {
        [MenuItem("Assets/CandleUI/CreateCandleUI", false, 4000)]
        public static void CreateCandleUI()
        {
            string[] selectedFolders = Selection.assetGUIDs;

            if (selectedFolders.Length != 1)
            {
                Debug.LogError("请正确选择要创建CandleUI的位置！！！");
                return;
            }

            // canvasNode只是用来辅助生成CandleUI的，在CandleUI生成完成后会自动删除 CandleUI的Prefab中不会有Canvas组件
            var canvasNode = new GameObject("CandleCanvas");
            var rectTransform = canvasNode.AddComponent<RectTransform>();
            rectTransform.NormalizeRectTransform();

            canvasNode.AddComponent<Canvas>();
            canvasNode.AddComponent<GraphicRaycaster>();

            var uiRoot = new GameObject("CandleTemplateUI");
            uiRoot.transform.SetParent(canvasNode.transform);
            uiRoot.AddComponent<RectTransform>().NormalizeRectTransform();
            uiRoot.AddComponent<Image>();

            string path = AssetDatabase.GUIDToAssetPath(selectedFolders[0]);
            PrefabUtility.SaveAsPrefabAsset(uiRoot, $"{path}/{uiRoot.name}.prefab", out var success);
            Object.DestroyImmediate(canvasNode);
            AssetDatabase.Refresh();
            if (success)
            {
                Debug.Log("Create Candle UI Success!!!");
            }
            else
            {
                Debug.LogError("Create Candle UI Fail!!!");
            }
        }

        private static void NormalizeRectTransform(this RectTransform rectTransform)
        {
            rectTransform.sizeDelta = Vector2.zero;
            rectTransform.anchorMin = Vector2.zero;
            rectTransform.anchorMax = Vector2.one;
            rectTransform.localScale = Vector3.one;
            rectTransform.pivot = new Vector2(0.5f, 0.5f);
            rectTransform.anchoredPosition = Vector2.zero;
        }

        // TODO 生成UI引用脚本
        // TODO 支持基于UniTask的异步操作
        private const string CandleUIGenPath = "Gen";
        private const string CandleUIPath = "Gen/UI";

        [MenuItem("Assets/CandleUI/CreateCandleBaseUI", false, 4000)]
        public static void GenerateCandleBaseUI()
        {
            string[] selection = Selection.assetGUIDs;

            // TODO 支持批量生成BaseUI
            if (selection.Length != 1)
            {
                Debug.LogError("[CandleUIGenerator]: 请选择正确的CandleUI！！！");
                return;
            }

            var uiGenPath = Path.Combine(Application.dataPath, CandleUIGenPath);
            var uiPath = Path.Combine(Application.dataPath, CandleUIPath);
            if (!Directory.Exists(uiGenPath))
            {
                Directory.CreateDirectory(uiGenPath);
                Directory.CreateDirectory(uiPath);
            }
            else
            {
                if (!Directory.Exists(uiPath))
                {
                    Directory.CreateDirectory(uiPath);
                }
            }
        }
    }
}