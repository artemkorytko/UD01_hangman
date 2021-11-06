using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    private const string text_path = "word_rus";

    private string[] allWords;

    public string[] AllWords => AllWords;

    private void Awake()
    {
        var file = Resources.Load<TextAsset>(text_path);
        var text = file.text;
        string[] allWords = File.ReadAllLines(text);
    }
}
