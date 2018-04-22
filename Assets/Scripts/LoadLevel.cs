using UnityEngine.SceneManagement;
using UnityEngine;

/// <summary>
/// Loads levels.
/// </summary>
public class LoadLevel : MonoBehaviour
{
    /// <summary>
    /// Load a level.
    /// </summary>
    /// <param name="name">Level to load.</param>
    public void Load(string name)
    {
        SceneManager.LoadScene(name);
    }
}
