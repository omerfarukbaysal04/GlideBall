using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadCredits : MonoBehaviour
{
    public void OnTrigger2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            SceneManager.LoadScene("Credits");
        }
    }
}
