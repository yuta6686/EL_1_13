using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class Presenter : MonoBehaviour
{
    [SerializeField]
    private Score _score;



    [SerializeField]
    private CutKnife _cutKnife;

    // Start is called before the first frame update
    void Start()
    {
        _cutKnife._CutCount            
            .Subscribe(isCut => 
            {
                _score.SetScore(isCut);
            })
            .AddTo(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
