using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerDeath : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Death();
    }
    public void Death()
    {

        SceneManager.LoadScene(0);
    }

}
