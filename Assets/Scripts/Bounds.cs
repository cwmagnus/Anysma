using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Bounds of gameplay.
/// </summary>
public class Bounds : MonoBehaviour
{
    [SerializeField]
    private float outOfBoundsTimer;
    [SerializeField]
    private Text outOfBoundsMessage;

    private float originalBoundsTimer;

    private bool outOfBounds;

    /// <summary>
    /// Set up bounds.
    /// </summary>
    private void Start()
    {
        originalBoundsTimer = outOfBoundsTimer;
        outOfBounds = false;
    }

    /// <summary>
    /// Update out of bounds timer.
    /// </summary>
    private void Update()
    {
        if (outOfBounds)
        {
            outOfBoundsMessage.text = 
                string.Format("Out of bounds!\n\nGet back in {0}!", 
                Mathf.RoundToInt(outOfBoundsTimer));
            if (outOfBoundsTimer <= 0)
            {
                SceneManager.LoadScene("Lose");
            }
            else
            {
                outOfBoundsTimer -= Time.deltaTime;
            }
        }
        else
        {
            outOfBoundsMessage.text = "";
            outOfBoundsTimer = originalBoundsTimer;
        }
    }

    /// <summary>
    /// Exit bounds.
    /// </summary>
    /// <param name="other">Thing leaving bounds.</param>
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            outOfBounds = true;
        }
    }

    /// <summary>
    /// Enter back into bounds.
    /// </summary>
    /// <param name="other">Thing in bounds.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            outOfBounds = false;
        }
    }
}
