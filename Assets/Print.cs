using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Print : MonoBehaviour
{
    public TMP_Text text;
    public void PrintContent()
    {
        Debug.Log($"{text.text}");
    }
}
