using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HyperCasualTest
{
    internal class LevelEnd
    {

        private GameObject _endCamera;
        private PlayerView _playerView;
        InputBase _input;

        internal LevelEnd(GameObject endCamera,PlayerView playerView, InputBase input)
        {
            _endCamera = endCamera;
            _playerView = playerView;
            _input = input;
        }
        internal void ShowEndLevel()
        {
            Object.Instantiate(Resources.Load("Prefabs/VFX/Confetti"),_playerView.transform.position,Quaternion.identity);
            _endCamera.SetActive(true);
            _input.Taped += RestartLevel;
        }

        void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}