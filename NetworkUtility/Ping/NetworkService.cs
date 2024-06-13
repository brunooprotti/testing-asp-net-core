using System.Net.NetworkInformation;

namespace NetworkUtility.Ping
{
    public class NetworkService
    {
        private readonly IDNS _DNS;

        public NetworkService(IDNS DNS)
        {
            _DNS = DNS;
        }

        public string SendPing()
        {
            //SearchDNS();
            //BuildPacket();
            var dnsSuccess = _DNS.SendDNS();

            if (dnsSuccess) return "Success: Ping sent!";
            else return "Failed: Ping not send!";

        }

        public int PingTimeOut(int a, int b)
        {
            return a + b;
        }

        public DateTime LastPingDate()
        {
            return DateTime.Now;
        }

        public PingOptions GetPingOptions()
        {
            return new PingOptions() 
            {
                DontFragment = true,
                Ttl = 1
            };
        }

        public IEnumerable<PingOptions> MostRecentPings()
        {
            IEnumerable<PingOptions> pings = new[] 
            {
                new PingOptions()
                {
                    DontFragment = true,
                    Ttl = 1
                },
                new PingOptions()
                {
                    DontFragment = true,
                    Ttl = 1
                },
                new PingOptions()
                {
                    DontFragment = true,
                    Ttl = 1
                }
            };

            return pings;
        }
    }
}
