using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace HyperCasualTest
{
    internal class GameStarter : MonoBehaviour
    {
        [SerializeField] Waypoints waypoints;
        [SerializeField] CinemachineVirtualCamera virtualCamera;
        [SerializeField] GameObject endCamera;
        private ControllersUpdater _controllersUpdater;
        void Awake()
        {
            _controllersUpdater = new ControllersUpdater();
            waypoints.AddWayPoints();

            PlayerView playerView = Instantiate(Resources.Load<PlayerView>("Prefabs/MainHero"),waypoints.wayPoints[0].transform.position,Quaternion.identity);
            virtualCamera.Follow = playerView.transform;
            virtualCamera.LookAt = playerView.transform;           

            EnemyFactory enemyFactory = new EnemyFactory(_controllersUpdater);
            LevelSetUp levelSetUp = new LevelSetUp(waypoints.wayPoints, enemyFactory);

            InputBase input;

            #if UNITY_ANDROID
            input = new TouchInput();
            #endif

            #if UNITY_EDITOR
            input = new MouseInput();
            #endif

            PlayerConfig playerConfig = Resources.Load<PlayerConfig>("Configs/PlayerConfig");

            PlayerMove playerMove = new MoveByWaypoints(playerConfig.speed, playerConfig.turnSpeed, playerView, waypoints.wayPoints);

            LevelEnd levelEnd = new LevelEnd(endCamera,playerView,input);
            playerMove.EndReached += levelEnd.ShowEndLevel;

            PlayerShoot playerShoot = new ShootToDirection(playerView.gunPoint, new BulletFactory(_controllersUpdater), playerConfig.shootPower,input);
            PlayerController playerController = new PlayerController(playerView, input, playerMove, playerShoot);

            _controllersUpdater.AddController(playerController);
            

        }

        void Update()
        {
            _controllersUpdater.Update();
        }
        void FixedUpdate()
        {
            _controllersUpdater.FixedUpdate();
        }
        void LateUpdate()
        {
            _controllersUpdater.LateUpdate();
        }
    }

}
