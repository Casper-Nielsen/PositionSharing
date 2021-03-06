// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Key.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace CommunicationModels.Models {

  /// <summary>Holder for reflection information generated from Key.proto</summary>
  public static partial class KeyReflection {

    #region Descriptor
    /// <summary>File descriptor for Key.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static KeyReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CglLZXkucHJvdG8SGkNvbW11bmljYXRpb25Nb2RlbHMuTW9kZWxzIoQBCgNL",
            "ZXkSNQoEdHlwZRgBIAEoDjInLkNvbW11bmljYXRpb25Nb2RlbHMuTW9kZWxz",
            "LktleS5LZXlUeXBlEgsKA2tleRgCIAEoDBIKCgJpdhgDIAEoDCItCgdLZXlU",
            "eXBlEggKBE5PTkUQABIHCgNBRVMQARIHCgNSU0EQAhIGCgJESBADYgZwcm90",
            "bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::CommunicationModels.Models.Key), global::CommunicationModels.Models.Key.Parser, new[]{ "Type", "Key_", "Iv" }, null, new[]{ typeof(global::CommunicationModels.Models.Key.Types.KeyType) }, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class Key : pb::IMessage<Key>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<Key> _parser = new pb::MessageParser<Key>(() => new Key());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Key> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::CommunicationModels.Models.KeyReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Key() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Key(Key other) : this() {
      type_ = other.type_;
      key_ = other.key_;
      iv_ = other.iv_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Key Clone() {
      return new Key(this);
    }

    /// <summary>Field number for the "type" field.</summary>
    public const int TypeFieldNumber = 1;
    private global::CommunicationModels.Models.Key.Types.KeyType type_ = global::CommunicationModels.Models.Key.Types.KeyType.None;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::CommunicationModels.Models.Key.Types.KeyType Type {
      get { return type_; }
      set {
        type_ = value;
      }
    }

    /// <summary>Field number for the "key" field.</summary>
    public const int Key_FieldNumber = 2;
    private pb::ByteString key_ = pb::ByteString.Empty;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pb::ByteString Key_ {
      get { return key_; }
      set {
        key_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "iv" field.</summary>
    public const int IvFieldNumber = 3;
    private pb::ByteString iv_ = pb::ByteString.Empty;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pb::ByteString Iv {
      get { return iv_; }
      set {
        iv_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Key);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Key other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Type != other.Type) return false;
      if (Key_ != other.Key_) return false;
      if (Iv != other.Iv) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Type != global::CommunicationModels.Models.Key.Types.KeyType.None) hash ^= Type.GetHashCode();
      if (Key_.Length != 0) hash ^= Key_.GetHashCode();
      if (Iv.Length != 0) hash ^= Iv.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (Type != global::CommunicationModels.Models.Key.Types.KeyType.None) {
        output.WriteRawTag(8);
        output.WriteEnum((int) Type);
      }
      if (Key_.Length != 0) {
        output.WriteRawTag(18);
        output.WriteBytes(Key_);
      }
      if (Iv.Length != 0) {
        output.WriteRawTag(26);
        output.WriteBytes(Iv);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (Type != global::CommunicationModels.Models.Key.Types.KeyType.None) {
        output.WriteRawTag(8);
        output.WriteEnum((int) Type);
      }
      if (Key_.Length != 0) {
        output.WriteRawTag(18);
        output.WriteBytes(Key_);
      }
      if (Iv.Length != 0) {
        output.WriteRawTag(26);
        output.WriteBytes(Iv);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Type != global::CommunicationModels.Models.Key.Types.KeyType.None) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Type);
      }
      if (Key_.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeBytesSize(Key_);
      }
      if (Iv.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeBytesSize(Iv);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Key other) {
      if (other == null) {
        return;
      }
      if (other.Type != global::CommunicationModels.Models.Key.Types.KeyType.None) {
        Type = other.Type;
      }
      if (other.Key_.Length != 0) {
        Key_ = other.Key_;
      }
      if (other.Iv.Length != 0) {
        Iv = other.Iv;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
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
            Type = (global::CommunicationModels.Models.Key.Types.KeyType) input.ReadEnum();
            break;
          }
          case 18: {
            Key_ = input.ReadBytes();
            break;
          }
          case 26: {
            Iv = input.ReadBytes();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 8: {
            Type = (global::CommunicationModels.Models.Key.Types.KeyType) input.ReadEnum();
            break;
          }
          case 18: {
            Key_ = input.ReadBytes();
            break;
          }
          case 26: {
            Iv = input.ReadBytes();
            break;
          }
        }
      }
    }
    #endif

    #region Nested types
    /// <summary>Container for nested types declared in the Key message type.</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static partial class Types {
      public enum KeyType {
        [pbr::OriginalName("NONE")] None = 0,
        [pbr::OriginalName("AES")] Aes = 1,
        [pbr::OriginalName("RSA")] Rsa = 2,
        [pbr::OriginalName("DH")] Dh = 3,
      }

    }
    #endregion

  }

  #endregion

}

#endregion Designer generated code
