using UnityEngine;

public class AddBlockEffect : MonoBehaviour
{
    [SerializeField] private TextMesh _floatingTextPrefab;

    private void FloatingText(Vector3 position)
    {
        TextMesh floatingText = Instantiate(_floatingTextPrefab, position, Quaternion.identity, transform);
        floatingText.text = "+1";
        Destroy(floatingText.gameObject,1);
    }

    public void ShowFloatingText(Vector3 position)
    {
        if (_floatingTextPrefab)
        {
            FloatingText(position);
        }
    }
}
