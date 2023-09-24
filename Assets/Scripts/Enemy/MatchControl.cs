using System.Collections;
using System.Collections.Generic;
using Enemy;
using UnityEngine;


namespace Enemy
{
    public class MatchControl : MonoBehaviour
    {
        [SerializeField]
        private MatchInstance _matchInstance;

        [SerializeField]
        private GameObject _player;

        private void Awake()
        {
            _matchInstance.Reset();
            _matchInstance.Player = _player;
        }
        
        private void Update()
        {
            _matchInstance.AddTime(Time.deltaTime);
        }
    }
 
}
