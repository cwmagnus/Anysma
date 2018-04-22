using UnityEngine;

namespace Anysma
{
    /// <summary>
    /// Handles turning the player.
    /// </summary>
    public class PlayerTurning : MonoBehaviour
    {
        [SerializeField]
        private float turnSpeed = 5.0f;

        // Time to turn
        private float turnTime;

        // Left and right modifier
        private int modifier = 0;

        private Rigidbody2D body;

        /// <summary>
        /// Get body reference.
        /// </summary>
        private void Start()
        {
            body = GetComponent<Rigidbody2D>();
        }

        /// <summary>
        /// Turn the player.
        /// </summary>
        private void FixedUpdate()
        {
            if (turnTime > 0)
            {
                float deltaMove = Time.deltaTime * turnSpeed * modifier;
                body.angularVelocity = deltaMove;
            }
            // Set movement time to 0 if lower than 0
            turnTime = (turnTime < 0) ? 0 : turnTime - Time.deltaTime;
        }

        /// <summary>
        /// Set the turn time.
        /// </summary>
        /// <param name="turnTime">New turning time.</param>
        public void SetTurnValue(int turnTime, int modifier)
        {
            this.turnTime = turnTime / 3.0f;
            this.modifier = modifier;
        }
    }
}
