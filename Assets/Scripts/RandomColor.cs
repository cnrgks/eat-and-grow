using UnityEngine;

public class RandomColor : MonoBehaviour
{
    void Start()
    {
        GetComponent<SpriteRenderer>().color = Color.HSVToRGB(Random.Range(0f, 1f), 1f, 1f);
    }
}
