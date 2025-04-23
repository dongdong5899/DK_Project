using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace DKProject.Chapter
{
    public class StageLoader : MonoBehaviour
    {
        [SerializeField] private AssetReference _stageAssetRef;
        private AsyncOperationHandle<GameObject> loadHandle;

        private void OnEnable()
        {
            LoadAsset();
        }

        private void LoadAsset()
        {
            loadHandle = _stageAssetRef.InstantiateAsync(transform);
            loadHandle.Completed += handle =>
            {

            };
        }
    }
}
