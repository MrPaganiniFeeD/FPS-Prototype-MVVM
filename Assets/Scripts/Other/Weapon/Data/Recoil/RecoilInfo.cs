using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player.Weapon.Recoil
{
    [Serializable]
    public class RecoilInfo : IRecoilInfo
    {
        [SerializeField] private AnimationCurve _curve;

        [FormerlySerializedAs("_timeSmoothX")] [SerializeField] private int _timeSmooth;
        [SerializeField] private float _smoothX;
        [SerializeField] private float _smoothY;
        
        [SerializeField] private float x;
        [SerializeField] private float y;
        [SerializeField] private float z;
        
        
        public bool IsRecoil { get; set; }
        public IEnumerable<float> Points => ConvertCurve(_curve);
        public int TimeSmooth => _timeSmooth;
        public float SmoothX => _smoothX;
        public float SmoothY => _smoothY;

        public float X => x;
        public float Y => y;
        public float Z => z;

        public IEnumerable<float> ConvertCurve<T>(T curve) where T : AnimationCurve
        {
            var convertArray = new List<float>();
            for (var i = 0; i < curve.length; i++)
            {
                convertArray.Add(curve[i].value);
            }
            convertArray.Reverse();
            return convertArray;
        }
    }
}