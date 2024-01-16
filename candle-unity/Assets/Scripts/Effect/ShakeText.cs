using System.Collections;
using TMPro;
using UnityEngine;

namespace Effect
{
    public class ShakeText : MonoBehaviour
    {
        public TMP_Text destination; //输出处
        [Range(0, .05f)] public float shakeAmount = 0.25f; //抖动幅度
        [Range(1, 10)] public float speed = 5f; //抖动速度
        private bool _isUp = true; //上下抖动标志
        private int _currentLineNumber; //记录当前行号


        public IEnumerator Print(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                string res = $"<color=white>{text.Substring(0, i)}</color>";
                res += i == text.Length - 1
                    ? $"<color=white><size=0.25>{text[i]}</size></color>"
                    : $"<color=red><size=0.25>{text[i]}</size></color>"; //实现高亮打字机效果
                destination.text = res;
                ShakeChar();
                _isUp = !_isUp; //上下抖动标识更新
                yield return new WaitForSeconds(1 / speed);
            }
        }

        private void ShakeChar()
        {
            destination.ForceMeshUpdate(); //网格数据更新
            for (int i = 0; i < destination.textInfo.characterCount; i++) //遍历文本中所有字符
            {
                TMP_CharacterInfo currentChar = destination.textInfo.characterInfo[i]; //获取当前一个字符的信息
                if (currentChar.isVisible && currentChar.lineNumber == _currentLineNumber) //若字符可见且行号为当前打印字符行号
                {
                    Vector3[] verts = destination.textInfo.meshInfo[currentChar.materialReferenceIndex]
                        .vertices; //获取这个字符的顶点数据
                    for (int j = 0; j < 4; j++)
                        verts[currentChar.vertexIndex + j] +=
                            _isUp
                                ? new Vector3(0f, shakeAmount, 0f)
                                : new Vector3(0f, shakeAmount * -1, 0f); //对每个顶点进行偏移
                }
            }

            _currentLineNumber =
                destination.textInfo.characterInfo[destination.textInfo.characterCount - 1].lineNumber; //更新行号
            for (int i = 0; i < destination.textInfo.meshInfo.Length; i++) //写入配置的数据
            {
                var currentMesh = destination.textInfo.meshInfo[i];
                currentMesh.mesh.vertices = currentMesh.vertices;
                destination.UpdateGeometry(currentMesh.mesh, i);
            }
        }
    }
}