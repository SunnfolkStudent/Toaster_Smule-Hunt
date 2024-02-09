using UnityEngine;

public class scoreingAndDeactivating : MonoBehaviour
{
    public static int score;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("smule"))
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
