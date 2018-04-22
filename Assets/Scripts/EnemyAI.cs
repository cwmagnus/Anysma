using UnityEngine;

namespace Anysma
{
    /// <summary>
    /// Enemy AI logic.
    /// </summary>
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField]
        private Transform target;
        [SerializeField]
        private float shootTime;
        private float originalShootTime;
        [SerializeField]
        private float speed;
        [SerializeField]
        private float rotationSpeed;

        private Rigidbody2D body;
        private WeaponSystem weaponSystem;

        private States state;

        enum States
        {
            Chase,
            Idle,
            Wander,
            Aggressive,
            LookTarget,
            AggressiveLook
        }

        /// <summary>
        /// Set up AI.
        /// </summary>
        private void Start()
        {
            body = GetComponent<Rigidbody2D>();
            weaponSystem = GetComponent<WeaponSystem>();
            state = States.Idle;
            originalShootTime = shootTime;
            shootTime = -1;
        }

        /// <summary>
        /// Check AI states.
        /// </summary>
        private void FixedUpdate()
        {
            CheckAround();
            switch (state)
            {
                case States.Chase:
                    Move();
                    LookAtTarget();
                    break;
                case States.Aggressive:
                    Move();
                    LookAtTarget();
                    Shoot();
                    break;
                case States.AggressiveLook:
                    LookAtTarget();
                    Shoot();
                    break;
                case States.LookTarget:
                    LookAtTarget();
                    break;

            }
            Debug.Log(state);
        }

        /// <summary>
        /// Move the ai.
        /// </summary>
        private void Move()
        {
            body.AddForce(transform.up * speed * Time.deltaTime);
        }

        /// <summary>
        /// Look at the target point.
        /// </summary>
        private void LookAtTarget()
        {
            // Look at the target
            var targetAngle = Mathf.Atan2(target.position.y - transform.position.y, 
                target.position.x - transform.position.x);
            targetAngle = targetAngle * (180 / Mathf.PI) - 90;
            body.MoveRotation(Mathf.LerpAngle(body.rotation, targetAngle, 
                Time.deltaTime * rotationSpeed));

            // Change state
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);
            if (hit)
            {
                if (hit.transform.tag == "Player")
                {
                    state = States.Aggressive;
                    if (hit.distance < 5)
                    {
                        state = States.AggressiveLook;
                    }
                }
                else
                {
                    state = States.Chase;
                }
            }
        }

        /// <summary>
        /// Shoot automatically over time.
        /// </summary>
        private void Shoot()
        {
            if (shootTime < 0)
            {
                weaponSystem.Fire();
                shootTime = originalShootTime;
            }
            else
            {
                shootTime -= Time.deltaTime;
            }
        }

        /// <summary>
        /// Check if the target is around.
        /// </summary>
        private void CheckAround()
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 7);
            foreach (Collider2D hit in hits)
            {
                if (hit.tag == "Player")
                {
                    if (state != States.AggressiveLook && state != States.Aggressive)
                    {
                        state = States.Chase;
                        break;
                    }
                }
            }
        }
    }
}
