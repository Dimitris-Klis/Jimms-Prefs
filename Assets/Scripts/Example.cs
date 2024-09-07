using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Example : MonoBehaviour
{
    public int minNumber = 0;
    public int maxNumber = 64;
    public int currentNumber = 0;
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        //load the number
        currentNumber = JimmsPrefs.GetInt("Number", 0);
        text.text = currentNumber.ToString();
    }
    public void RollNewNumber()
    {
        currentNumber = Random.Range(minNumber, maxNumber+1);
        
        //Store the number
        JimmsPrefs.SetInt("Number", currentNumber);

        text.text = currentNumber.ToString();
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}