using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SafeArea : MonoBehaviour
{
    private RectTransform rectTransform => transform as RectTransform;


    private void Start()
    {
        ApplySafeAreaTop();
    }

    void ApplySafeAreaTop()
    {
        Rect safeArea = Screen.safeArea;
        float topMargin = Screen.height - (safeArea.y + safeArea.height);
        float bottomMargin = Screen.height - (safeArea.y + safeArea.height);

        //rectTransform.sizeDelta = new Vector2(safeArea.width, safeArea.height);
        //rectTransform.anchoredPosition = new Vector2(safeArea.position.x, safeArea.position.y - topMargin);

        // ��ü ȭ�� ���� ��� safeArea�� top margin ���


        //// ��� ������ŭ �е��� ��
        rectTransform.offsetMax = new Vector2(rectTransform.offsetMax.x, -topMargin);
        StartCoroutine(DelayRebuild());
        //LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
    }

    private IEnumerator DelayRebuild()
    {
        yield return new WaitForSeconds(0.1f);
        yield return null;
        yield return null;
        LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
    }
}
