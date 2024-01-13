using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct MyRange<T>
{
    public T _min, _max;

    public MyRange(T min, T max)
    {
        _min = min;
        _max = max;
    }    
}


[System.Serializable]
public struct CutInfo
{    
    public ParticleSystem _particle;
}

[System.Serializable]
public struct AppearInfo
{
    public MyRange<Vector2> _direction;
    public MyRange<float> _strength;           
}

public class Shrimp : MonoBehaviour
{
    [SerializeField]
    private CutInfo _cutInfo;

    [SerializeField]
    private AppearInfo _appearInfo;
   

    private Image _image;
    private Rigidbody2D _rigidbody;
    private RectTransform _rectTransform;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _rectTransform = GetComponent<RectTransform>();
    }    

    public void Appear()
    {                

        Vector2 direction = new Vector2();
        direction.x = Random.Range(_appearInfo._direction._min.x, _appearInfo._direction._max.x);
        direction.y = Random.Range(_appearInfo._direction._min.y, _appearInfo._direction._max.y);

        var strength = Random.Range(_appearInfo._strength._min, _appearInfo._strength._max);

        _rigidbody.AddForce(direction * strength);
    }

    public void Cut()
    {        
        var effect = Instantiate(_cutInfo._particle,_rectTransform.position,Quaternion.identity);

        Destroy(this.gameObject);

        // await UniTask.Delay(System.TimeSpan.FromSeconds(effect.duration));        
    }
}
