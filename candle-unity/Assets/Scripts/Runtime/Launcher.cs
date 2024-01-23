using System.Collections;
using UnityEngine;

namespace Runtime
{
    public class Launcher : MonoBehaviour
    {
        private IEnumerator Start()
        {
            GameManager.Create();
            yield return null;
            GameManager.Instance.Init();
        }
    }
}