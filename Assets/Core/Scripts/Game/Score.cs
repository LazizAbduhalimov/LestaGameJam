using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TMP_Text Text;

    public void Start()
    {
        Bank.OnValueChangedEvent += UpdateText;
    }
    
    private void UpdateText(object o, int oldValue, int newValue)
    {
        Text.text = "Score" + newValue;
    }
}