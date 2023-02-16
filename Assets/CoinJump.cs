using UnityEngine;

public class CoinJump : MonoBehaviour
{
    public float jumpHeight = 0.5f;
    public float jumpDuration = 1f;

    private Vector2 startPosition;
    private float timeElapsed = 0f;
    public GameObject coin;
    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;
        float t = timeElapsed / jumpDuration;
        t = Mathf.Sin(t * Mathf.PI);
        transform.position = Vector2.Lerp(startPosition, startPosition + Vector2.up * jumpHeight, t);

        if (timeElapsed >= jumpDuration)
        {
            timeElapsed = 0f;
        }
        Destroy(coin, 6.5f);
      
    }
}