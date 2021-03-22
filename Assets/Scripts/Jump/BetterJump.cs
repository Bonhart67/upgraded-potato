using UnityEngine;

namespace Jump
{
    public class BetterJump : MonoBehaviour
    {
        public float fallMultiplier = 2.5f;
        public float lowJumpMultiplier = 2f;

        private Rigidbody2D rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (rb.velocity.y < -0.000001f)
            {
                rb.gravityScale = fallMultiplier;
            }
            else if (rb.velocity.y  > 0.000001f && !Input.GetButton("Jump"))
            {
                rb.gravityScale = lowJumpMultiplier;
            }
            else
            {
                rb.gravityScale = 5f;
            }
        }
    }
}
