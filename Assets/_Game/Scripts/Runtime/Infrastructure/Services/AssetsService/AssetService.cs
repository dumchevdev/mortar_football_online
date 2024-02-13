using UnityEngine;

namespace Runtime._Game.Scripts.Runtime.Infrastructure.Services.AssetsService
{
    public class AssetService : IAssetService
    {
        GameObject IAssetService.GetPrefab(string path)
        {
            return Resources.Load<GameObject>(path);
        }
    }
}