using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace LearnDOTween
{
    public class DOTweenLearn : MonoBehaviour
    {
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private Button clickBtn;

        private Vector3 _originPos;

        private void Awake()
        {
            _originPos = rectTransform.localPosition;
            clickBtn.onClick.AddListener(OnClickBtn);
        }


        private void OnClickBtn()
        {
            var nowPosY = _originPos.y + rectTransform.rect.size.y;
            rectTransform.localPosition = new Vector3(_originPos.x, nowPosY, _originPos.z);
            rectTransform.DOLocalMove(_originPos, 0.3f).SetEase(Ease.OutQuad);
        }
    }
}