using UnityEngine;

namespace Game.Core.PlayerControl
{
    public class InputManager : MonoBehaviour
    {
        private bool _inputJump;
        private float _inputMove;

        protected float MoveInput {
            get {
                return _inputMove = Input.GetAxis("Horizontal");
            }
        }
        protected bool JumpInput {
            get {
                if ((Input.GetKeyDown(KeyCode.Space)) || (Input.GetKeyDown(KeyCode.W))) _inputJump = true;
                else _inputJump = false;
                return _inputJump;
            }
        }
    }
}

