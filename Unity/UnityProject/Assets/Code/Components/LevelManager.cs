using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Components
{
    public class LevelManager : MonoBehaviour
    {
        private int levelWidth;
        private int levelHeight;

        [SerializeField]
        private Transform grassTile;
        [SerializeField]
        public Transform wallsTile;

        [SerializeField]
        private Color grassColor;
        [SerializeField]
        private Color wallsColor;

        [SerializeField]
        private Texture2D levelTexture;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}