using TMPro;
using UnityEngine;

namespace Utils
{
    public class DebugExt : Debug
    {
        public static string Log(string message, TextMeshProUGUI textMeshProUGUI)
        {
            textMeshProUGUI.text += "\n" + message;
            Log(message);
            return textMeshProUGUI.text;
        }
    }
}