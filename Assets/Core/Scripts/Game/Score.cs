using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TMP_Text Text;

    public void Start()
    {
        Bank.OnValueChangedEvent += UpdateText;
        Bank.SetScore(this, 0);
    }

    public void OnDestroy()
    {
        
    }

    private void UpdateText(object o, int oldValue, int newValue)
    {
        Text.text = "Score: " + newValue;
    }
}