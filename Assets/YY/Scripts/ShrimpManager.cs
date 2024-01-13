using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Triggers;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

[System.Serializable]
public struct TweenParameter
{
    public float _duration;
    public float _delay;
    public Ease _ease;
}

public class ShrimpManager : MonoBehaviour
{
    [SerializeField]
    private List<Shrimp> shrimpList;

    [SerializeField]
    private int _appearCount = 10;

    [SerializeField]
    private int _secondAppearCount = 20;

    [SerializeField]
    private int _thirdAppearCount = 30;

    [SerializeField]
    private MyRange<float> _appearDelay = new MyRange<float>(0.1f,0.8f);

    [SerializeField]
    private MyRange<float> _secoundAppearDelay = new MyRange<float>(0.1f, 0.5f);

    [SerializeField]
    private MyRange<float> _thirdAppearDelay = new MyRange<float>(0.1f, 0.2f);

    [SerializeField]
    private MyRange<float> _appearPositionX;

    [SerializeField]
    private MyRange<float> _appearSize;

    [SerializeField]
    private float _appearPositionY;

    [SerializeField]
    private RectTransform _shrimpDeployArea;

    [SerializeField]
    private TextMeshProUGUI _finishText;
    private RectTransform _finishTextRT;

    [SerializeField]
    private TweenParameter _finishTweenParameter = new TweenParameter()
    {
        _delay = 0.0f,
        _duration = 1.0f,
        _ease = Ease.Linear
    };

    [SerializeField]
    private RectTransform _finishEffectDeploy;

    [SerializeField]
    private ParticleSystem _finishEffect;

    [SerializeField]
    private RestShrimp _restShrimp;

    [SerializeField]
    private AudioSource _bgmSource;

    [SerializeField]
    private AudioSource _resultSource;

    [SerializeField]
    private TextMeshProUGUI _startText;

    [SerializeField]
    private TextMeshProUGUI _waveText;

    private RectTransform _waveTextRT;

    private void Awake()
    {
        _finishTextRT = _finishText.GetComponent<RectTransform>();
        _waveTextRT = _waveText.GetComponent<RectTransform>();
    }    

    // Start is called before the first frame update
    async void Start()
    {
        _finishTextRT.localScale = Vector3.zero;
        _waveTextRT.localScale = Vector3.zero;

        _startText.GetComponent<RectTransform>().DOScale(0.75f, 1.0f).SetLoops(-1, LoopType.Yoyo);

        // 左クリックするまで待つ       
        await UniTask.WaitUntil(() => Input.GetMouseButtonDown(0));

        _startText.gameObject.SetActive(false);

        _waveText.text = "1 Wave !";

        var sequence = DOTween.Sequence();

        sequence.Append(_waveTextRT.DOScale(1.0f, _finishTweenParameter._duration)
            .SetDelay(_finishTweenParameter._delay)
            .SetEase(_finishTweenParameter._ease));

        sequence.Append(_waveTextRT.DOScale(0.0f, _finishTweenParameter._duration)
           .SetDelay(_finishTweenParameter._delay + 0.5f)
           .SetEase(_finishTweenParameter._ease));

        for (int i=0;i<_appearCount;i++)
        {
            var position = new Vector2(Random.Range(_appearPositionX._min, _appearPositionX._max), _appearPositionY);

            _restShrimp.SetRestCount(i + 1, _appearCount);

            var shrimp = Instantiate(shrimpList[Random.Range(0, shrimpList.Count - 1)], _shrimpDeployArea);
            var rectTransform = shrimp.GetComponent<RectTransform>();
            rectTransform.localPosition = Vector3.zero;
            rectTransform.anchoredPosition = position;
            rectTransform.localScale = Vector3.one * Random.Range(_appearSize._min, _appearSize._max);

            shrimp.Appear();

            float delay = Random.Range(_appearDelay._min,_appearDelay._max);
            await UniTask.Delay(System.TimeSpan.FromSeconds(delay));
        }
        _waveText.text = "2 Wave !";

        sequence = DOTween.Sequence();

        sequence.Append( _waveTextRT.DOScale(1.0f, _finishTweenParameter._duration)
            .SetDelay(_finishTweenParameter._delay)
            .SetEase(_finishTweenParameter._ease));

        sequence.Append(_waveTextRT.DOScale(0.0f, _finishTweenParameter._duration)
           .SetDelay(_finishTweenParameter._delay + 0.5f)
           .SetEase(_finishTweenParameter._ease));

        // 2週目
        for (int i = 0; i < _secondAppearCount; i++)
        {
            var position = new Vector2(Random.Range(_appearPositionX._min, _appearPositionX._max), _appearPositionY);

            _restShrimp.SetRestCount(i + 1, _secondAppearCount);

            var shrimp = Instantiate(shrimpList[Random.Range(0, shrimpList.Count - 1)], _shrimpDeployArea);
            var rectTransform = shrimp.GetComponent<RectTransform>();
            rectTransform.localPosition = Vector3.zero;
            rectTransform.anchoredPosition = position;
            rectTransform.localScale = Vector3.one * Random.Range(_appearSize._min, _appearSize._max);

            shrimp.Appear();

            float delay = Random.Range(_secoundAppearDelay._min, _secoundAppearDelay._max);
            await UniTask.Delay(System.TimeSpan.FromSeconds(delay));
        }

        _waveText.text = "3 Wave !";

        sequence = DOTween.Sequence();

        sequence.Append(_waveTextRT.DOScale(1.0f, _finishTweenParameter._duration)
            .SetDelay(_finishTweenParameter._delay)
            .SetEase(_finishTweenParameter._ease));

        sequence.Append(_waveTextRT.DOScale(0.0f, _finishTweenParameter._duration)
           .SetDelay(_finishTweenParameter._delay + 0.5f)
           .SetEase(_finishTweenParameter._ease));

        // 3週目
        for (int i = 0; i < _thirdAppearCount; i++)
        {
            var position = new Vector2(Random.Range(_appearPositionX._min, _appearPositionX._max), _appearPositionY);

            _restShrimp.SetRestCount(i + 1, _thirdAppearCount);

            var shrimp = Instantiate(shrimpList[Random.Range(0, shrimpList.Count - 1)], _shrimpDeployArea);
            var rectTransform = shrimp.GetComponent<RectTransform>();
            rectTransform.localPosition = Vector3.zero;
            rectTransform.anchoredPosition = position;
            rectTransform.localScale = Vector3.one * Random.Range(_appearSize._min, _appearSize._max);

            shrimp.Appear();

            float delay = Random.Range(_thirdAppearDelay._min, _thirdAppearDelay._max);
            await UniTask.Delay(System.TimeSpan.FromSeconds(delay));
        }

        // 終了時エフェクト
        Instantiate(_finishEffect, _finishEffectDeploy);

        _bgmSource.volume = 0.35f;
        _resultSource.Play();

        

        //  登場
        _finishTextRT.DOScale(1.0f, _finishTweenParameter._duration)
            .SetDelay(_finishTweenParameter._delay)
            .SetEase(_finishTweenParameter._ease);

        // 左クリックするまで待つ       
        await UniTask.WaitUntil(() => Input.GetMouseButtonDown(0));       

        _finishTextRT.DOScale(0.0f, _finishTweenParameter._duration)
            .SetDelay(_finishTweenParameter._delay + 0.5f)
            .SetEase(_finishTweenParameter._ease);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
