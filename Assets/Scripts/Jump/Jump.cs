using UnityEngine;

namespace Jump
{
    public class Jump : MonoBehaviour
    {
        [Range(1, 10)] public float jumpVelocity;
        public float groundedSkin = 0.05f;
        public LayerMask mask;
        private bool _jumpRequest;
        private bool _grounded;
        private Vector2 _playerSize;
        private Vector2 _boxSize;
        private Rigidbody2D _rb;
        private void Awake()
        {
            _playerSize = GetComponent<BoxCollider2D>().size;
            _boxSize = new Vector2(_playerSize.x, groundedSkin);
            _rb = GetComponent<Rigidbody2D>();
        }
        private void Update()
        {
            if (Input.GetButton("Jump") && _grounded)
            {
                _jumpRequest = true;
            }
        }
        private void FixedUpdate()
        {
            if (_jumpRequest)
            {
                jumpVelocity = Player.Instance.jumpHeight.Value;
                _rb.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
                _jumpRequest = false;
                _grounded = false;
            }
            else
            {
                Vector2 boxCenter = (Vector2) transform.position + Vector2.down * ((_playerSize.y + _boxSize.y) * 0.5f);
                _grounded = (Physics2D.OverlapBox(boxCenter, _boxSize, 0f, mask) != null);
            }
        }
    }
}
