using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services
{
    public interface IAssetProviderService : IService
    {
        GameObject Instantiate(string address);
    }
}