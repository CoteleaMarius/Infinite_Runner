using UnityEngine;

namespace _InfiniteRunner.Scripts
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float movementSpeed, sideSpeed, gravity, lineDistance;
        [SerializeField] private int linesToMove = 1;
        private CharacterController _characterController;

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            _characterController.Move(new Vector3(0, gravity, movementSpeed) * Time.deltaTime);
            Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
            if (linesToMove == 0)
            {
                targetPosition += Vector3.left * lineDistance;
            }else if (linesToMove == 2)
            {
                targetPosition += Vector3.right * lineDistance;
            }

            transform.position = targetPosition;
        }

        public void MovementSide(bool isRight)
        {
            if (isRight)
            {
                if (linesToMove < 2) linesToMove++;
            }else
            {
                if(linesToMove > 0) linesToMove--;
            }
        }
        
    }
}
