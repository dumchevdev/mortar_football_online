using Photon.Pun;
using UnityEngine;
using Runtime._Game.Scripts.Runtime.Infrastructure;

namespace Runtime._Game.Scripts.Runtime.Gameplay.Mortar
{
    public class MortarLocalRotationView : MonoBehaviour, IPunObservable
    {
        [SerializeField] private PhotonView photonView;
        
        private Quaternion _lastLocalRotation;
        private Quaternion _localRotationAtLastPacket;
        
        private float _currentTime;
        private double _currentPacketTime;
        private double _lastPacketTime;
        
        private void Update()
        {
            if (!photonView.IsMine)
            {
                RemoteLocalRotate();
            }
            else
            {
                LocalRotate();
            }
        }

        private void LocalRotate()
        {
            transform.localRotation = Quaternion.Euler(Game.InputService.Mouse);
        }

        private void RemoteLocalRotate()
        {
            var timeToReachGoal = _currentPacketTime - _lastPacketTime;
            if (timeToReachGoal == 0)
                return;
            
            _currentTime += Time.deltaTime;

            transform.localRotation = Quaternion.Lerp(_localRotationAtLastPacket, _lastLocalRotation,
                (float) (_currentTime / timeToReachGoal));
        }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                stream.SendNext(transform.localRotation);
            }
            else
            {
                _lastLocalRotation = (Quaternion)stream.ReceiveNext();

                _currentTime = 0.0f;
                _lastPacketTime = _currentPacketTime;
                _currentPacketTime = info.SentServerTime;
                _localRotationAtLastPacket = transform.localRotation;
            }
        }
    }
}
