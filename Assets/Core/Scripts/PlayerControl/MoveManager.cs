using Game.Core.Colorize;
using UnityEngine;

namespace Game.Core.PlayerControl
{
    public class MoveManager : InputManager
    {
        [SerializeField] GameObject player;
        [SerializeField] GameObject playerRender;
        [SerializeField] Rigidbody2D _rb;
        [SerializeField] GameObject rayPosLeft;
        [SerializeField] GameObject rayPosRight;
        [SerializeField] Animator animator;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpPower;
        [SerializeField] private float _jumpRayDist;
        private bool _canJump;

        private void Update() {
            RayCheckGround();
            CheckJump();
        }
        private void FixedUpdate() { 
            CheckMove(); 
        }
        private void CheckJump() {
            if (_canJump && JumpInput) {
                _rb.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
                _canJump = false;
            }
        }
        private void CheckMove() {
            _rb.velocity = new Vector2(MoveInput * _speed, _rb.velocity.y);
            if (MoveInput > 0) playerRender.transform.localScale = new Vector3(-1,1,1);
            else if (MoveInput < 0) playerRender.transform.localScale = new Vector3(1,1,1);
        }
        private void RayCheckGround()   {
            RaycastHit2D hitGroundLeft = Physics2D.Raycast(rayPosLeft.transform.position, Vector2.down, _jumpRayDist, _layerMask);
            RaycastHit2D hitGroundRight = Physics2D.Raycast(rayPosRight.transform.position, Vector2.down, _jumpRayDist, _layerMask);

            Debug.DrawRay(rayPosLeft.transform.position, Vector2.down * hitGroundLeft.distance, Color.green);
            Debug.DrawRay(rayPosRight.transform.position, Vector2.down * hitGroundRight.distance, Color.blue);

            if (hitGroundLeft.collider || hitGroundRight.collider) {
                _canJump = true;
                animator.SetBool("InAir", false);
            }
            else {
                _canJump = false;
                animator.SetBool("InAir", true);
            }
        }
    }
}

