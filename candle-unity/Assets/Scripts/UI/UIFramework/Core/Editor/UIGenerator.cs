using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

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

            var go = new GameObject("CandleTemplateUI");
            var rectTransform = go.AddComponent<RectTransform>();
            rectTransform.NormalizeRectTransform();

            go.AddComponent<Canvas>();
            go.AddComponent<GraphicRaycaster>();

            var go1 = new GameObject("True UI");
            go1.transform.SetParent(go.transform);
            go1.AddComponent<RectTransform>().NormalizeRectTransform();
            go1.AddComponent<Image>();

            string path = AssetDatabase.GUIDToAssetPath(selectedFolders[0]);
            PrefabUtility.SaveAsPrefabAsset(go1, $"{path}/{go1.name}.prefab", out var success);
            Object.DestroyImmediate(go);
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
    }
}