using TMPro;
using UnityEngine;

public class DebugExt : Debug
{
    public static void Log(string message, TextMeshProUGUI textMeshProUGUI)
    {
        textMeshProUGUI.text += "\n" + message;
        Log(message);
    }
}