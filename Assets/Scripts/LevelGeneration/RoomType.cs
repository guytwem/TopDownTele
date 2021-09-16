using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown.LevelGeneration
{
    public class RoomType : MonoBehaviour
    {
        public int type;

        public void RoomDestruction()
        {
            Destroy(gameObject);
        }
    } 
}

