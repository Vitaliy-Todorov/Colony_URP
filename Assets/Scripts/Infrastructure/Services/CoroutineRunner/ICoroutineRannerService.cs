using Assets.Scripts.Infrastructure.Services;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.States.CoroutineRunner
{
    public interface ICoroutineRannerService : IService
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}