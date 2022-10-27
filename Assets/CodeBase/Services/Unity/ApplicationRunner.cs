using UnityEngine;

namespace CodeBase.Services.Unity
{
    public class ApplicationRunner : IApplicationRunner
    {
        public void Quit()
        {
            Application.Quit();
        }
    }
}