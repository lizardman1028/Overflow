using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingNumber2D : MonoBehaviour
{

    public float lifeTime = 2f;           // total lifetime
    public float floatAmplitudeX = 0.2f;  // small horizontal drift
    public float floatSpeed = 1f;         // speed of horizontal drift

    private Vector3 startPos;             // initial spawn position
    private float elapsedTime;
    private float phaseOffset;            // random offset for gentle sway
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        // Gentle horizontal sway
        float offsetX = Mathf.Sin(elapsedTime * floatSpeed + phaseOffset) * floatAmplitudeX;
        transform.position = new Vector3(startPos.x + offsetX, startPos.y, startPos.z);

        // Fade out over lifetime
        float remaining = Mathf.Clamp01(lifeTime - elapsedTime);
        if (sr != null)
        {
            Color c = sr.color;
            c.a = remaining; // simple fade out
            sr.color = c;
        }

        // Destroy when done
        if (elapsedTime >= lifeTime)
            Destroy(gameObject);
    }

    public void SetNumber(Sprite numberSprite)
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = numberSprite;

        startPos = transform.position;
        elapsedTime = 0f;
        phaseOffset = Random.Range(0f, Mathf.PI * 2); // randomize motion
    }
}
