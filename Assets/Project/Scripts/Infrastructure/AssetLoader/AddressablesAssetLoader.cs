using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Project.Infrastructure.Common {
    
    public class AddressablesAssetLoader : IAssetLoader {
        public async UniTask<T> LoadAsync<T>(string assetPath) 
            where T : Object {

            var asset = await Addressables.LoadAssetAsync<T>(assetPath);

            return asset;
        }

        public void Unload<T>(T asset) where T : Object {
            Addressables.Release(asset);
        }
    }

}
