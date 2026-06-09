using UnityEngine;
using DG.Tweening;

public class UIPopup : MonoBehaviour
{
    private void OnEnable()
    {
        transform.localScale = Vector3.zero;

        Sequence seq = DOTween.Sequence();

        seq.Append(
            transform.DOScale(1.15f, 0.3f)
        );

        seq.Append(
            transform.DOScale(1f, 0.15f)
        );

        seq.SetUpdate(true);
    }
}