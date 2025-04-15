using Unity.VisualScripting;
using UnityEngine;

public class SafeArea : MonoBehaviour
{
    private RectTransform rectTransform => transform as RectTransform;



    private void OnValidate()
    {
        ApplySafeAreaTop();
    }

    private void OnEnable()
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

        // 전체 화면 높이 대비 safeArea의 top margin 계산


        //// 상단 마진만큼 패딩을 줌
        rectTransform.offsetMax = new Vector2(rectTransform.offsetMax.x, -topMargin);
    }
}
