using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBlockEffect : MonoBehaviour
{
    [SerializeField] private TextMesh _floatingTextPrefab;

    private void FloatingText(Vector3 position)
    {
        TextMesh floatingText = Instantiate(_floatingTextPrefab, position, Quaternion.identity, transform);
        floatingText.text = "+1";
        StartCoroutine(WaitAndDestroy(floatingText));
    }

    public void ShowFloatingText(Vector3 position)
    {
        if (_floatingTextPrefab)
        {
            FloatingText(position);
        }
    }

    IEnumerator WaitAndDestroy(TextMesh floatingText)
    {
        yield return new WaitForSeconds(1);
        Destroy(floatingText.gameObject);
    }
}
