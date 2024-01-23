using UnityEngine;

namespace UI.Extension.InfiniteLoopList
{
    public class LoopViewItem
    {
        public GameObject Obj { get; }
        public object Param { get; }

        public LoopViewItem(GameObject obj, object param)
        {
            Obj = obj;
            Param = param;
        }
    }
}