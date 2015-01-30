using System.Runtime.Serialization;

namespace TweetSharp
{
    [DataContract]
    public class TwitterClientInfo 
    {
        public virtual string ClientName { get; set; }
        public virtual string ClientVersion { get; set; }
        public virtual string ClientUrl { get; set; }
        public virtual string ConsumerKey { get; set; }
        public virtual string ConsumerSecret { get; set; }
        public virtual bool IncludeEntities { get; set; }
        public virtual bool IncludeRetweets { get; set; }
    }
}