using UnityEngine;
using UnityEngine.UI;

public class ReplaceFont : MonoBehaviour
{
    [SerializeField] private Font newFont; // сюда перетащи свой .ttf/.otf шрифт

    [ContextMenu("Заменить шрифты на сцене")]
    private void Replace()
    {
        if (newFont == null)
        {
            Debug.LogError("Шрифт не назначен!");
            return;
        }

        Text[] texts = FindObjectsOfType<Text>(true); // true = берём и скрытые объекты
        foreach (Text t in texts)
        {
            t.font = newFont;
        }

        Debug.Log($"Шрифт заменён у {texts.Length} объектов");
    }
}
