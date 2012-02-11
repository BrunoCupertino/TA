using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TA.Domain.Entity
{
    public interface IEntidade : IComparable<IEntidade>, IEquatable<IEntidade>
    {
        int Id { get; set; }
    }
}
