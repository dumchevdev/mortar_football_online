namespace Runtime._Game.Scripts.Runtime.Infrastructure.Services.PunService
{
    public class PlayerData
    {
        public bool IsReady;
        public int ColorId;
        
        public int Id { get; }
        public bool IsLocal { get; }
        public string Nickname { get; }
        public int Score { get; private set; }

        
        public PlayerData(int id, bool isLocal, string nickname)
        {
            Id = id;
            IsLocal = isLocal;
            Nickname = nickname;
            IsReady = false;
            ColorId = 0;
            Score = 0;
        }

        public int NextColorId()
        {
            ColorId++;
            if (ColorId >= 7)
                ColorId = 0;
            
            return ColorId;
        }

        public void Goal(int score)
        {
            Score += score;
        }

        public void UpdateScore(int score)
        {
            Score = score;
        }
    }
}