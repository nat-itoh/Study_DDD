using Cysharp.Threading.Tasks;
using Object = UnityEngine.Object;

namespace Project.Infrastructure.Common {

    public interface IAssetLoader {
        UniTask<T> LoadAsync<T>(string assetPath) where T : Object;
        void Unload<T>(T asset) where T : Object;
    }

}
