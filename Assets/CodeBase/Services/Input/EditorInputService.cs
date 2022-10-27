using CodeBase.StaticData.Strings;
using UnityEngine;

namespace CodeBase.Services.Input
{
    public class EditorInputService : IInputService
    {
        public Vector2 GetAxis()
        {
            Vector2 simpleInputAxis = SimpleInputAxis();
        
            if (simpleInputAxis == Vector2.zero)
                return new Vector2(UnityEngine.Input.GetAxis(InputConstants.Horizontal), UnityEngine.Input.GetAxis(InputConstants.Vertical));

            return simpleInputAxis;
        }
    
        private Vector2 SimpleInputAxis() =>
            new Vector2(SimpleInput.GetAxis(InputConstants.Horizontal), SimpleInput.GetAxis(InputConstants.Vertical));
    }
}
