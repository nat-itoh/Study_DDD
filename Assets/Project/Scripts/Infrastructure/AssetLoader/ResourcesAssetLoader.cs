using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Project.Infrastructure.Common {

    public class ResourcesAssetLoader : IAssetLoader {

        public async UniTask<T> LoadAsync<T>(string assetPath) where T : Object {
            var request = Resources.LoadAsync<T>(assetPath);
            await request; // ”ñ“¯Šúƒ[ƒh‚ÌŠ®—¹‚ğ‘Ò‚Â
            return request.asset as T;
        }

        public void Unload<T>(T asset) where T : Object {
            Resources.UnloadAsset(asset);
        }
    }
}
