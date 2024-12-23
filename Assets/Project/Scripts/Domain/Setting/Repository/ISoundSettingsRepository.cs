using System;
using Cysharp.Threading.Tasks;
using Project.Domain.Setting.Model;

namespace Project.Domain.Setting.Repository {

    public interface ISoundSettingsRepository{
        UniTask<SoundSettingsSet> LoadAsync();
        UniTask SaveAsync(SoundSettingsSet settings);
    }
}
