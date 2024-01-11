using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace LearnUniTask
{
    public class UniTaskLearn : MonoBehaviour
    {
        // 加载文本 
        [SerializeField] private Button loadTextButton;
        [SerializeField] private Text contentText;

        [SerializeField] private Button loadSceneButton;
        [SerializeField] private Slider slider;
        [SerializeField] private Text progressText;

        [SerializeField] private Button webRequestButton;
        [SerializeField] private Image spriteImage;

        void Start()
        {
            loadTextButton.onClick.AddListener(OnClickLoadText);
            loadSceneButton.onClick.AddListener(OnClickLoadSceneBtn);
            webRequestButton.onClick.AddListener(OnClickWebRequest);
        }

        void Update()
        {
        }

        private async void OnClickLoadText()
        {
            // var resourceRequest = Resources.LoadAsync<TextAsset>("test");
            // var text = await resourceRequest;
            // contentText.text = ((TextAsset)text).text;

            UniTaskAsyncSampleBase uniTaskAsyncSampleBase = new UniTaskAsyncSampleBase();
            var re = uniTaskAsyncSampleBase.LoadAsync<TextAsset>("test");
            contentText.text = ((TextAsset)await re).text;
        }

        private async void OnClickLoadSceneBtn()
        {
            await SceneManager.LoadSceneAsync("Scenes/Main").ToUniTask((Progress.Create<float>((p) =>
            {
                slider.value = p;
                progressText.text = $"读取进度：{p * 100:F2}%";
            })));
        }

        private async void OnClickWebRequest()
        {
            var webRequest =
                UnityWebRequestTexture.GetTexture(
                    "https://s1.hdslb.com/bfs/static/jinkela/video/asserts/33-coin-ani.png");
            var result = (await webRequest.SendWebRequest());
            var texture = ((DownloadHandlerTexture)result.downloadHandler).texture;
            int totalSpriteCount = 24;
            int perSpriteWidth = texture.width / totalSpriteCount;
            Sprite[] sprites = new Sprite[totalSpriteCount];
            for (int i = 0; i < totalSpriteCount; i++)
            {
                sprites[i] = Sprite.Create(texture, new Rect(new Vector2(perSpriteWidth * i, 0), new Vector2(
                    perSpriteWidth, texture.height)), new Vector2(0.5f, 0.5f));
            }

            float perFrameTime = 0.1f;
            while (true)
            {
                for (int i = 0; i < totalSpriteCount; i++)
                {
                    await UniTask.Delay(TimeSpan.FromSeconds(perFrameTime));
                    var sprite = sprites[i];
                    spriteImage.sprite = sprite;
                }
            }
        }
    }
}