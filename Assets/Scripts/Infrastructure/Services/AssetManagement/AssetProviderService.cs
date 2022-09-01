using Assets.Scripts.Infrastructure.Services;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.States
{
    public class AssetProviderService : IAssetProviderService
    {
        public GameObject Instantiate(string address)
        {
            GameObject prefab = Resources.Load<GameObject>(address);
            return Object.Instantiate(prefab);
        }
    }
}
