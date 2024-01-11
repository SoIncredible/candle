using Cysharp.Threading.Tasks;
using UnityEngine;

namespace LearnUniTask
{
    public class UniTaskAsyncSampleBase
    {
        public async UniTask<Object> LoadAsync<T>(string path) where T : Object
        {
            var asyncOperation = Resources.LoadAsync<T>(path);
            return (await asyncOperation);
        }
    }
}