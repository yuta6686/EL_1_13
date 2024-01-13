using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RestShrimp : MonoBehaviour
{
    private TextMeshProUGUI _text;
    public void SetRestCount(int restCount,int appearCount)
    {
        _text.text = $"{restCount}/{appearCount}";
    }

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
