using Assets.Scripts.Infrastructure.Services;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.States
{
    public class FactoryService : IFactoryService
    {
        private AssetProviderService _assetProviderService;

        public FactoryService(AssetProviderService assetProviderService)
        {
            _assetProviderService = assetProviderService;
        }

        public GameObject CreateUnit()
        {
            return _assetProviderService.Instantiate(AssetAddress.unit);
        }
    }
}
