using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using TweetSharp.Helpers;

namespace TweetSharp
{
    [DataContract]
    [DebuggerDisplay("{SenderScreenName} to {RecipientScreenName}:{Text}")]
    [JsonObject(MemberSerialization.OptIn)]
    public sealed class TwitterDirectMessage : PropertyChangedBase,
                                        IComparable<TwitterDirectMessage>,
                                        IEquatable<TwitterDirectMessage>,
                                        ITweetable
    {
        private long _id;
        private long _recipientId;
        private string _recipientScreenName;
        private TwitterUser _recipient;
        private long _senderId;
        private TwitterUser _sender;
        private string _senderScreenName;
        private string _text;
        private DateTime _createdDate;
        private TwitterEntities _entities;

        [DataMember]
        public long Id
        {
            get { return _id; }
            set
            {
                if (_id == value)
                {
                    return;
                }

                _id = value;
                OnPropertyChanged("Id");
            }
        }

        [DataMember]
        public long RecipientId
        {
            get { return _recipientId; }
            set
            {
                if (_recipientId == value)
                {
                    return;
                }

                _recipientId = value;
                OnPropertyChanged("RecipientId");
            }
        }

        [DataMember]
        public string RecipientScreenName
        {
            get { return _recipientScreenName; }
            set
            {
                if (_recipientScreenName == value)
                {
                    return;
                }

                _recipientScreenName = value;
                OnPropertyChanged("RecipientScreenName");
            }
        }

        [DataMember]
        public TwitterUser Recipient
        {
            get { return _recipient; }
            set
            {
                if (_recipient == value)
                {
                    return;
                }

                _recipient = value;
                OnPropertyChanged("Recipient");
            }
        }

        [DataMember]
        public long SenderId
        {
            get { return _senderId; }
            set
            {
                if (_senderId == value)
                {
                    return;
                }

                _senderId = value;
                OnPropertyChanged("SenderId");
            }
        }

        [DataMember]
        public TwitterUser Sender
        {
            get { return _sender; }
            set
            {
                if (_sender == value)
                {
                    return;
                }

                _sender = value;
                OnPropertyChanged("Sender");
            }
        }

        [DataMember]
        public string SenderScreenName
        {
            get { return _senderScreenName; }
            set
            {
                if (_senderScreenName == value)
                {
                    return;
                }

                _senderScreenName = value;
                OnPropertyChanged("SenderScreenName");
            }
        }

        [DataMember]
        public string Text
        {
            get { return _text; }
            set
            {
                if (_text == value)
                {
                    return;
                }
                _text = value;
                _entities = null;
                OnPropertyChanged("Text");
            }
        }

        private string _textAsHtml;
        public string TextAsHtml
        {
            get
            {
                return (_textAsHtml ?? (_textAsHtml = this.ParseTextWithEntities()));
            }
            set
            {
                _textAsHtml = value;
                OnPropertyChanged("TextAsHtml");
            }
        }

        public ITweeter Author
        {
            get { return Sender; }
        }

        [DataMember]
        [JsonProperty("created_at")]
        public DateTime CreatedDate
        {
            get { return _createdDate; }
            set
            {
                if (_createdDate == value)
                {
                    return;
                }

                _createdDate = value;
                OnPropertyChanged("CreatedDate");
            }
        }

        [DataMember]
        public TwitterEntities Entities
        {
            get { return _entities ?? (Entities = Text.ParseTwitterageToEntities()); }
            set
            {
                if (_entities != null)
                {
                    return;
                }

                _entities = value;
                OnPropertyChanged("Entities");
            }
        }

        #region IComparable<TwitterDirectMessage> Members

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. 
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public int CompareTo(TwitterDirectMessage other)
        {
            return other.Id == Id ? 0 : other.Id > Id ? -1 : 1;
        }

        #endregion

        #region IEquatable<TwitterDirectMessage> Members

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="obj">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="obj"/> parameter; otherwise, false.
        /// </returns>
        public bool Equals(TwitterDirectMessage obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            return obj.Id == Id;
        }

        #endregion

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>.</param>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            return obj.GetType() == typeof (TwitterDirectMessage) && Equals((TwitterDirectMessage) obj);
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(TwitterDirectMessage left, TwitterDirectMessage right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(TwitterDirectMessage left, TwitterDirectMessage right)
        {
            return !Equals(left, right);
        }

#if !Smartphone && !NET20
        [DataMember]
#endif
        public string RawSource { get; set; }
    }
}