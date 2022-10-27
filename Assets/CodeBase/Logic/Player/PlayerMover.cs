using CodeBase.Services.Input;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic.Player
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField]
        private CharacterController _characterContoller;
        
        private float _movementSpeed;
    
        private IInputService _inputService;

        [Inject]
        private void Construct(IInputService inputService) =>
            _inputService = inputService;

        public void SetMovementSpeed(float speed) =>
            _movementSpeed = speed;
        
        private void Update()
        {
            Vector3 movementVector = _inputService.GetAxis();
            movementVector = new Vector3(movementVector.x, 0, movementVector.y);
            movementVector.Normalize();

            _characterContoller.Move(movementVector * (_movementSpeed * Time.deltaTime));
        }
    }
}
