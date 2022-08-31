using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.AllServices
{
    public class AllServices
    {
        private static AllServices _instance;
        public static AllServices Container => _instance ?? ( _instance = new AllServices() );

        private AllServices()
        {
        }

        public void RegisterService<TService>(TService service) where TService : IService =>
            Implementation<TService>.ServiceInstance = service;

        public TService GetService<TService>() where TService : IService =>
            Implementation<TService>.ServiceInstance;

        private static class Implementation<TService>
        {
            public static TService ServiceInstance;
        }
    }
}