using TMPro;
using UnityEngine;

public class DebugExt : Debug
{
    public static string Log(string message, TextMeshProUGUI textMeshProUGUI)
    {
        // textMeshProUGUI.text += "\n" + message;
        Log(message);
        return "\n" + message;
    }
}