using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackDemo
{
    class GetInt : ICloneable
    {
        public int I { get; set; }

        public GetInt(int i)
        {
            I = i;
        }

        public override string ToString()
        {
            return I.ToString();
        }

        public object Clone()
        {
            return new GetInt(I);
        }
    }

    class GetString : ICloneable
    {
        public string S { get; set; }

        public GetString(string s)
        {
            S = s;
        }

        public override string ToString()
        {
            return S.ToString();
        }

        public object Clone()
        {
            return new GetString(S);
        }
    }

    class GetDouble : ICloneable
    {
        public double D { get; set; }

        public GetDouble(double d)
        {
            D = d;
        }

        public override string ToString()
        {
            return D.ToString();
        }

        public object Clone()
        {
            return new GetDouble(D);
        }
    }

}
