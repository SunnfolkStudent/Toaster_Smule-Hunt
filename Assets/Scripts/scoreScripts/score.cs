using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public Text text;

    private void Update()
    {
        text.text = scoreingAndDeactivating.score.ToString();
    }
}
