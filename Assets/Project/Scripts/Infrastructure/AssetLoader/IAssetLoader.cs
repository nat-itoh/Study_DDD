using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Project.Infrastructure.Common {

    public interface IAssetLoader {
        UniTask<T> LoadAsync<T>(string assetPath) where T : Object;
        void Unload<T>(T asset) where T : Object;
    }

}
