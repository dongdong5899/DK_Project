using UnityEngine;

namespace DKProject.UI
{
    public class LoadingCanvas : MonoBehaviour
    {
        public static LoadingCanvas instance;

        private void Awake()
        {
            if(instance != null && instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                DontDestroyOnLoad(gameObject);
                instance = this;
            }
        }
    }
}
