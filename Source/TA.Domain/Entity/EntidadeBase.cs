using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TA.Domain.Entity
{
    public abstract class EntidadeBase : IEntidade
    {
        #region IEntidade Members

        public int Id { get; set; }

        #endregion

        #region IComparable<IEntidade> Members

        public virtual int CompareTo(IEntidade other)
        {
            return this.Id.CompareTo(other.Id);
        }

        #region IEquatable<IEntidade> Members

        public bool Equals(IEntidade other)
        {
            return this.Id.Equals(other.Id);
        }

        #endregion

        #endregion

        public override bool Equals(object obj)
        {
            return this.Equals(obj as IEntidade);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public abstract override string ToString();
    }
}
