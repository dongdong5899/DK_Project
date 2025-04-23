using UnityEngine;

namespace DKProject.UI
{
    public class LoadingCanvas : MonoBehaviour
    {
        public static LoadingCanvas instance;

        private void Awake()
        {
            if (instance != this) 
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
