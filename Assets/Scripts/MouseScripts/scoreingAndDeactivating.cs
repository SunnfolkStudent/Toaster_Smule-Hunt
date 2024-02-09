using UnityEngine;

public class scoreingAndDeactivating : MonoBehaviour
{
    public static int score;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Smule"))
        {
            other.gameObject.SetActive(false);
            score += 50;
        }

        /*if (other.gameObject.CompareTag("SuckHazard"))
        {
            print("takeDamage");
        }*/
    }
}
