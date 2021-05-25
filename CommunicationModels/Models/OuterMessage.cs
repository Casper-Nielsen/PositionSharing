// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: OuterMessage.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;

namespace CommunicationModels.Models
{
    /// <summary>Holder for reflection information generated from OuterMessage.proto</summary>
    public static partial class OuterMessageReflection
    {

        #region Descriptor
        /// <summary>File descriptor for OuterMessage.proto</summary>
        public static pbr::FileDescriptor Descriptor
        {
            get { return descriptor; }
        }
        private static pbr::FileDescriptor descriptor;

        static OuterMessageReflection()
        {
            byte[] descriptorData = global::System.Convert.FromBase64String(
                string.Concat(
                  "ChJPdXRlck1lc3NhZ2UucHJvdG8SGkNvbW11bmljYXRpb25Nb2RlbHMuTW9k",
                  "ZWxzGh9nb29nbGUvcHJvdG9idWYvdGltZXN0YW1wLnByb3RvIr4CCgxPdXRl",
                  "ck1lc3NhZ2USQwoFbVR5cGUYASABKA4yNC5Db21tdW5pY2F0aW9uTW9kZWxz",
                  "Lk1vZGVscy5PdXRlck1lc3NhZ2UuTWVzc2FnZVR5cGUSQwoFclR5cGUYAiAB",
                  "KA4yNC5Db21tdW5pY2F0aW9uTW9kZWxzLk1vZGVscy5PdXRlck1lc3NhZ2Uu",
                  "UmVxdWVzdFR5cGUSKQoFc3RhbXAYAyABKAsyGi5nb29nbGUucHJvdG9idWYu",
                  "VGltZXN0YW1wEg8KB21lc3NhZ2UYBCABKAwiPgoLTWVzc2FnZVR5cGUSCQoF",
                  "RVJST1IQABIMCghSRVNQT05TRRABEgsKB1JFUVVFU1QQAhIJCgVQVUxTRRAD",
                  "IigKC1JlcXVlc3RUeXBlEggKBE5PTkUQABIPCgtDUkVBVEVHUk9VUBABYgZw",
                  "cm90bzM="));
            descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
                new pbr::FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.TimestampReflection.Descriptor, },
                new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::CommunicationModels.Models.OuterMessage), global::CommunicationModels.Models.OuterMessage.Parser, new[]{ "MType", "RType", "Stamp", "Message" }, null, new[]{ typeof(global::CommunicationModels.Models.OuterMessage.Types.MessageType), typeof(global::CommunicationModels.Models.OuterMessage.Types.RequestType) }, null, null)
                }));
        }
        #endregion

    }
    #region Messages
    public sealed partial class OuterMessage : pb::IMessage<OuterMessage>
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
#endif
    {
        private static readonly pb::MessageParser<OuterMessage> _parser = new pb::MessageParser<OuterMessage>(() => new OuterMessage());
        private pb::UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pb::MessageParser<OuterMessage> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pbr::MessageDescriptor Descriptor
        {
            get { return global::CommunicationModels.Models.OuterMessageReflection.Descriptor.MessageTypes[0]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        pbr::MessageDescriptor pb::IMessage.Descriptor
        {
            get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public OuterMessage()
        {
            OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public OuterMessage(OuterMessage other) : this()
        {
            mType_ = other.mType_;
            rType_ = other.rType_;
            stamp_ = other.stamp_ != null ? other.stamp_.Clone() : null;
            message_ = other.message_;
            _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public OuterMessage Clone()
        {
            return new OuterMessage(this);
        }

        /// <summary>Field number for the "mType" field.</summary>
        public const int MTypeFieldNumber = 1;
        private global::CommunicationModels.Models.OuterMessage.Types.MessageType mType_ = global::CommunicationModels.Models.OuterMessage.Types.MessageType.Error;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public global::CommunicationModels.Models.OuterMessage.Types.MessageType MType
        {
            get { return mType_; }
            set
            {
                mType_ = value;
            }
        }

        /// <summary>Field number for the "rType" field.</summary>
        public const int RTypeFieldNumber = 2;
        private global::CommunicationModels.Models.OuterMessage.Types.RequestType rType_ = global::CommunicationModels.Models.OuterMessage.Types.RequestType.None;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public global::CommunicationModels.Models.OuterMessage.Types.RequestType RType
        {
            get { return rType_; }
            set
            {
                rType_ = value;
            }
        }

        /// <summary>Field number for the "stamp" field.</summary>
        public const int StampFieldNumber = 3;
        private global::Google.Protobuf.WellKnownTypes.Timestamp stamp_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public global::Google.Protobuf.WellKnownTypes.Timestamp Stamp
        {
            get { return stamp_; }
            set
            {
                stamp_ = value;
            }
        }

        /// <summary>Field number for the "message" field.</summary>
        public const int MessageFieldNumber = 4;
        private pb::ByteString message_ = pb::ByteString.Empty;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public pb::ByteString Message
        {
            get { return message_; }
            set
            {
                message_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other)
        {
            return Equals(other as OuterMessage);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(OuterMessage other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            if (ReferenceEquals(other, this))
            {
                return true;
            }
            if (MType != other.MType) return false;
            if (RType != other.RType) return false;
            if (!object.Equals(Stamp, other.Stamp)) return false;
            if (Message != other.Message) return false;
            return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode()
        {
            int hash = 1;
            if (MType != global::CommunicationModels.Models.OuterMessage.Types.MessageType.Error) hash ^= MType.GetHashCode();
            if (RType != global::CommunicationModels.Models.OuterMessage.Types.RequestType.None) hash ^= RType.GetHashCode();
            if (stamp_ != null) hash ^= Stamp.GetHashCode();
            if (Message.Length != 0) hash ^= Message.GetHashCode();
            if (_unknownFields != null)
            {
                hash ^= _unknownFields.GetHashCode();
            }
            return hash;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override string ToString()
        {
            return pb::JsonFormatter.ToDiagnosticString(this);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void WriteTo(pb::CodedOutputStream output)
        {
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
            output.WriteRawMessage(this);
#else
      if (MType != global::CommunicationModels.Models.OuterMessage.Types.MessageType.Error) {
        output.WriteRawTag(8);
        output.WriteEnum((int) MType);
      }
      if (RType != global::CommunicationModels.Models.OuterMessage.Types.RequestType.None) {
        output.WriteRawTag(16);
        output.WriteEnum((int) RType);
      }
      if (stamp_ != null) {
        output.WriteRawTag(26);
        output.WriteMessage(Stamp);
      }
      if (Message.Length != 0) {
        output.WriteRawTag(34);
        output.WriteBytes(Message);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
#endif
        }

#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output)
        {
            if (MType != global::CommunicationModels.Models.OuterMessage.Types.MessageType.Error)
            {
                output.WriteRawTag(8);
                output.WriteEnum((int)MType);
            }
            if (RType != global::CommunicationModels.Models.OuterMessage.Types.RequestType.None)
            {
                output.WriteRawTag(16);
                output.WriteEnum((int)RType);
            }
            if (stamp_ != null)
            {
                output.WriteRawTag(26);
                output.WriteMessage(Stamp);
            }
            if (Message.Length != 0)
            {
                output.WriteRawTag(34);
                output.WriteBytes(Message);
            }
            if (_unknownFields != null)
            {
                _unknownFields.WriteTo(ref output);
            }
        }
#endif

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int CalculateSize()
        {
            int size = 0;
            if (MType != global::CommunicationModels.Models.OuterMessage.Types.MessageType.Error)
            {
                size += 1 + pb::CodedOutputStream.ComputeEnumSize((int)MType);
            }
            if (RType != global::CommunicationModels.Models.OuterMessage.Types.RequestType.None)
            {
                size += 1 + pb::CodedOutputStream.ComputeEnumSize((int)RType);
            }
            if (stamp_ != null)
            {
                size += 1 + pb::CodedOutputStream.ComputeMessageSize(Stamp);
            }
            if (Message.Length != 0)
            {
                size += 1 + pb::CodedOutputStream.ComputeBytesSize(Message);
            }
            if (_unknownFields != null)
            {
                size += _unknownFields.CalculateSize();
            }
            return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(OuterMessage other)
        {
            if (other == null)
            {
                return;
            }
            if (other.MType != global::CommunicationModels.Models.OuterMessage.Types.MessageType.Error)
            {
                MType = other.MType;
            }
            if (other.RType != global::CommunicationModels.Models.OuterMessage.Types.RequestType.None)
            {
                RType = other.RType;
            }
            if (other.stamp_ != null)
            {
                if (stamp_ == null)
                {
                    Stamp = new global::Google.Protobuf.WellKnownTypes.Timestamp();
                }
                Stamp.MergeFrom(other.Stamp);
            }
            if (other.Message.Length != 0)
            {
                Message = other.Message;
            }
            _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(pb::CodedInputStream input)
        {
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
            input.ReadRawMessage(this);
#else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            MType = (global::CommunicationModels.Models.OuterMessage.Types.MessageType) input.ReadEnum();
            break;
          }
          case 16: {
            RType = (global::CommunicationModels.Models.OuterMessage.Types.RequestType) input.ReadEnum();
            break;
          }
          case 26: {
            if (stamp_ == null) {
              Stamp = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            }
            input.ReadMessage(Stamp);
            break;
          }
          case 34: {
            Message = input.ReadBytes();
            break;
          }
        }
      }
#endif
        }

#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input)
        {
            uint tag;
            while ((tag = input.ReadTag()) != 0)
            {
                switch (tag)
                {
                    default:
                        _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
                        break;
                    case 8:
                        {
                            MType = (global::CommunicationModels.Models.OuterMessage.Types.MessageType)input.ReadEnum();
                            break;
                        }
                    case 16:
                        {
                            RType = (global::CommunicationModels.Models.OuterMessage.Types.RequestType)input.ReadEnum();
                            break;
                        }
                    case 26:
                        {
                            if (stamp_ == null)
                            {
                                Stamp = new global::Google.Protobuf.WellKnownTypes.Timestamp();
                            }
                            input.ReadMessage(Stamp);
                            break;
                        }
                    case 34:
                        {
                            Message = input.ReadBytes();
                            break;
                        }
                }
            }
        }
#endif

        #region Nested types
        /// <summary>Container for nested types declared in the OuterMessage message type.</summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static partial class Types
        {
            public enum MessageType
            {
                [pbr::OriginalName("ERROR")] Error = 0,
                [pbr::OriginalName("RESPONSE")] Response = 1,
                [pbr::OriginalName("REQUEST")] Request = 2,
                [pbr::OriginalName("PULSE")] Pulse = 3,
            }

            public enum RequestType
            {
                [pbr::OriginalName("NONE")] None = 0,
                [pbr::OriginalName("CREATEGROUP")] Creategroup = 1,
            }

        }
        #endregion

    }

    #endregion

}

#endregion Designer generated code