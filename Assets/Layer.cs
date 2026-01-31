using UnityEngine;

public class Layer : MonoBehaviour
{
    [Header("Capabilities")]
    public bool canToggle;
    public bool canMove;

    [Header("Move Data")]
    public float horizontal;
    public float vertical;

    private Rigidbody2D rb;
    Vector2 targetPos;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (!canMove) return;
        rb.MovePosition(targetPos);
    }

    public void MoveH(float value)
    {
        if (!canMove) return;
        horizontal = value;
        Apply();
    }

    public void MoveV(float value)
    {
        if (!canMove) return;
        vertical = value;
        Apply();
    }

    void Apply()
    {
        targetPos = new Vector2(
            horizontal * LayerManager.Instance.moveValue,
            vertical * LayerManager.Instance.moveValue
        );
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!this.gameObject.CompareTag("Spikes")) return;
        if (collision.gameObject.CompareTag("Player")) GameManager.Instance.OnReplayButtonClicked();
    }
}
