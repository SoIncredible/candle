using UnityEngine;

namespace UI.UIFramework.Core
{
    public class UIManager : MonoBehaviour
    {
        public void Init()
        {
            Debug.Log($"执行UIManager初始化,UIManager挂载节点名称{transform.name}");
        }

        public void Release()
        {
        }
    }
}