using UnityEngine;
using TMPro;

namespace Mirror.Examples.Pong
{
    public class Player : NetworkBehaviour
    {
        [SyncVar]
        public int score = 0;

        public TextMeshProUGUI scoreText;

        public float speed = 30;
        public Rigidbody2D rigidbody2d;

        // need to use FixedUpdate for rigidbody
        void FixedUpdate()
        {
            // only let the local player control the racket.
            // don't control other player's rackets
            if (isLocalPlayer)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    score++;
                }
                scoreText.text = score.ToString();
                rigidbody2d.velocity = speed * Time.fixedDeltaTime * new Vector2(0, Input.GetAxisRaw("Vertical"));
            }
        }
    }
}
