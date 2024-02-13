using Photon.Pun;
using UnityEngine;

namespace Runtime._Game.Scripts.Runtime.Gameplay.Gate
{
    public class GateLocalTransformView : MonoBehaviour, IPunObservable
    {
        [SerializeField] private PhotonView photonView;
        [SerializeField] private float speed;
        [SerializeField] private int firstPositionZ;
        [SerializeField] private int secondPositionZ;
        
        private Vector3 _lastLocalPosition;
        private Vector3 _localPositionAtLastPacket;

        private float _currentTime;
        private double _currentPacketTime;
        private double _lastPacketTime;
        
        private void Update()
        {
            if (!photonView.IsMine)
            {
                RemoteMove();
            }
            else
            {
                LocalMove();
            }

        }

        private void LocalMove()
        {
            float pingPong = Mathf.PingPong(Time.time * speed, 1);

            Vector3 gateLocalPosition = transform.localPosition;
            var firstPosition = new Vector3(gateLocalPosition.x, gateLocalPosition.y, firstPositionZ);
            var secondPosition = new Vector3(gateLocalPosition.x, gateLocalPosition.y, secondPositionZ);
        
            transform.localPosition = Vector3.Lerp(firstPosition, secondPosition, pingPong);
        }

        private void RemoteMove()
        {
            var timeToReachGoal = _currentPacketTime - _lastPacketTime;
            if (timeToReachGoal == 0)
                return;
            
            _currentTime += Time.deltaTime;

            transform.localPosition = Vector3.Lerp(_localPositionAtLastPacket, _lastLocalPosition, (float)(_currentTime / timeToReachGoal));
        }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                stream.SendNext(transform.localPosition);
            }
            else
            {
                _lastLocalPosition = (Vector3)stream.ReceiveNext();

                _currentTime = 0.0f;
                _lastPacketTime = _currentPacketTime;
                _currentPacketTime = info.SentServerTime;
                _localPositionAtLastPacket = transform.localPosition;
            }
        }
    }
}