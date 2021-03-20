using UnityEngine;

namespace Jump
{
    public class Jump : MonoBehaviour
    {
        [Range(1, 10)] public float jumpVelocity = 5f;
        public float groundedSkin = 0.05f;
        public LayerMask mask;

        private bool jumpRequest;
        private bool grounded;

        private Vector2 playerSize;
        private Vector2 boxSize;

        private void Awake()
        {
            playerSize = GetComponent<BoxCollider2D>().size;
            boxSize = new Vector2(playerSize.x, groundedSkin);
        }

        private void Update()
        {
            if (Input.GetButton("Jump") && grounded)
            {
                jumpRequest = true;
            }
        }


        private void FixedUpdate()
        {
            if (jumpRequest)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);

                jumpRequest = false;
                grounded = false;
            }
            else
            {
                Vector2 boxCenter = (Vector2) transform.position + Vector2.down * ((playerSize.y + boxSize.y) * 0.5f);
                grounded = (Physics2D.OverlapBox(boxCenter, boxSize, 0f, mask) != null);
                //print(Physics2D.OverlapBox(boxCenter, boxSize, 0f, mask).gameObject.name);
            }
        }
    }
}
