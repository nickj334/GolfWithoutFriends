using UnityEngine;

public class TimedMovingPlatform : MonoBehaviour
{
    public float moveDistance = 2f;         // How far to move down
    public float moveSpeed = 1f;            // Speed of movement
    public float waitTimeAtTop = 5f;        // Time to wait before descending
    public float waitTimeAtBottom = 2f;     // Time to wait before ascending

    private Vector3 startPos;
    private Vector3 endPos;
    private bool movingDown = false;
    private bool isWaiting = false;

    void Start()
    {
        startPos = transform.position;
        endPos = startPos - Vector3.up * moveDistance;

        StartCoroutine(MoveLoop());
    }

    System.Collections.IEnumerator MoveLoop()
    {
        while (true)
        {
            // Wait at top
            yield return new WaitForSeconds(waitTimeAtTop);

            // Move down
            yield return StartCoroutine(MovePlatform(endPos));

            // Wait at bottom
            yield return new WaitForSeconds(waitTimeAtBottom);

            // Move back up
            yield return StartCoroutine(MovePlatform(startPos));
        }
    }

    System.Collections.IEnumerator MovePlatform(Vector3 targetPos)
    {
        while (Vector3.Distance(transform.position, targetPos) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos; // Snap to target
    }
}
