using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Components
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField]
        private Transform grassTile;
        [SerializeField]
        public Transform wallsTile;
        [SerializeField]
        public Transform playerTile;

        [SerializeField]
        private Color grassColor;
        [SerializeField]
        private Color wallsColor;
        [SerializeField]
        private Color spawnColor;

        [SerializeField]
        private Texture2D levelTexture;

        // Start is called before the first frame update
        void Start()
        {
            var lvlWidth = levelTexture.width;
            var lvlHeight = levelTexture.height;
            var texturePixelsArray = levelTexture.GetPixels();

            var colorTileMap = new Dictionary<Color, Transform>()
            {
                { grassColor, grassTile },
                { wallsColor, wallsTile },
                { spawnColor, playerTile },
            };

            for (int y = 0; y < lvlHeight; y++)
            {
                for (int x = 0; x < lvlWidth; x++)
                {
                    var pixel = texturePixelsArray[y * lvlWidth + x];
                    var texture = colorTileMap[pixel];

                    if (texture != null)
                    {
                        var transform = Instantiate(texture, new Vector3(x, y), Quaternion.identity);
                        transform.SetParent(this.transform);
                    }
                }
            }
        }
    }
}