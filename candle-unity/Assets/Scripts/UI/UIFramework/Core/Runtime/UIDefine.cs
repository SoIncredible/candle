namespace UI.UIFramework.Core.Runtime
{
    public struct UIInfo
    {
        public readonly UIType UIType;

        public UIInfo(UIType uiType)
        {
            UIType = uiType;
        }
    }

    public enum UIType
    {
        None,
        Home,

        LearnUniTask,
        LearnDoTween,
    }
}