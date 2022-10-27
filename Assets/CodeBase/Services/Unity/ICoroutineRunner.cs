using System.Collections;
using UnityEngine;

namespace CodeBase.Services.Unity
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator enumerator);
        void StopCoroutine(IEnumerator enumerator);
    }
}