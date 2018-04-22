using UnityEngine;
using UnityEngine.SceneManagement;

namespace Anysma
{
    /// <summary>
    /// Check if the player made it home.
    /// </summary>
    public class AnysmaWin : MonoBehaviour
    {
        /// <summary>
        /// Check win conditions.
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                SceneManager.LoadScene("Win");
            }
        }
    }
}