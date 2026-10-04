using UnityEngine;

public class MovingPlatformChain : MonoBehaviour
{
    [Header("Lista piattaforme in ordine")]
    public Transform[] platforms;

    [Header("Punti A e B")]
    public Transform pointA;
    public Transform pointB;

    [Header("Velocità movimento")]
    public float speed = 2f;

    private int index = 0; // Coppia corrente
    private float t = 0f;
    private bool forward = true;

    void Update()
    {
        if (platforms.Length < 2) return;

        // Piattaforme attive nella coppia
        Transform p1 = platforms[index];
        Transform p2 = platforms[index + 1];

        // Movimento PingPong
        t += (forward ? 1 : -1) * speed * Time.deltaTime;
        float lerpVal = Mathf.Clamp01(t);

        // Muovo entrambe insieme
        p1.position = Vector3.Lerp(pointA.position, pointB.position, lerpVal);
        p2.position = Vector3.Lerp(pointA.position, pointB.position, lerpVal);

        // Se arrivo a un estremo → cambio coppia
        if (lerpVal >= 1f)
        {
            forward = false;
            NextPair();
        }
        else if (lerpVal <= 0f)
        {
            forward = true;
            NextPair();
        }
    }

    void NextPair()
    {
        // Next index
        index++;

        // Se arriva alla fine riparte
        if (index >= platforms.Length - 1)
            index = 0;

        // Reset interpolazione
        t = forward ? 0f : 1f;
    }
}
