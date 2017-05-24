/**
 * Autogenerated by Thrift Compiler (0.10.0)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;

namespace grafo_thrift
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class grafo : TBase
  {
    private List<vertice> _Lvertices;
    private List<aresta> _Larestas;

    public List<vertice> Lvertices
    {
      get
      {
        return _Lvertices;
      }
      set
      {
        __isset.Lvertices = true;
        this._Lvertices = value;
      }
    }

    public List<aresta> Larestas
    {
      get
      {
        return _Larestas;
      }
      set
      {
        __isset.Larestas = true;
        this._Larestas = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool Lvertices;
      public bool Larestas;
    }

    public grafo() {
    }

    public void Read (TProtocol iprot)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 1:
              if (field.Type == TType.List) {
                {
                  Lvertices = new List<vertice>();
                  TList _list0 = iprot.ReadListBegin();
                  for( int _i1 = 0; _i1 < _list0.Count; ++_i1)
                  {
                    vertice _elem2;
                    _elem2 = new vertice();
                    _elem2.Read(iprot);
                    Lvertices.Add(_elem2);
                  }
                  iprot.ReadListEnd();
                }
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2:
              if (field.Type == TType.List) {
                {
                  Larestas = new List<aresta>();
                  TList _list3 = iprot.ReadListBegin();
                  for( int _i4 = 0; _i4 < _list3.Count; ++_i4)
                  {
                    aresta _elem5;
                    _elem5 = new aresta();
                    _elem5.Read(iprot);
                    Larestas.Add(_elem5);
                  }
                  iprot.ReadListEnd();
                }
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }
      finally
      {
        iprot.DecrementRecursionDepth();
      }
    }

    public void Write(TProtocol oprot) {
      oprot.IncrementRecursionDepth();
      try
      {
        TStruct struc = new TStruct("grafo");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (Lvertices != null && __isset.Lvertices) {
          field.Name = "Lvertices";
          field.Type = TType.List;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteListBegin(new TList(TType.Struct, Lvertices.Count));
            foreach (vertice _iter6 in Lvertices)
            {
              _iter6.Write(oprot);
            }
            oprot.WriteListEnd();
          }
          oprot.WriteFieldEnd();
        }
        if (Larestas != null && __isset.Larestas) {
          field.Name = "Larestas";
          field.Type = TType.List;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteListBegin(new TList(TType.Struct, Larestas.Count));
            foreach (aresta _iter7 in Larestas)
            {
              _iter7.Write(oprot);
            }
            oprot.WriteListEnd();
          }
          oprot.WriteFieldEnd();
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }
      finally
      {
        oprot.DecrementRecursionDepth();
      }
    }

    public override string ToString() {
      StringBuilder __sb = new StringBuilder("grafo(");
      bool __first = true;
      if (Lvertices != null && __isset.Lvertices) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Lvertices: ");
        __sb.Append(Lvertices);
      }
      if (Larestas != null && __isset.Larestas) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Larestas: ");
        __sb.Append(Larestas);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
