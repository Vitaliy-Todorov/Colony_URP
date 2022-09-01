using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services
{
    public interface IFactoryService : IService
    {
        GameObject CreateUnit();
    }
}