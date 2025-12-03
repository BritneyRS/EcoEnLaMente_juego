using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour, IErasable
{
    public SpriteRenderer sr;
    private Color originalColor;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }

    public void Erase()
    {
        sr.color = Color.gray;
        StartCoroutine(Restore());
    }

    IEnumerator Restore()
    {
        yield return new WaitForSeconds(4f);
        sr.color = originalColor;
    }
}
