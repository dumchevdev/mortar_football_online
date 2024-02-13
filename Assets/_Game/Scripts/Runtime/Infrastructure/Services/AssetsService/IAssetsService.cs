using UnityEngine;

namespace Runtime._Game.Scripts.Runtime.Infrastructure.Services.AssetsService
{
    public interface IAssetService : IService
    {
        GameObject GetPrefab(string path);
    }
}
