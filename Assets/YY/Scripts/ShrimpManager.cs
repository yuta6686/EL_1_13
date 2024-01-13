using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrimpManager : MonoBehaviour
{
    [SerializeField]
    private List<Shrimp> shrimpList;

    [SerializeField]
    private int _appearCount = 10;

    [SerializeField]
    private MyRange<float> _appearDelay = new MyRange<float>(0.1f,0.8f);

    [SerializeField]
    private MyRange<float> _appearPositionX;

    [SerializeField]
    private MyRange<float> _appearSize;

    [SerializeField]
    private float _appearPositionY;

    [SerializeField]
    private RectTransform _shrimpDeployArea;

    // Start is called before the first frame update
    async void Start()
    {
        for(int i=0;i<_appearCount;i++)
        {
            var position = new Vector2(Random.Range(_appearPositionX._min, _appearPositionX._max), _appearPositionY);

            var shrimp = Instantiate(shrimpList[Random.Range(0, shrimpList.Count - 1)], _shrimpDeployArea);
            var rectTransform = shrimp.GetComponent<RectTransform>();
            rectTransform.localPosition = Vector3.zero;
            rectTransform.anchoredPosition = position;
            rectTransform.localScale = Vector3.one * Random.Range(_appearSize._min, _appearSize._max);

            shrimp.Appear();

            float delay = Random.Range(_appearDelay._min,_appearDelay._max);
            await UniTask.Delay(System.TimeSpan.FromSeconds(delay));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
