using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutKnife : MonoBehaviour
{
    [SerializeField]
    private Vector2 _offset = new Vector2();

    [SerializeField]
    private RectTransform _rectTransform;

    [SerializeField]
    private GameObject _mousePressTrail;

    [SerializeField]
    private GameObject _defaultTrail;

    private bool _isMousePress = false;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var screen = new Vector2(Screen.width, Screen.height);
        var halfscreen = screen / 2.0f;

        var mousePosition = Input.mousePosition;
        mousePosition.x = Mathf.Clamp(mousePosition.x, -halfscreen.x, halfscreen.x);
        mousePosition.y = Mathf.Clamp(mousePosition.y, -halfscreen.y, halfscreen.y);

        Vector2 mousePositionInit = Input.mousePosition;
        _rectTransform.anchoredPosition = (mousePositionInit - halfscreen) + _offset;

        if (Input.GetMouseButton(0))
        {
            _mousePressTrail.SetActive(true);
            _defaultTrail.SetActive(false);

            _isMousePress = true;
        }
        else
        {
            _mousePressTrail.SetActive(false);
            _defaultTrail.SetActive(true);

            _isMousePress = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger");

        if (collision.CompareTag("shrimp") && _isMousePress)
        {
            Debug.Log("trigger shrimp");
            collision.GetComponent<Shrimp>().Cut();
        }
    }
}
